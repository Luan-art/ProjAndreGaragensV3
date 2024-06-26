﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using ProjAndreVeiculosV3_Pagamento.Data;

namespace ProjAndreVeiculosV3_Pagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly ProjAndreVeiculosV3_PagamentoContext _context;

        public PagamentosController(ProjAndreVeiculosV3_PagamentoContext context)
        {
            _context = context;
        }

        // GET: api/Pagamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pagamento>>> GetPagamento()
        {
          if (_context.Pagamento == null)
          {
              return NotFound();
          }

            var pagamentos = await _context.Pagamento
                .Include(p => p.Boleto)
                .Include(p => p.Cartao)
                .Include(p => p.Pix)
                .Include(tp => tp.Pix.Tipo)
                .ToListAsync();

            return pagamentos;
        }

        // GET: api/Pagamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pagamento>> GetPagamento(int id)
        {
          if (_context.Pagamento == null)
          {
              return NotFound();
          }
            var pagamento = await _context.Pagamento
                   .Include(p => p.Boleto)
                   .Include(p => p.Cartao)
                   .Include(p => p.Pix)
                   .FirstOrDefaultAsync(p => p.Id == id);

            if (pagamento == null)
            {
                return NotFound();
            }

            return pagamento;
        }

        // PUT: api/Pagamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagamento(int id, Pagamento pagamento)
        {
            if (id != pagamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(pagamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagamentoExists(id))
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

        // POST: api/Pagamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pagamento>> PostPagamento(PagamentoDTO pagamentoDTO)
        {
          if (_context.Pagamento == null)
          {
              return Problem("Entity set 'ProjAndreVeiculosV3_PagamentoContext.Pagamento'  is null.");
          }
            Pagamento pagamento = new Pagamento(pagamentoDTO);

            pagamento.Boleto = await _context.Boleto.FindAsync(pagamentoDTO.Boleto);
            pagamento.Cartao = await _context.Cartao.FindAsync(pagamentoDTO.Cartao);
            pagamento.Pix = await _context.Pix.FindAsync(pagamentoDTO.Pix);

            _context.Pagamento.Add(pagamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPagamento", new { id = pagamento.Id }, pagamento);
        }

        // DELETE: api/Pagamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagamento(int id)
        {
            if (_context.Pagamento == null)
            {
                return NotFound();
            }
            var pagamento = await _context.Pagamento.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound();
            }

            _context.Pagamento.Remove(pagamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PagamentoExists(int id)
        {
            return (_context.Pagamento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
