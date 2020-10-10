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
        public async Task<ActionResult<IEnumerable<SolicitacaoCreditoDTO>>> GetSolicitacaoCredito()
        {
            var lista = await _context.SolicitacaoCredito.ToListAsync();

            var dto = _mapper.Map<List<SolicitacaoCredito>, List<SolicitacaoCreditoDTO>>(lista);
            return dto;
        }

        // GET: api/SolicitacaoCredito/5
        [HttpGet("{id}")]
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

        // PUT: api/SolicitacaoCredito/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSolicitacaoCredito(int id, SolicitacaoCredito solicitacaoCredito)
        //{
        //    if (id != solicitacaoCredito.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(solicitacaoCredito).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SolicitacaoCreditoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/SolicitacaoCredito
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SolicitacaoCreditoDTO>> PostSolicitacaoCredito(CadastroSolicitacaoCreditoDTO solicitacaoCreditoDTO)
        {
            var solicitacaoCredito = _mapper.Map<CadastroSolicitacaoCreditoDTO, SolicitacaoCredito>(solicitacaoCreditoDTO);
            _context.SolicitacaoCredito.Add(solicitacaoCredito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolicitacaoCredito", new { id = solicitacaoCredito.Id }, solicitacaoCredito);
        }

        // DELETE: api/SolicitacaoCredito/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SolicitacaoCredito>> DeleteSolicitacaoCredito(int id)
        {
            var solicitacaoCredito = await _context.SolicitacaoCredito.FindAsync(id);
            if (solicitacaoCredito == null)
            {
                return NotFound();
            }

            _context.SolicitacaoCredito.Remove(solicitacaoCredito);
            await _context.SaveChangesAsync();

            return solicitacaoCredito;
        }

        private bool SolicitacaoCreditoExists(int id)
        {
            return _context.SolicitacaoCredito.Any(e => e.Id == id);
        }
    }
}
