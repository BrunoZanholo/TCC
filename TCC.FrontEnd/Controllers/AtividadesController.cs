using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TCC.FrontEnd.Controllers
{
    public class AtividadesController : Controller
    {
        // GET: Atividades
        public ActionResult Index()
        {
            return View();
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