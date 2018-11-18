using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disqueria.DAL;
using Disqueria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Disqueria.Controllers
{
    public class DiscosController : Controller
    {
        protected readonly IGenericRepository<Disco> repo;
        public DiscosController(IGenericRepository<Disco> _repo)
        {
            this.repo = _repo;

        }
        // GET: Canciones
        public ActionResult Index()
        {
            return View();
        }

        // GET: Canciones/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Canciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Canciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Disco model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                repo.Add(model);
                repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Canciones/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Canciones/Edit/5
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

        // GET: Canciones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Canciones/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                repo.Del(id);
                repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}