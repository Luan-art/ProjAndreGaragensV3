using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using ProjAndreVeiculosV3_TermoUso.Service;
using System.Net;

namespace ProjAndreVeiculosV3_TermoUso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermoDeUsosController : ControllerBase
    {
        private readonly TermoUsoService _termoService;

        public TermoDeUsosController(TermoUsoService bancoService)
        {
            _termoService = bancoService;
        }

        [HttpGet]
        public ActionResult<List<TermoDeUso>> Get()
        {
            return _termoService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetTermoUso")]
        public ActionResult<TermoDeUso> Get(string id) => _termoService.Get(id);

        [HttpPost]
        public async Task<ActionResult<TermoDeUso>> Create([FromBody] TermoDeUso termoUso)
        {
            _termoService.Create(termoUso);
            return CreatedAtRoute("GetAddess", new { id = termoUso.Id }, termoUso);
        }
    }
}
