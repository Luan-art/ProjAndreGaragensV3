using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using ProjAndreVeiculosV3_Seguro.Data;
using ProjAndreVeiculosV3_Seguro.Service;

namespace ProjAndreVeiculosV3_Seguro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurosController : ControllerBase
    {
        private readonly ProjAndreVeiculosV3_SeguroContext _context;
        private readonly SeguroService _service;

        public SegurosController(ProjAndreVeiculosV3_SeguroContext context, SeguroService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seguro>>> GetSeguro()
        {
            if (_context.Seguro == null)
            {
                return NotFound();
            }
            return _service.GetSeguro();
        }

        // GET: api/Servicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servico>> GetServico(int id)
        {
            if (_context.Seguro == null)
            {
                return NotFound();
            }
            Seguro seguro = new Seguro();
            seguro = _service.GetSeguro(id);

            if (seguro == null)
            {
                return NotFound();
            }

            return Ok(seguro);
        }


        // POST: api/Servicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeguroDTO>> PostServico(SeguroDTO seguroDTO)
        {
            if (_context.Seguro == null)
            {
                return Problem("Entity set 'ProjAndreVeiculosV3_ServicoContext.Servico'  is null.");
            }
            Seguro seguro = new Seguro(seguroDTO);
            seguro.Carro = await _context.Carro.FindAsync(seguroDTO.Carro);
            seguro.Cliente = await _context.Cliente.FindAsync(seguroDTO.Cliente);
            seguro.CondutorPrincipal = await _context.Condutor.FindAsync(seguroDTO.CondutorPrincipal);

            _service.InserirSeguro(seguro);

            return seguroDTO;
        }

    }
}