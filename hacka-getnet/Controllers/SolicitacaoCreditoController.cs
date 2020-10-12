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

namespace hacka_getnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SolicitacaoCreditoController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        //
        public SolicitacaoCreditoController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/SolicitacaoCredito
        [HttpGet]
        //[Authorize(Roles = "Incentivador, Empreendedor")]
        public async Task<ActionResult<IEnumerable<SolicitacaoCreditoDTO>>> GetSolicitacaoCredito()
        {
            var lista = await _context.SolicitacaoCredito.ToListAsync();

            var dto = _mapper.Map<List<SolicitacaoCredito>, List<SolicitacaoCreditoDTO>>(lista);
            return dto;
        }

        // GET: api/SolicitacaoCredito/5
        [HttpGet("{id}")]
        //[Authorize(Roles = "Incentivador, Empreendedor")]
        public async Task<ActionResult<SolicitacaoCreditoDTO>> GetSolicitacaoCredito(int id)
        {
            var solicitacaoCredito = await _context.SolicitacaoCredito.FindAsync(id);

            if (solicitacaoCredito == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<SolicitacaoCredito, SolicitacaoCreditoDTO>(solicitacaoCredito);
            return dto;
        }
       

        // POST: api/SolicitacaoCredito
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        //[Authorize(Roles = "Empreendedor")]
        public async Task<ActionResult<SolicitacaoCreditoDTO>> PostSolicitacaoCredito(
            [FromForm] CadastroSolicitacaoCreditoDTO solicitacaoCreditoDTO,
            IFormFile file)
        {
            var solicitacaoCredito = _mapper.Map<CadastroSolicitacaoCreditoDTO, SolicitacaoCredito>(solicitacaoCreditoDTO);

            string Bucket = "hacka-getnet.appspot.com";
            MemoryStream stream = null;

            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    stream = new MemoryStream(fileBytes);
                }
            }

            long dateLong = DateTime.Now.Ticks;
            var extensao = Path.GetExtension(file.FileName);

            string nomeArquivo = $"{dateLong}{extensao}";

            var urlImagem = await new FirebaseStorage(Bucket)
                .Child("SolicitacaoCredito")
                .Child(nomeArquivo)
                .PutAsync(stream);

            if (!string.IsNullOrEmpty(urlImagem))
            {

                solicitacaoCredito.UrlImagem = urlImagem;
            }
            
            _context.SolicitacaoCredito.Add(solicitacaoCredito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolicitacaoCredito", new { id = solicitacaoCredito.Id }, solicitacaoCredito);
        }


        private bool SolicitacaoCreditoExists(int id)
        {
            return _context.SolicitacaoCredito.Any(e => e.Id == id);
        }
    }
}
