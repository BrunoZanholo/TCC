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
    public class AreasController : Controller
    {
        private readonly IConfiguration configuration;

        public AreasController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: Areas
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage response = await ApiGet("api/areas");

            response.EnsureSuccessStatusCode();

            var areas = await response.Content.ReadAsAsync<List<Area>>();

            return View(areas);
        }

        private async Task<HttpResponseMessage> ApiGet(string rota)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var url = this.configuration.GetValue<string>("tcc-api:monitoramento");

            //var response = await client.GetAsync("http://localhost:3005/" + rota);

            var response = await client.GetAsync(url + "/" + rota);

            return response;
        }

        // GET: Areas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage response = await ApiGet("api/areas/" + id.ToString());

            var area = await response.Content.ReadAsAsync<Area>();

            response = await ApiGet("api/afetados/area/" + id.ToString());

            var afetados = await response.Content.ReadAsAsync<List<Afetado>>();

            area.Afetados = afetados;

            response = await ApiGet("api/sensores/area/" + id.ToString());

            var sensores = await response.Content.ReadAsAsync<List<Sensor>>();

            area.Sensores = sensores;

            return View(area);
        }

        // GET: Areas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Areas/Create
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

        // GET: Areas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Areas/Edit/5
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

        // GET: Areas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Areas/Delete/5
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