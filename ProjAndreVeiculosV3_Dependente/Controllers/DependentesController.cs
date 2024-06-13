using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using ProjAndreVeiculosV3_Dependente.Data;
using ProjAndreVeiculosV3_Dependente.Service;

namespace ProjAndreVeiculosV3_Dependente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentesController : ControllerBase
    {
        private readonly ProjAndreVeiculosV3_DependenteContext _context;
        private readonly  DependenteService dependenteService;

        public DependentesController(ProjAndreVeiculosV3_DependenteContext context, DependenteService service)
        {
            _context = context;
            dependenteService = service;
        }

        // GET: api/Dependentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dependente>>> GetDependente()
        {
            var dependentesDTO = dependenteService.GetDependente();
            var dependentes = new List<Dependente>();

            foreach (var dependenteDTO in dependentesDTO)
            {
                var dependente = new Dependente(dependenteDTO);
                dependente.Cliente = await _context.Cliente.FindAsync(dependente.Cliente);
                dependente.Endereco = await _context.Endereco.FindAsync(dependente.Endereco);
                dependentes.Add(dependente);
            }

            return dependentes;
        }

        // GET: api/Dependentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dependente>> GetDependente(string id)
        {
            DependenteDTO dependenteDTO = dependenteService.GetDependente(id);

            Dependente dependente = new Dependente(dependenteDTO);
            dependente.Cliente = await _context.Cliente.FindAsync(dependente.Cliente);
            dependente.Endereco = await _context.Endereco.FindAsync(dependente.Endereco);

            return dependente;
        }

        // POST: api/Dependentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dependente>> PostDependente(Dependente dependente)
        {
          if (_context.Dependente == null)
          {
              return Problem("Entity set 'ProjAndreVeiculosV3_DependenteContext.Dependente'  is null.");
          }
            dependenteService.InserirDependente(dependente);

            return CreatedAtAction("GetDependente", new { id = dependente.Documento }, dependente);
        }

    }
}
