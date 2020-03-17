using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperheroWebpage.Data;
using SuperheroWebpage.Models;

namespace SuperheroWebpage.Controllers
{
    public class SuperheroController : Controller
    {
        private ApplicationDbContext db;
        public SuperheroController(ApplicationDbContext context)
        {
            db = context;
        }
        // GET: Superhero
        public ActionResult Index()
        {
            var superheroes = db.Superheroes;
            return View(superheroes);
        }

        // GET: Superhero/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

        // POST: Superhero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                // TODO: Add insert logic here
                db.Add(superhero);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int id)
        {
            Superhero superhero = db.Superheroes.Where(a => a.Id == id).FirstOrDefault();
            return View(superhero);
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                // TODO: Add update logic here
                Superhero heroToUpdate = db.Superheroes.Where(a => a.Id == id).FirstOrDefault();
                heroToUpdate.Name = superhero.Name;
                heroToUpdate.AlterEgo = superhero.AlterEgo;
                heroToUpdate.PrimaryAbility = superhero.PrimaryAbility;
                heroToUpdate.SecondaryAbility = superhero.SecondaryAbility;
                heroToUpdate.Catchphrase = superhero.Catchphrase;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Delete/5
        public ActionResult Delete(int id)
        {
            Superhero superhero = db.Superheroes.Where(a => a.Id == id).FirstOrDefault();
            return View(superhero);
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                // TODO: Add delete logic here
                Superhero heroToUpdate
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}