using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using ProjAndreVeiculosV3_Financiamento.Data;
using ProjAndreVeiculosV3_Financiamento.Service;

namespace ProjAndreVeiculosV3_Financiamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanciamentoesController : ControllerBase
    {
        private readonly ProjAndreVeiculosV3_FinanciamentoContext _context;
        private readonly FinanciamentoServico _service;

        public FinanciamentoesController(ProjAndreVeiculosV3_FinanciamentoContext context, FinanciamentoServico servico)
        {
            _context = context;
            _service = servico;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Financiamento>>> GetFinanciamento()
        {
            if (_context.Financiamento == null)
            {
                return NotFound();
            }
            return _service.GetFinanciamento();
        }

        // GET: api/Servicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Financiamento>> GetFinanciamento(int id)
        {
            if (_context.Financiamento == null)
            {
                return NotFound();
            }
            Financiamento financiamento = new Financiamento();
            financiamento = _service.GetFinanciamento(id);

            if (financiamento == null)
            {
                return NotFound();
            }

            return Ok(financiamento);
        }


        // POST: api/Servicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FinanciamentoDTO>> PostServico(FinanciamentoDTO financiamentoDTO)
        {
            if (_context.Financiamento == null)
            {
                return Problem("Entity set 'ProjAndreVeiculosV3_ServicoContext.Servico'  is null.");
            }
            Financiamento financiamento = new Financiamento(financiamentoDTO);
            financiamento.Banco = await _context.Banco.FindAsync(financiamentoDTO.Banco);
            financiamento.venda = await _context.Venda.FindAsync(financiamentoDTO.venda);

           

            _service.InserirFinanciamento(financiamento);

            return financiamentoDTO;
        }
    }
}
