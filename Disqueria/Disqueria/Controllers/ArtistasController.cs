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
    public class ArtistasController : Controller
    {
        protected readonly IGenericRepository<Artista> repo;

        public ArtistasController(IGenericRepository<Artista> _repo)
        {
            this.repo = _repo;
        }
        // GET: Artistas
        public IActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: Artistas/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetID(id));
        }

        // GET: Artistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artistas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Artista model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Add(model);
                    repo.Save();
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Artistas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Artistas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Artista model)
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

        // GET: Artistas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Artistas/Delete/5
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