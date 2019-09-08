using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TCC.FrontEnd.Controllers
{
    public class IncidentesController : Controller
    {
        // GET: Incidentes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Incidentes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Incidentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Incidentes/Create
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

        // GET: Incidentes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Incidentes/Edit/5
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

        // GET: Incidentes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Incidentes/Delete/5
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