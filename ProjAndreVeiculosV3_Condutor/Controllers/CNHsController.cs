using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using ProjAndreVeiculosV3_Condutor.Data;

namespace ProjAndreVeiculosV3_Condutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CNHsController : ControllerBase
    {
        private readonly ProjAndreVeiculosV3_CondutorContext _context;

        public CNHsController(ProjAndreVeiculosV3_CondutorContext context)
        {
            _context = context;
        }

        // GET: api/CNHs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CNH>>> GetCNH()
        {
            if (_context.CNH == null)
            {
                return NotFound();
            }
            var CNHS = await _context.CNH
                            .Include(p => p.Categoria)
                            .ToListAsync();

            return CNHS;
        }

        // GET: api/CNHs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CNH>> GetCNH(string id)
        {
            if (_context.CNH == null)
            {
                return NotFound();
            }
            var CNH = await _context.CNH
                            .Include(p => p.Categoria)
                            .FirstOrDefaultAsync();

            if (CNH == null)
            {
                return NotFound();
            }

            return CNH;
        }

        // PUT: api/CNHs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCNH(string id, CNH cNH)
        {
            if (id != cNH.Cnh)
            {
                return BadRequest();
            }

            _context.Entry(cNH).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CNHExists(id))
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

        // POST: api/CNHs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CNH>> PostCNH(CNHDTO cNHDTO)
        {
            if (_context.CNH == null)
            {
                return Problem("Entity set 'ProjAndreVeiculosV3_CondutorContext.CNH'  is null.");
            }

            CNH cnh = new CNH(cNHDTO);

            cnh.Categoria = await _context.Categoria.FindAsync(cNHDTO.CategoriaID);

            _context.CNH.Add(cnh);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CNHExists(cnh.Cnh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCNH", new { id = cnh.Cnh }, cnh);
        }

        // DELETE: api/CNHs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCNH(string id)
        {
            if (_context.CNH == null)
            {
                return NotFound();
            }
            var cNH = await _context.CNH.FindAsync(id);
            if (cNH == null)
            {
                return NotFound();
            }

            _context.CNH.Remove(cNH);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CNHExists(string id)
        {
            return (_context.CNH?.Any(e => e.Cnh == id)).GetValueOrDefault();
        }
    }
}
