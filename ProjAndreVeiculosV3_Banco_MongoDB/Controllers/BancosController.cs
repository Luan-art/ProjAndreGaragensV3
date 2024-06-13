using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ProjAndreVeiculosV3_Banco.Service;
using ProjAndreVeiculosV3_Banco_MongoDB.Data;
using ProjAndreVeiculosV3_Banco_MongoDB.Utils;

namespace ProjAndreVeiculosV3_Banco_MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancosController : ControllerBase
    {
        private readonly ProjAndreVeiculosV3_Banco_MongoDBContext _context;
        private readonly BancoMongoService _service;
        public BancosController(ProjAndreVeiculosV3_Banco_MongoDBContext context, BancoMongoService service)
        {
            _context = context;
            _service = service;
        }

        // POST: api/Bancos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Banco>> PostBanco(Banco banco)
        {
            try
            {
                await _service.CreateAsync(banco);
                return CreatedAtAction(nameof(PostBanco), new { id = banco.CNPJ }, banco);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
    }
}