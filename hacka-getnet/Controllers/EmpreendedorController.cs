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
using Microsoft.AspNetCore.Authorization;
using hacka_getnet.Token;
using hacka_getnet.DTO;

namespace hacka_getnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpreendedorController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EmpreendedorController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] LoginDTO loginDTO)
        {
            // Recupera o usuário
            var user = await _context.Empreendedor                
                .Where(x => x.Usuario == loginDTO.Usuario && x.Senha == loginDTO.Senha)
                                                  .FirstOrDefaultAsync();

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user.Usuario, "Empreendedor");

            // Oculta a senha
            user.Senha = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
        // GET: api/Empreendedor
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<EmpreendedorDTO>>> GetEmpreendedor()
        {
            var empreendedores = await _context.Empreendedor.Include(x=>x.Endereco).Include(x=>x.Cartao).ToListAsync();
            var lista = new List<EmpreendedorDTO>();

            foreach(var empreendedor in empreendedores)
            {
                var empreendedorDTO = _mapper.Map<Empreendedor,EmpreendedorDTO>(empreendedor);
                empreendedorDTO.EnderecoEmpreendedorDTO = _mapper.Map<EnderecoEmpreendedor, EnderecoEmpreendedorDTO>(empreendedor.Endereco);
                empreendedorDTO.CartaoEmpreendedorDTO = _mapper.Map<CartaoEmpreendedor, CartaoEmpreendedorDTO>(empreendedor.Cartao);

                lista.Add(empreendedorDTO);
            }
            
            

            return lista;
        }

        // GET: api/Empreendedor/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<EmpreendedorDTO>> GetEmpreendedor(int id)
        {
            var empreendedor = await _context.Empreendedor.Include(x => x.Endereco)
                                            .Include(x => x.Cartao)
                                            .Where(x => x.Id == id)
                                            .FirstOrDefaultAsync();


            if (empreendedor == null)
            {
                return NotFound();
            }

            var empreendedorDTO = _mapper.Map<Empreendedor, EmpreendedorDTO>(empreendedor);
            empreendedorDTO.EnderecoEmpreendedorDTO = _mapper.Map<EnderecoEmpreendedor, EnderecoEmpreendedorDTO>(empreendedor.Endereco);
            empreendedorDTO.CartaoEmpreendedorDTO = _mapper.Map<CartaoEmpreendedor, CartaoEmpreendedorDTO>(empreendedor.Cartao);

            return empreendedorDTO;
        }

        // PUT: api/Empreendedor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutEmpreendedor(int id, CadastroEmpreendedorDTO empreendedorDTO)
        {
            var empreendedor = _mapper.Map<CadastroEmpreendedorDTO, Empreendedor>(empreendedorDTO);
            var endereco = _mapper.Map<EnderecoEmpreendedorDTO, EnderecoEmpreendedor>(empreendedorDTO.EnderecoEmpreendedorDTO);
            var cartao = _mapper.Map<CartaoEmpreendedorDTO, CartaoEmpreendedor>(empreendedorDTO.CartaoEmpreendedorDTO);

            if (id != empreendedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(empreendedor).State = EntityState.Modified;
            _context.Entry(endereco ).State = EntityState.Modified;
            _context.Entry(cartao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpreendedorExists(id))
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

        // POST: api/Empreendedor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<EmpreendedorDTO>> PostEmpreendedor(CadastroEmpreendedorDTO empreendedorDTO)
        {
            var empreendedor = _mapper.Map<CadastroEmpreendedorDTO, Empreendedor>(empreendedorDTO);
            empreendedor.Endereco = _mapper.Map<EnderecoEmpreendedorDTO, EnderecoEmpreendedor>(empreendedorDTO.EnderecoEmpreendedorDTO);
            empreendedor.Cartao = _mapper.Map<CartaoEmpreendedorDTO, CartaoEmpreendedor>(empreendedorDTO.CartaoEmpreendedorDTO);

            _context.Empreendedor.Add(empreendedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpreendedor", new { id = empreendedor.Id });
        }

        // DELETE: api/Empreendedor/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Empreendedor>> DeleteEmpreendedor(int id)
        {
            var empreendedor = await _context.Empreendedor.FindAsync(id);
            if (empreendedor == null)
            {
                return NotFound();
            }

            _context.Empreendedor.Remove(empreendedor);
            await _context.SaveChangesAsync();

            return empreendedor;
        }

        private bool EmpreendedorExists(int id)
        {
            return _context.Empreendedor.Any(e => e.Id == id);
        }
    }
}
