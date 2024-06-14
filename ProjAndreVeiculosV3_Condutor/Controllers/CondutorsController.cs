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
    public class CondutorsController : ControllerBase
    {
        private readonly ProjAndreVeiculosV3_CondutorContext _context;

        public CondutorsController(ProjAndreVeiculosV3_CondutorContext context)
        {
            _context = context;
        }

        // GET: api/Condutors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Condutor>>> GetCondutor()
        {
          if (_context.Condutor == null)
          {
              return NotFound();
          }
            var Condutores = await _context.Condutor
                            .Include(p => p.CNH)
                            .Include(p => p.CNH.Categoria)
                            .ToListAsync();

            return Condutores;
        }

        // GET: api/Condutors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Condutor>> GetCondutor(string id)
        {
          if (_context.Condutor == null)
          {
              return NotFound();
          }
            var condutor = await _context.Condutor
                           .Include(p => p.CNH)
                           .Include(c => c.CNH.Categoria)
                           .FirstOrDefaultAsync();

            if (condutor == null)
            {
                return NotFound();
            }

            return condutor;
        }

        // PUT: api/Condutors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondutor(string id, Condutor condutor)
        {
            if (id != condutor.Documento)
            {
                return BadRequest();
            }

            _context.Entry(condutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondutorExists(id))
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

        // POST: api/Condutors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Condutor>> PostCondutor(CondutorDTO condutorDTO)
        {
          if (_context.Condutor == null)
          {
              return Problem("Entity set 'ProjAndreVeiculosV3_CondutorContext.Condutor'  is null.");
          }
            var condutor = new Condutor(condutorDTO);
            condutor.CNH = await _context.CNH.FindAsync(condutorDTO.CNHId);
            condutor.CNH.Categoria = await _context.Categoria.FindAsync(condutor.CNH.Categoria);
            condutor.Endereco = await _context.Endereco.FindAsync(condutorDTO.EnderecoId);

            _context.Condutor.Add(condutor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CondutorExists(condutor.Documento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCondutor", new { id = condutor.Documento }, condutor);
        }

        // DELETE: api/Condutors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondutor(string id)
        {
            if (_context.Condutor == null)
            {
                return NotFound();
            }
            var condutor = await _context.Condutor.FindAsync(id);
            if (condutor == null)
            {
                return NotFound();
            }

            _context.Condutor.Remove(condutor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CondutorExists(string id)
        {
            return (_context.Condutor?.Any(e => e.Documento == id)).GetValueOrDefault();
        }
    }
}
