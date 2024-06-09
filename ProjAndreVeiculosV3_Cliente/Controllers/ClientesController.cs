using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using ProjAndreVeiculosV3_Cliente.Data;

namespace ProjAndreVeiculosV3_Cliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ProjAndreVeiculosV3_ClienteContext _context;
        private readonly HttpClient _httpClient;

        public ClientesController(ProjAndreVeiculosV3_ClienteContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;

        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetCliente()
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.ToListAsync();
            foreach (Clientes cliente in clientes)
            {
                Endereco endereco = await _context.Endereco.Where(e => cliente.Endereco.Id == e.Id).FirstAsync();
                cliente.Endereco = endereco;
            }
            return clientes;
        }


        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetCliente(string id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(string id, Clientes cliente)
        {
            if (id != cliente.Documento)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // POST: api/Clientes/{cep}
        [HttpPost("{cep}")]
        public async Task<ActionResult<Clientes>> PostCliente(string cep, ClienteDTO clienteDTO)
        {
            var enderecoId = await CriarEnderecoRemotamente(cep);

            if (enderecoId != null)
            {
                Clientes cliente = new Clientes(clienteDTO);
                cliente.Endereco = await _context.Endereco.FindAsync(enderecoId);

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCliente", new { id = cliente.Documento }, cliente);
            }
            else
            {
                return BadRequest("Erro ao criar endereço pelo CEP.");
            }
        }

        private async Task<int?> CriarEnderecoRemotamente(string cep)
        {
            using (var httpClient = new HttpClient())
            {
                string url = $"https://localhost:7261/api/Enderecos/{cep}";

                var response = await httpClient.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    var enderecoId = await response.Content.ReadAsStringAsync();
                    return int.Parse(enderecoId);
                }
                else
                {
                    return null;
                }
            }
        }


        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(string id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(string id)
        {
            return (_context.Clientes?.Any(e => e.Documento == id)).GetValueOrDefault();
        }
    }
}
