using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hacka_getnet;
using hacka_getnet.Entidades;
using AutoMapper;
using Firebase.Storage;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Newtonsoft.Json;
using hacka_getnet.DTO;
using System.Net.Http.Headers;
using hacka_getnet.Entidades.GetNet;
using System.IO.Compression;
using System.Text;

namespace hacka_getnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PagamentoController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        //
        public PagamentoController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> RealizaPagamentoSolicitacaoCredito(int idIncentivador, int idSolicitacaoCredito, decimal valor)
        {

            var incentivador = await _context.Incentivador.FindAsync(idIncentivador);

            if(incentivador == null)
            {
                return NotFound("Incenticador nao encontrado");
            }

            var solicitacaoCredito = await _context.SolicitacaoCredito.FindAsync(idSolicitacaoCredito);

            if (incentivador == null)
            {
                return NotFound("Solicitacao de Credito nao encontrada");
            }


            var empreendedor = await _context.Empreendedor.FindAsync(solicitacaoCredito.EmpreendedorId);

            if (empreendedor == null)
            {
                return NotFound("Empreendedor nao encontrado");
            }

            //Processa  API PIX
            //todo consumir a api do PIX

            //Processou corretamento o PIX
            _context.PagamentoSolicitacaoCreditoPIX.Add(new PagamentoSolicitacaoCreditoPIX
            {
                ChavePixOrigem = incentivador.ChavePix,
                ChavePixDestino = empreendedor.ChavePix,
                IdTransacaoPIX = new Guid().ToString(),
                Valor = valor,
                DataPagamento = DateTime.Now,
                SolicitacaoCreditoId = solicitacaoCredito.Id,
                StatusPagamento = StatusPagamento.PENDENTE_RESGATAR,
            });

            await _context.SaveChangesAsync();


            return Ok();
        }

        [HttpGet("buscar-pagamentos-solicitacao")]
        public async Task<ActionResult> BuscaPagamentoSolicitacao(int idSolicitacaoCredito)
        {
            
            var solicitacaoCredito = await _context.SolicitacaoCredito.FindAsync(idSolicitacaoCredito);
            var pagamentos = _context.PagamentoSolicitacaoCreditoPIX.Where(x => x.SolicitacaoCreditoId == idSolicitacaoCredito).ToList();

            if (solicitacaoCredito == null)
            {
                return NotFound("Solicitacao de Credito nao encontrada");
            }
 
            return Ok(pagamentos.Select(x=> new {x.Valor, x.DataPagamento }));
        }

        [HttpGet("resgatar-pagamento")]
        public async Task<ActionResult> ResgatarPagamentoSolicitacao(int idSolicitacaoCredito)
        {
            var configuracaoApp = await _context.ConfiguracaoApp.FirstAsync();
            var solicitacaoCredito = await _context.SolicitacaoCredito.FindAsync(idSolicitacaoCredito);

            if (solicitacaoCredito == null)
            {
                return NotFound("Solicitacao de Credito nao encontrada");
            }

            var empreendedor = await _context.Empreendedor.FindAsync(solicitacaoCredito.EmpreendedorId);

            if (empreendedor == null)
            {
                return NotFound("Empreendedor nao encontrado");
            }


            var pagamentos = _context.PagamentoSolicitacaoCreditoPIX.Where(x => x.SolicitacaoCreditoId == idSolicitacaoCredito &&
                                                                                x.StatusPagamento == StatusPagamento.PENDENTE_RESGATAR).ToList();



            //Envia do PIX Plim para o PIX da Dona Maria
            var totalPagamento = pagamentos.Sum(x => x.Valor);
            var juros = (totalPagamento * (decimal)configuracaoApp.TaxaJurosACobrarDoEmpreendedor) / 100;
            totalPagamento = totalPagamento + juros;

            //atualiza o status de cada pagamento
            foreach (var pagamento in pagamentos)
            {
                pagamento.StatusPagamento = StatusPagamento.RESGATADO;
            }


            //gera a cobranca recorrente via getNet para dona Maria
            for (int i = 1; i <= solicitacaoCredito.QuantidadeParcelasReembolso; i++)
            {
                //cria uma linha para cobranca recorrente
                _context.CobrancaRecorrente.Add(
                new CobrancaRecorrente
                {
                    EmpreendedorId = empreendedor.Id,
                    DataCobranca = DateTime.Now.AddMonths(i),
                    Valor = totalPagamento / solicitacaoCredito.QuantidadeParcelasReembolso,
                });
            }


            //encerra a solicitacao
            solicitacaoCredito.StatusSolicitacaoCredito = StatusSolicitacaoCredito.RESGATADA;

            await _context.SaveChangesAsync();



            return Ok();
        }

        [HttpGet("buscar-cobrancas-recorrentes")]
        public async Task<ActionResult> BuscaCobrancaRecorrente(int idEmpreendedor)
        {

            var cobrancaRecorrente =  await _context.CobrancaRecorrente.Where(x => x.EmpreendedorId == idEmpreendedor).ToListAsync();
            

            if (cobrancaRecorrente == null)
            {
                return NotFound();
            }

            return Ok(cobrancaRecorrente.Select(x => new { x.Valor, x.DataCobranca, StatusCobrancaRecorrente = x.StatusCobrancaRecorrente.ToString() }));
        }


        private async Task<string> GeraToken()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic ZDZkOTg3MWMtMjRiMy00NGFiLTg5YTEtMjFlMzI3MjdlNTQwOmJjZjAwNjcwLTU4MWEtNDEzZS04NDY5LWY1NTljMDU5MzZkMA==");

                var data = new Dictionary<string, string>();
                data.Add("scope", "oob");
                data.Add("grant_type", "client_credentials");

                using (var content = new FormUrlEncodedContent(data))
                {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");


                    var response = await httpClient.PostAsync("https://api-sandbox.getnet.com.br/auth/oauth/v2/token", content);

                    var stringJson = await response.Content.ReadAsStringAsync();
                    var token = JsonConvert.DeserializeObject<AcessTokenGetNet>(stringJson);

                    return  await Task.FromResult<string>( token.access_token);
                }
            }

            
        }

        // GET: api/SolicitacaoCredito        
        private async Task<TokenCartao> GeraTokenCartaoCredito()
        {
            var cartao = new
            {
                card_number = "5155901222280001",
                customer_id  = "teste"
            };
            var json =  System.Text.Json.JsonSerializer.Serialize(cartao);
            
            var configuracaoApp = await _context.ConfiguracaoApp.FirstOrDefaultAsync();

            var bearerToken = await GeraToken();
            var httpClient = new HttpClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://api-sandbox.getnet.com.br/v1/tokens/card");

            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
            httpClient.DefaultRequestHeaders.Add("seller_id", configuracaoApp.GetNetId);

            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           // httpClient.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf8"));

            requestMessage.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.SendAsync(requestMessage);
            
            Stream responded = response.Content.ReadAsStreamAsync().Result;
            Stream decompressed = new GZipStream(responded, CompressionMode.Decompress);
            StreamReader objReader = new StreamReader(decompressed, Encoding.UTF8);
            string sLine =  objReader.ReadToEnd();

            var token = JsonConvert.DeserializeObject<TokenCartao>(sLine);

            return token;
        }

      
    }
}