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
    public class HelmetsController : Controller
    {
        private IUnitOfWork unit = new UnitOfWork(new SkiHillDb());

        // GET: Helmets by category
        public ActionResult Index(string categ = "Covers")
        {

            ViewBag.Title = string.Join(" ", Regex.Split(categ, @"(?<!^)(?=[A-Z])")) + " Helmets";
            if (unit.HelmetsRepo.Count() > 0)
            {
                return View(unit.HelmetsRepo.GetElements(x => x.Category.ToString().Equals(categ)));

            }
            return RedirectToAction("Create");
        }

        // GET: Helmets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Helmet helmet = unit.HelmetsRepo.GetElement(x => x.Id == id);
            if (helmet == null)
            {
                return HttpNotFound();
            }
            return View(helmet);
        }

        // GET: Helmets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Helmets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price,Size,Model,Brand,Category")] Helmet helmet)
        {
            if (ModelState.IsValid)
            {
                unit.HelmetsRepo.Add(helmet);
                unit.Commit();
                return RedirectToAction("Index", "Helmets", new {categ = helmet.Category.ToString() });
            }

            return View(helmet);
        }

        // GET: Helmets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Helmet helmet = unit.HelmetsRepo.GetElement(x => x.Id == id);
            if (helmet == null)
            {
                return HttpNotFound();
            }
            return View(helmet);
        }

        // POST: Helmets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,Size,Model,Brand,Category")] Helmet helmet)
        {
            if (ModelState.IsValid)
            {
                unit.HelmetsRepo.Update(helmet);
                unit.Commit();
                return RedirectToAction("Index", "Helmets", new { categ = helmet.Category.ToString() });
            }
            return View(helmet);
        }

        // GET: Helmets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Helmet helmet = unit.HelmetsRepo.GetElement(X => X.Id == id);
            if (helmet == null)
            {
                return HttpNotFound();
            }
            return View(helmet);
        }

        // POST: Helmets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Helmet helmet = unit.HelmetsRepo.GetElement(X => X.Id == id);
            string categ = helmet.Category.ToString();
            unit.HelmetsRepo.Delete(helmet);
            unit.Commit();
            return RedirectToAction("Index", "Helmets", new { categ = categ });
        }

        //View all helmet categories to filter data by category
        public ActionResult HelmetsCategories()
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
