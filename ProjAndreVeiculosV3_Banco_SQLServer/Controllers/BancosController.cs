using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ProjAndreVeiculosV3_Banco_SQLServer.Data;

namespace ProjAndreVeiculosV3_Banco_SQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancosController : ControllerBase
    {
        private readonly ProjAndreVeiculosV3_Banco_SQLServerContext _context;

        public BancosController(ProjAndreVeiculosV3_Banco_SQLServerContext context)
        {
            _context = context;
        }

        // POST: api/Bancos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Banco>> PostBanco(Banco banco)
        {
            if (_context.Banco == null)
            {
                return Problem("Entity set 'ProjRabbitMQSendMessageContext.Message'  is null.");
            }
            _context.Banco.Add(banco);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
