﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using ProjAndreVeiculosV3_Venda.Data;

namespace ProjAndreVeiculosV3_Venda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly ProjAndreVeiculosV3_VendaContext _context;

        public VendasController(ProjAndreVeiculosV3_VendaContext context)
        {
            _context = context;
        }

        // GET: api/Vendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> GetVenda()
        {
          if (_context.Venda == null)
          {
              return NotFound();
          }

            var vendas = await _context.Venda
                .Include(v => v.Cliente)
                .Include(v => v.Carro)
                .Include(v => v.Pagamento)
                .Include(v => v.Funcionario)
                .ToListAsync();

            return vendas;
        }

        // GET: api/Vendas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
          if (_context.Venda == null)
          {
              return NotFound();
          }
            var venda = await _context.Venda
                    .Include(v => v.Cliente)
                    .Include(v => v.Carro)
                    .Include(v => v.Pagamento)
                    .Include(v => v.Funcionario)
                    .FirstOrDefaultAsync(v => v.Id == id);

            if (venda == null)
            {
                return NotFound();
            }

            return venda;

        }

        // PUT: api/Vendas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenda(int id, Venda venda)
        {
            if (id != venda.Id)
            {
                return BadRequest();
            }

            _context.Entry(venda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaExists(id))
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

        // POST: api/Vendas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Venda>> PostVenda(VendaDTO vendaDTO)
        {
          if (_context.Venda == null)
          {
              return Problem("Entity set 'ProjAndreVeiculosV3_VendaContext.Venda'  is null.");
          }
            Venda venda = new Venda(vendaDTO);
            venda.Carro = await _context.Carro.FindAsync(venda.Carro.Placa);
            venda.Cliente = await _context.Cliente.FindAsync(venda.Cliente.Documento);
            venda.Funcionario = await _context.Funcionario.FindAsync(venda.Funcionario.Documento);
            venda.Pagamento = await _context.Pagamento.FindAsync(venda.Pagamento.Id);

            _context.Venda.Add(venda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenda", new { id = venda.Id }, venda);
        }

        // DELETE: api/Vendas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenda(int id)
        {
            if (_context.Venda == null)
            {
                return NotFound();
            }
            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            _context.Venda.Remove(venda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendaExists(int id)
        {
            return (_context.Venda?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
