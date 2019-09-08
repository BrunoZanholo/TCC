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
using Microsoft.Extensions.Configuration;
using TCC.FrontEnd.Models;

namespace TCC.FrontEnd.Controllers
{
    [Authorize]
    public class AtividadesController : Controller
    {
        private readonly IConfiguration configuration;

        public AtividadesController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: Atividades
        public async Task<ActionResult> Index()
        {
            try
            {
                HttpResponseMessage response = await ApiGet("api/atividades");

                var atividades = await response.Content.ReadAsAsync<List<Atividade>>();

                return View(atividades);
            }
            catch (Exception ex)
            {
                var str = ex.GetBaseException().Message;
            }

            return View();
        }

        private async Task<HttpResponseMessage> ApiGet(string rota)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var url = this.configuration.GetValue<string>("tcc-api:monitoramento");

            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync(url + "/" + rota);

            return response;
        }

        // GET: Atividades/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Atividades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Atividades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Atividades/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Atividades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Atividades/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Atividades/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}