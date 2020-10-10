using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hacka_getnet;
using hacka_getnet.Entidades;

namespace hacka_getnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncentivadorController : ControllerBase
    {
        private readonly Context _context;

        public IncentivadorController(Context context)
        {
            _context = context;
        }

        // GET: api/Incentivador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incentivador>>> GetIncentivador()
        {
            return await _context.Incentivador.ToListAsync();
        }

        // GET: api/Incentivador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Incentivador>> GetIncentivador(int id)
        {
            var incentivador = await _context.Incentivador.FindAsync(id);

            if (incentivador == null)
            {
                return NotFound();
            }

            return incentivador;
        }

        // PUT: api/Incentivador/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncentivador(int id, Incentivador incentivador)
        {
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
        public async Task<ActionResult<Incentivador>> PostIncentivador(Incentivador incentivador)
        {
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
