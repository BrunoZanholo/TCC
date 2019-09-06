using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
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
    public class IncidentesController : ControllerBase
    {
        private readonly CoreContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IncidentesController(CoreContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/Incidentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incidente>>> GetIncidente()
        {
            return await _context.Incidentes.ToListAsync();
        }

        // GET: api/Incidentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Incidente>> GetIncidente(int id)
        {
            var incidente = await _context.Incidentes.FindAsync(id);

            if (incidente == null)
            {
                return NotFound();
            }

            return incidente;
        }

        // PUT: api/Incidentes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidente(int id, Incidente incidente)
        {
            if (id != incidente.IncidenteId)
            {
                return BadRequest();
            }

            _context.Entry(incidente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidenteExists(id))
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

        // POST: api/Incidentes
        [HttpPost]
        public async Task<ActionResult<Incidente>> PostIncidente(Incidente incidente)
        {
            _context.Incidentes.Add(incidente);
            await _context.SaveChangesAsync();

            if (incidente.Classificacao > 10)
            {
                var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                try
                {
                    var client = new HttpClient();

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    var content = await client.PostAsync(new Uri("http://localhost:3003/api/PlanosAcao/incidente/" + incidente.IncidenteId), null);
                }
                catch (Exception ex)
                {
                    var str = ex.GetBaseException().Message;
                }
            }

            return CreatedAtAction("GetIncidente", new { id = incidente.IncidenteId }, incidente);
        }

        // DELETE: api/Incidentes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Incidente>> DeleteIncidente(int id)
        {
            var incidente = await _context.Incidentes.FindAsync(id);
            if (incidente == null)
            {
                return NotFound();
            }

            _context.Incidentes.Remove(incidente);
            await _context.SaveChangesAsync();

            return incidente;
        }

        private bool IncidenteExists(int id)
        {
            return _context.Incidentes.Any(e => e.IncidenteId == id);
        }
    }
}


/*
 * 
 * 
 * Cadastro de sensores (id, area, tipo, rotulo) -> modulo de monitoramento
Cadastro de areas (id, nome) -> modulo de monitoramento
Cadastro de incidentes (id, area, classificacao, plano) -> modulo de monitoramento
Cadastro de afetados (id, area, nome, email) -> modulo de monitoramento


Atividade (rotuloSensor, tipo, intensidade) -> modulo de monitoramento
-> recupera o sensor
-> recupera a area
-> if ((tipo atividade == tremor))
{
	if (intensidade > 10)
{
	gera ->	novo incidente (area do sensor, classificacao = 10)
}
}
if (tipo atividade == ruido)
{
}

Novo incidente -> modulo de monitoramento
-> notifica modulo de seguranca para executar ou nao plano de acao


Cadastro de planos de acao (id, nome, tipo, classificacao) -> modulo de seguranca


*/
