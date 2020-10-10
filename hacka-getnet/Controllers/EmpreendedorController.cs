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
    public class EmpreendedorController : ControllerBase
    {
        private readonly Context _context;

        public EmpreendedorController(Context context)
        {
            _context = context;
        }

        // GET: api/Empreendedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empreendedor>>> GetEmpreendedor()
        {
            return await _context.Empreendedor.ToListAsync();
        }

        // GET: api/Empreendedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empreendedor>> GetEmpreendedor(int id)
        {
            var empreendedor = await _context.Empreendedor.FindAsync(id);

            if (empreendedor == null)
            {
                return NotFound();
            }

            return empreendedor;
        }

        // PUT: api/Empreendedor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpreendedor(int id, Empreendedor empreendedor)
        {
            if (id != empreendedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(empreendedor).State = EntityState.Modified;

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
        public async Task<ActionResult<Empreendedor>> PostEmpreendedor(Empreendedor empreendedor)
        {
            _context.Empreendedor.Add(empreendedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpreendedor", new { id = empreendedor.Id }, empreendedor);
        }

        // DELETE: api/Empreendedor/5
        [HttpDelete("{id}")]
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
