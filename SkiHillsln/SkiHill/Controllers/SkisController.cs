using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Models;
using System.Text.RegularExpressions;

namespace SkiHill.Controllers
{
    public class SkisController : Controller
    {
        private IUnitOfWork unit = new UnitOfWork(new SkiHillDb());

        // GET: Skis by category
        public ActionResult Index(string categ = "AllMountain")
        {
            ViewBag.Title = string.Join(" ", Regex.Split(categ, @"(?<!^)(?=[A-Z])")) + " Ski";
            if (unit.SkiRepo.Count() > 0)
            {
                return View(unit.SkiRepo.GetElements(x => x.Category.ToString().Equals(categ)));

            }
            return RedirectToAction("Create");
        }

        // GET: Skis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ski ski = unit.SkiRepo.GetElement(x => x.Id == id);
            if (ski == null)
            {
                return HttpNotFound();
            }
            return View(ski);
        }

        // GET: Skis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price,Model,Brand,Length,Category")] Ski ski)
        {
            if (ModelState.IsValid)
            {
                unit.SkiRepo.Add(ski);
                unit.Commit();
                return RedirectToAction("Index", "Skis", new {categ = ski.Category.ToString() });
            }

            return View(ski);
        }

        // GET: Skis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ski ski = unit.SkiRepo.GetElement(x => x.Id == id);
            if (ski == null)
            {
                return HttpNotFound();
            }
            return View(ski);
        }

        // POST: Skis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,Model,Brand,Length,Category")] Ski ski)
        {
            if (ModelState.IsValid)
            {
                unit.SkiRepo.Update(ski);
                unit.Commit();
                return RedirectToAction("Index", "Skis", new { categ = ski.Category.ToString() });
            }
            return View(ski);
        }

        // GET: Skis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ski ski = unit.SkiRepo.GetElement(x => x.Id == id);
            if (ski == null)
            {
                return HttpNotFound();
            }
            return View(ski);
        }

        // POST: Skis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ski ski = unit.SkiRepo.GetElement(x => x.Id == id);
            string categ = ski.Category.ToString();
            unit.SkiRepo.Delete(ski);
            unit.Commit();
            return RedirectToAction("Index", "Skis", new {categ = categ });
        }

        //View all ski categories to filter data by category
        public ActionResult SkiCategories()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
