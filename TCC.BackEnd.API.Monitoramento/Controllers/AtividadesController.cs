using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC.BackEnd.API.Core.Data;
using TCC.BackEnd.API.Core.Models;

namespace TCC.BackEnd.API.Monitoramento.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadesController : ControllerBase
    {
        private readonly CoreContext _context;

        public AtividadesController(CoreContext context)
        {
            _context = context;
        }

        // GET: api/Atividades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atividade>>> GetAtividades()
        {
            return await _context.Atividades.ToListAsync();
        }

        // GET: api/Atividades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atividade>> GetAtividade(int id)
        {
            var atividade = await _context.Atividades.FindAsync(id);

            if (atividade == null)
            {
                return NotFound();
            }

            return atividade;
        }

        // PUT: api/Atividades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtividade(int id, Atividade atividade)
        {
            if (id != atividade.AtividadeId)
            {
                return BadRequest();
            }

            _context.Entry(atividade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtividadeExists(id))
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

        // POST: api/Atividades
        [HttpPost]
        public async Task<ActionResult<Atividade>> PostAtividade(Atividade atividade)
        {
            _context.Atividades.Add(atividade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtividade", new { id = atividade.AtividadeId }, atividade);
        }

        // DELETE: api/Atividades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Atividade>> DeleteAtividade(int id)
        {
            var atividade = await _context.Atividades.FindAsync(id);
            if (atividade == null)
            {
                return NotFound();
            }

            _context.Atividades.Remove(atividade);
            await _context.SaveChangesAsync();

            return atividade;
        }

        private bool AtividadeExists(int id)
        {
            return _context.Atividades.Any(e => e.AtividadeId == id);
        }
    }
}
