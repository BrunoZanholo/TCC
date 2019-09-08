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
    public class AfetadosController : ControllerBase
    {
        private readonly CoreContext _context;

        public AfetadosController(CoreContext context)
        {
            _context = context;
        }

        // GET: api/Afetados/area/{id}
        [HttpGet("area/{id}")]
        public async Task<ActionResult<IEnumerable<Afetado>>> GetAfetadosArea(int id)
        {
            return await _context.Afetados.Where(s => s.AreaId == id).ToListAsync();
        }

        // GET: api/Afetados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Afetado>>> GetAfetados()
        {
            return await _context.Afetados.ToListAsync();
        }

        // GET: api/Afetados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Afetado>> GetAfetado(int id)
        {
            var afetado = await _context.Afetados.FindAsync(id);

            if (afetado == null)
            {
                return NotFound();
            }

            return afetado;
        }

        // PUT: api/Afetados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAfetado(int id, Afetado afetado)
        {
            if (id != afetado.AfetadoId)
            {
                return BadRequest();
            }

            _context.Entry(afetado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AfetadoExists(id))
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

        // POST: api/Afetados
        [HttpPost]
        public async Task<ActionResult<Afetado>> PostAfetado(Afetado afetado)
        {
            _context.Afetados.Add(afetado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAfetado", new { id = afetado.AfetadoId }, afetado);
        }

        // DELETE: api/Afetados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Afetado>> DeleteAfetado(int id)
        {
            var afetado = await _context.Afetados.FindAsync(id);
            if (afetado == null)
            {
                return NotFound();
            }

            _context.Afetados.Remove(afetado);
            await _context.SaveChangesAsync();

            return afetado;
        }

        private bool AfetadoExists(int id)
        {
            return _context.Afetados.Any(e => e.AfetadoId == id);
        }
    }
}
