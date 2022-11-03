using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteDev.Data;
using TesteDev.Models;
using TesteDevBackend.Models;
using X.PagedList;

namespace TesteDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly TesteDevContext _context;

        public ClientesController(TesteDevContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente(string? cpf, string? nome, DateTime? dataNascimento, int? sexo, string? endereco, string? estado, string? cidade, int? page)
        {
            IEnumerable<Cliente> clientes = await _context.Cliente.ToListAsync();

            if (!String.IsNullOrEmpty(nome))
            {
                clientes = clientes.Where(c => !String.IsNullOrEmpty(c.Nome)
                                        && RemoveDiacritics(c.Nome).ContainsCaseInsensitive(RemoveDiacritics(nome)));
            }
            if (!String.IsNullOrEmpty(cpf))
            {
                clientes = clientes.Where(c => !String.IsNullOrEmpty(c.CPF)
                                        && RemoveDiacritics(c.CPF).ContainsCaseInsensitive(RemoveDiacritics(cpf)));
            }
            if (dataNascimento.HasValue)
            {
                clientes = clientes.Where(c => c.DataNascimento == dataNascimento.Value.Date);
            }
            if (sexo.HasValue)
            {
                clientes = clientes.Where(c => c.sexo == sexo);
            }
            if (!String.IsNullOrEmpty(endereco))
            {
                clientes = clientes.Where(c => !String.IsNullOrEmpty(c.Endereco)
                                        && RemoveDiacritics(c.Endereco).ContainsCaseInsensitive(RemoveDiacritics(endereco)));
            }
            if (!String.IsNullOrEmpty(estado))
            {
                clientes = clientes.Where(c => !String.IsNullOrEmpty(c.Estado) 
                                        && RemoveDiacritics(c.Estado).ContainsCaseInsensitive(RemoveDiacritics(estado)));
            }
            if (!String.IsNullOrEmpty(cidade))
            {
                clientes = clientes.Where(c => !String.IsNullOrEmpty(c.Cidade)
                                        && RemoveDiacritics(c.Cidade).ContainsCaseInsensitive(RemoveDiacritics(cidade)));
            }

            var pageNumber = page ?? 1;
            var onePageOfClients = clientes.ToPagedList(pageNumber, 5);

            return Ok(clientes);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            cliente.DataInserido = DateTime.Now;
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.DataExcluido = DateTime.Now;

            _context.Cliente.Update(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }

        private static string RemoveDiacritics(string text)
        {
            string formD = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char ch in formD)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
