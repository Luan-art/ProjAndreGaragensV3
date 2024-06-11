using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ProjAndreVeiculosV3_Endereco.Data;
using ProjAndreVeiculosV3_Endereco.Service;

namespace ProjAndreVeiculosV3_Endereco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly ProjAndreVeiculosV3_EnderecoContext _context;
        private readonly HttpClient _httpClient;
        private readonly EnderecoService enderecoService;


        public EnderecosController(ProjAndreVeiculosV3_EnderecoContext context, HttpClient httpClient, EnderecoService enderecoService)
        {
            _context = context;
            _httpClient = httpClient;
            this.enderecoService = enderecoService;
        }

        // GET: api/Enderecos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetEndereco()
        {
          if (_context.Endereco == null)
          {
              return NotFound();
          }
            return await _context.Endereco.ToListAsync();
        }

        // GET: api/Enderecos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetEndereco(int id)
        {
          if (_context.Endereco == null)
          {
              return NotFound();
          }
            var endereco = await _context.Endereco.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return endereco;
        }

        [HttpGet("cep/{cep}")]
        public async Task<ActionResult<Endereco>> GetEnderecoByCep(string cep)
        {
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var enderecoViaCep = JsonSerializer.Deserialize<Endereco>(jsonResponse, options);

                if (enderecoViaCep == null || string.IsNullOrWhiteSpace(enderecoViaCep.CEP))
                {
                    return NotFound("Endereço não encontrado para o CEP fornecido.");
                }

                return enderecoViaCep;
            }
            else
            {
                return BadRequest("Erro ao buscar endereço pelo CEP.");
            }
        }

        // PUT: api/Enderecos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEndereco(int id, Endereco endereco)
        {
            if (id != endereco.Id)
            {
                return BadRequest();
            }

            _context.Entry(endereco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(id))
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

        // POST: api/Enderecos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
        {
          if (_context.Endereco == null)
          {
              return Problem("Entity set 'ProjAndreVeiculosV3_EnderecoContext.Endereco'  is null.");
          }
            _context.Endereco.Add(endereco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEndereco", new { id = endereco.Id }, endereco);
        }

        [HttpPost("{cep}")]
        public async Task<ActionResult<int>> PostEndereco(string cep)
        {
            
            if(enderecoService.Get().Count == 0)
            {
                PopularMongo();
            }

            string url = $"https://viacep.com.br/ws/{cep}/json/";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var enderecoViaCep = JsonSerializer.Deserialize<Endereco>(jsonResponse);

                if (enderecoViaCep == null || string.IsNullOrWhiteSpace(enderecoViaCep.CEP))
                {
                    return BadRequest("Endereço não encontrado para o CEP fornecido.");
                }

                var endereco = new Endereco(_httpClient, url);
                    
                _context.Endereco.Add(endereco);
                await _context.SaveChangesAsync();

                enderecoService.Create(endereco);

                return endereco.Id;
            }
            else
            {
                return BadRequest("Erro ao buscar endereço pelo CEP.");
            }
        }

        private void PopularMongo()
        {
            var enderecosSql = _context.Endereco.ToList();
            if (enderecosSql.Count() > 0)
            {
                enderecoService.GetMany(enderecosSql);
            }
        }


        // DELETE: api/Enderecos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEndereco(int id)
        {
            if (_context.Endereco == null)
            {
                return NotFound();
            }
            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            _context.Endereco.Remove(endereco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnderecoExists(int id)
        {
            return (_context.Endereco?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
