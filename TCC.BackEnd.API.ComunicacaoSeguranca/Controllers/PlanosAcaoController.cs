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

namespace TCC.BackEnd.API.ComunicacaoSeguranca.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlanosAcaoController : ControllerBase
    {
        private readonly CoreContext _context;

        public PlanosAcaoController(CoreContext context)
        {
            _context = context;
        }

        // GET: api/PlanosAcao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanoAcao>>> GetPlanosAcao()
        {
            return await _context.PlanosAcao.ToListAsync();
        }

        // GET: api/PlanosAcao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanoAcao>> GetPlanoAcao(int id)
        {
            var planoAcao = await _context.PlanosAcao.FindAsync(id);

            if (planoAcao == null)
            {
                return NotFound();
            }

            return planoAcao;
        }

        // PUT: api/PlanosAcao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanoAcao(int id, PlanoAcao planoAcao)
        {
            if (id != planoAcao.PlanoAcaoId)
            {
                return BadRequest();
            }

            _context.Entry(planoAcao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanoAcaoExists(id))
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

        // POST: api/PlanosAcao
        [HttpPost]
        public async Task<ActionResult<PlanoAcao>> PostPlanoAcao(PlanoAcao planoAcao)
        {
            _context.PlanosAcao.Add(planoAcao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanoAcao", new { id = planoAcao.PlanoAcaoId }, planoAcao);
        }

        // DELETE: api/PlanosAcao/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlanoAcao>> DeletePlanoAcao(int id)
        {
            var planoAcao = await _context.PlanosAcao.FindAsync(id);
            if (planoAcao == null)
            {
                return NotFound();
            }

            _context.PlanosAcao.Remove(planoAcao);
            await _context.SaveChangesAsync();

            return planoAcao;
        }

        private bool PlanoAcaoExists(int id)
        {
            return _context.PlanosAcao.Any(e => e.PlanoAcaoId == id);
        }
    }
}
