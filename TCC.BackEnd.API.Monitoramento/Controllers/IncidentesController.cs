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
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public IncidentesController(CoreContext context, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        // GET: api/Incidentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incidente>>> GetIncidente()
        {
            var incidentes = await _context.Incidentes.ToListAsync();

            incidentes.ForEach(a =>
            {
                a.Area = _context.Areas.FirstOrDefault(s => s.AreaId == a.AreaId);
                a.PlanoAcao = _context.PlanosAcao.FirstOrDefault(s => s.PlanoAcaoId == a.PlanoAcaoId);
            });

            return incidentes;
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

                    var url = this._configuration.GetValue<string>("tcc-api:comunicacao");

                    var content = await client.PostAsync(new Uri(url + "/api/PlanosAcao/incidente/" + incidente.IncidenteId), null);
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
