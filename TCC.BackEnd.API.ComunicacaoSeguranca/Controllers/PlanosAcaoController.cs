using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;
using TCC.BackEnd.API.Core.Data;
using TCC.BackEnd.API.Core.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace TCC.BackEnd.API.ComunicacaoSeguranca.Controllers
{
    //[Authorize]
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

        [HttpPost("incidente/{id}")]
        public async Task<ActionResult> PostTratarIncidente(int id)
        {
            var incidente = await _context.Incidentes.FindAsync(id);

            if (incidente.Classificacao > 0)
            {
                var planoAcao = await _context.PlanosAcao.FirstOrDefaultAsync(pa => pa.Classificacao == incidente.Classificacao);

                incidente.PlanoAcaoId = planoAcao.PlanoAcaoId;

                await _context.SaveChangesAsync();

                var area = await _context.Areas.FindAsync(incidente.AreaId);

                if (planoAcao != null)
                {
                    var afetados = _context.Afetados.Where(af => af.AreaId == incidente.AreaId).ToList();

                    Parallel.For(0, afetados.Count, index =>
                    {
                        var afetado = afetados[index];

                        switch (planoAcao.Tipo.ToUpper())
                        {
                            case "EMAIL":
                                {
                                    var client = new SendGridClient("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");
                                    var msg = new SendGridMessage()
                                    {
                                        From = new EmailAddress("tcc@puc.com.br", "TCC PUC"),
                                        Subject = afetado.Nome,
                                        PlainTextContent = "Área de risco: " + area.Nome + ". " + planoAcao.Mensagem,
                                        HtmlContent = "<strong>" + "Área de risco: " + area.Nome + ". " + planoAcao.Mensagem + "</strong>"
                                    };
                                    msg.AddTo(new EmailAddress(afetado.Email, afetado.Nome));
                                    client.SendEmailAsync(msg).Wait();

                                    break;
                                }
                            case "SMS":
                                {
                                    const string accountSid = "ACa9213b350d6d061b6ae76875fa4bf822";
                                    const string authToken = "cb67dda7832a522e1edca99b051a65f9";

                                    try
                                    {
                                        TwilioClient.Init(accountSid, authToken);

                                        var message = MessageResource.Create(
                                            body: "Área de risco: " + area.Nome + ". " + planoAcao.Mensagem,
                                            from: new Twilio.Types.PhoneNumber("+16575004717"),
                                            to: new Twilio.Types.PhoneNumber("+55" + afetado.Celular)
                                        );
                                    }
                                    catch { }

                                    break;
                                }
                        }
                    });
                }
            }

            return Ok();
        }

        private bool PlanoAcaoExists(int id)
        {
            return _context.PlanosAcao.Any(e => e.PlanoAcaoId == id);
        }
    }
}
