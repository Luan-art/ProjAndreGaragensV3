using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using ProjAndreVeiculosV3_Banco.Service;
using System.Net;

namespace ProjAndreVeiculosV3_Banco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancosController : ControllerBase
    {
        private readonly BancoService bancoService;

        public BancosController(BancoService bancoService)
        {
            this.bancoService = bancoService;
        }

        [HttpGet]
        public ActionResult<List<Banco>> Get()
        {
            return bancoService.Get();
        }

        [HttpGet("{id:length(14)}", Name = "GetBanco")]
        public ActionResult<Banco> Get(string id) => bancoService.Get(id);

        [HttpPost]
        public ActionResult<Banco> Create(Banco banco)
        {
            bancoService.Create(banco);
            return CreatedAtRoute("GetBanco", new { id = banco.CNPJ }, banco);
        }
    }
}
