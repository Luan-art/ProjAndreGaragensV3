using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using ProjAndreVeiculosV3_ValidacaoPendenciaFinanceira.Data;

namespace ProjAndreVeiculosV3_ValidacaoPendenciaFinanceira.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PendenciasFinanceirasController : ControllerBase
    {
        private readonly ProjAndreVeiculosV3_ValidacaoPendenciaFinanceiraContext _context;

        public PendenciasFinanceirasController(ProjAndreVeiculosV3_ValidacaoPendenciaFinanceiraContext context)
        {
            _context = context;
        }

        // GET: api/PendenciasFinanceiras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PendenciaFinanceira>>> GetPendenciaFinanceira()
        {
          if (_context.PendenciaFinanceira == null)
          {
              return NotFound();
          }
            return await _context.PendenciaFinanceira.ToListAsync();
        }

        // GET: api/PendenciasFinanceiras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PendenciaFinanceira>> GetPendenciaFinanceira(int id)
        {
          if (_context.PendenciaFinanceira == null)
          {
              return NotFound();
          }
            var pendenciaFinanceira = await _context.PendenciaFinanceira.FindAsync(id);

            if (pendenciaFinanceira == null)
            {
                return NotFound();
            }

            return pendenciaFinanceira;
        }

        // PUT: api/PendenciasFinanceiras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPendenciaFinanceira(int id, PendenciaFinanceira pendenciaFinanceira)
        {
            if (id != pendenciaFinanceira.Id)
            {
                return BadRequest();
            }

            _context.Entry(pendenciaFinanceira).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PendenciaFinanceiraExists(id))
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

        // POST: api/PendenciasFinanceiras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PendenciaFinanceira>> PostPendenciaFinanceira(PendenciaFinanceiraDTO pendenciaFinanceiraDTO)
        {
          if (_context.PendenciaFinanceira == null)
          {
              return Problem("Entity set 'ProjAndreVeiculosV3_ValidacaoPendenciaFinanceiraContext.PendenciaFinanceira'  is null.");
          }

          PendenciaFinanceira pendenciaFinanceira = new PendenciaFinanceira(pendenciaFinanceiraDTO);
            
        //  pendenciaFinanceira.Cliente.Endereco = await _context.Endereco.FindAsync(pendenciaFinanceira.Cliente.Endereco.Id);//
            pendenciaFinanceira.Cliente = await _context.Cliente.FindAsync(pendenciaFinanceiraDTO.ClienteDocumento);
          
            _context.PendenciaFinanceira.Add(pendenciaFinanceira);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPendenciaFinanceira", new { id = pendenciaFinanceira.Id }, pendenciaFinanceira);
        }

        // DELETE: api/PendenciasFinanceiras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePendenciaFinanceira(int id)
        {
            if (_context.PendenciaFinanceira == null)
            {
                return NotFound();
            }
            var pendenciaFinanceira = await _context.PendenciaFinanceira.FindAsync(id);
            if (pendenciaFinanceira == null)
            {
                return NotFound();
            }

            _context.PendenciaFinanceira.Remove(pendenciaFinanceira);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PendenciaFinanceiraExists(int id)
        {
            return (_context.PendenciaFinanceira?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
