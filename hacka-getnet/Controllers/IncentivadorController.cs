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
using System.IO;
using Firebase.Storage;
using hacka_getnet.Token;
using Microsoft.AspNetCore.Authorization;
using hacka_getnet.DTO;

namespace hacka_getnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncentivadorController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        //
        public IncentivadorController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost("Login")]        
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] LoginDTO loginDTO)
        {
            // Recupera o usuário
            var user = await _context.Incentivador.Where(x => x.Usuario == loginDTO.Usuario && x.Senha == loginDTO.Senha)
                                                  .FirstOrDefaultAsync();

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user.Usuario, "Incentivador");

            // Oculta a senha
            user.Senha = "";

            // Retorna os dados
            return new
            {
                user = user,                
                token = token
            };
        }

        // GET: api/Incentivador
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<IncentivadorDTO>>> GetIncentivador()
        {
            var lista =  await _context.Incentivador.ToListAsync();

            var dto = _mapper.Map<List<Incentivador>, List<IncentivadorDTO>>(lista);

            return dto;
        }

        // GET: api/Incentivador/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<IncentivadorDTO>> GetIncentivador(int id)
        {
            var incentivador = await _context.Incentivador.FindAsync(id);

            if (incentivador == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<Incentivador, IncentivadorDTO>(incentivador);
            return dto;
        }

        // PUT: api/Incentivador/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutIncentivador(int id, CadastroIncentivadorDTO incentivadorDTO)
        {
            var incentivador = _mapper.Map<CadastroIncentivadorDTO, Incentivador>(incentivadorDTO);

            if (id != incentivador.Id)
            {
                return BadRequest();
            }

            _context.Entry(incentivador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncentivadorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Incentivador
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<IncentivadorDTO>> PostIncentivador(CadastroIncentivadorDTO incentivadorDTO)
        {
            var incentivador = _mapper.Map<CadastroIncentivadorDTO, Incentivador>(incentivadorDTO);
            incentivador.Role = "Incentivador";
            _context.Incentivador.Add(incentivador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncentivador", new { id = incentivador.Id }, incentivador);
        }

        // DELETE: api/Incentivador/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Incentivador>> DeleteIncentivador(int id)
        {
            var incentivador = await _context.Incentivador.FindAsync(id);
            if (incentivador == null)
            {
                return NotFound();
            }

            _context.Incentivador.Remove(incentivador);
            await _context.SaveChangesAsync();

            return incentivador;
        }

        [Route("upload-comprovante")]
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadAsync(IFormFile file, int idIncentivador, int idSolicitacaoCredito)
        {
            var incentivador = await _context.Incentivador.FindAsync(idIncentivador);
            if (incentivador == null)
            {
                return NotFound();
            }


            var solicitacaoCredito = await _context.SolicitacaoCredito.FindAsync(idSolicitacaoCredito);
            if (solicitacaoCredito == null)
            {
                return NotFound();
            }


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
                //.Child("Usuario")
                .Child(nomeArquivo)
                .PutAsync(stream);

            if(!string.IsNullOrEmpty(urlImagem))
            {
                _context.ComprovanteIncentivo.Add(new ComprovanteIncentivo
                {
                    IncentivadorId = idIncentivador,
                    SolicitacaoCreditoId = idSolicitacaoCredito,
                    DataUpload = DateTime.Now,
                    UrlImagem = urlImagem,
                });

                await _context.SaveChangesAsync();
            }            


            return Created(urlImagem, urlImagem);
        }

        private bool IncentivadorExists(int id)
        {
            return _context.Incentivador.Any(e => e.Id == id);
        }
    }
}
