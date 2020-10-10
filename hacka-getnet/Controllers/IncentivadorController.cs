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

        // GET: api/Incentivador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncentivadorDTO>>> GetIncentivador()
        {
            var lista =  await _context.Incentivador.ToListAsync();

            var dto = _mapper.Map<List<Incentivador>, List<IncentivadorDTO>>(lista);

            return dto;
        }

        // GET: api/Incentivador/5
        [HttpGet("{id}")]
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
        public async Task<ActionResult<IncentivadorDTO>> PostIncentivador(CadastroIncentivadorDTO incentivadorDTO)
        {
            var incentivador = _mapper.Map<CadastroIncentivadorDTO, Incentivador>(incentivadorDTO);
            _context.Incentivador.Add(incentivador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncentivador", new { id = incentivador.Id }, incentivador);
        }

        // DELETE: api/Incentivador/5
        [HttpDelete("{id}")]
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

        private bool IncentivadorExists(int id)
        {
            return _context.Incentivador.Any(e => e.Id == id);
        }
    }
}
