﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using ProjAndreVeiculosV3_Funcionario.Data;

namespace ProjAndreVeiculosV3_Funcionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly ProjAndreVeiculosV3_FuncionarioContext _context;

        public FuncionariosController(ProjAndreVeiculosV3_FuncionarioContext context)
        {
            _context = context;
        }

        // GET: api/Funcionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionario()
        {
          if (_context.Funcionario == null)
          {
              return NotFound();
          }
            var funcionarios = await _context.Funcionario.ToListAsync();

  

            return funcionarios;
        }

        // GET: api/Funcionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> GetFuncionario(string id)
        {
          if (_context.Funcionario == null)
          {
              return NotFound();
          }
            var funcionario = await _context.Funcionario
                  .Include(p => p.Cargo)
                  .Include(p => p.Endereco)
                  .FirstOrDefaultAsync(p => p.Documento == id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return funcionario;
        }

        // PUT: api/Funcionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionario(string id, Funcionario funcionario)
        {
            if (id != funcionario.Documento)
            {
                return BadRequest();
            }

            _context.Entry(funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
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

        // POST: api/Funcionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Funcionario>> PostFuncionario(FuncionarioDTO funcionarioDTO)
        {
          if (_context.Funcionario == null)
          {
              return Problem("Entity set 'ProjAndreVeiculosV3_FuncionarioContext.Funcionario'  is null.");
          }

            Funcionario funcionario = new Funcionario(funcionarioDTO);
            funcionario.Cargo = await _context.Cargo.FindAsync(funcionario.Cargo.Id);
            funcionario.Endereco = await _context.Endereco.FindAsync(funcionario.Endereco.Id);


            _context.Funcionario.Add(funcionario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FuncionarioExists(funcionario.Documento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFuncionario", new { id = funcionario.Documento }, funcionario);
        }

        [HttpPost("{cep}")]
        public async Task<ActionResult<Funcionario>> PostCliente(string cep, FuncionarioDTO funcionarioDTO)
        {
            var enderecoId = await CriarEnderecoRemotamente(cep);

            if (enderecoId != null)
            {
                Funcionario funcionario = new Funcionario(funcionarioDTO);
                funcionario.Endereco = await _context.Endereco.FindAsync(enderecoId);
                funcionario.Cargo = await _context.Cargo.FindAsync(funcionario.Cargo.Id);

                _context.Funcionario.Add(funcionario);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFuncionario", new { id = funcionario.Documento }, funcionario);
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

        // DELETE: api/Funcionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario(string id)
        {
            if (_context.Funcionario == null)
            {
                return NotFound();
            }
            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuncionarioExists(string id)
        {
            return (_context.Funcionario?.Any(e => e.Documento == id)).GetValueOrDefault();
        }
    }
}
