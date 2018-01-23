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
    public class BootsController : Controller
    {
        private IUnitOfWork unit = new UnitOfWork(new SkiHillDb());

        // GET: Boots by category
        public ActionResult Index(string categ = "Man")
        {
            ViewBag.Title = string.Join(" ", Regex.Split(categ, @"(?<!^)(?=[A-Z])")) + " Boots";
            if (unit.BootsRepo.Count() > 0)
            {
                return View(unit.BootsRepo.GetElements(x => x.Category.ToString().Equals(categ)));

            }
            return RedirectToAction("Create");

        }

        // GET: Boots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boot boot = unit.BootsRepo.GetElement(x => x.Id == id);
            if (boot == null)
            {
                return HttpNotFound();
            }
            return View(boot);
        }

        // GET: Boots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price,Model,Brand,Size,Category")] Boot boot)
        {
            if (ModelState.IsValid)
            {
                unit.BootsRepo.Add(boot);
                unit.Commit();
                return RedirectToAction("Index", "Boots", new {categ = boot.Category.ToString() });
            }

            return View(boot);
        }

        // GET: Boots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boot boot = unit.BootsRepo.GetElement(x => x.Id == id);
            if (boot == null)
            {
                return HttpNotFound();
            }
            return View(boot);
        }

        // POST: Boots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,Model,Brand,Size,Category")] Boot boot)
        {
            if (ModelState.IsValid)
            {
                unit.BootsRepo.Update(boot);
                unit.Commit();
                return RedirectToAction("Index", "Boots", new {categ = boot.Category.ToString() });
            }
            return View(boot);
        }

        // GET: Boots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boot boot = unit.BootsRepo.GetElement(x => x.Id == id);
            if (boot == null)
            {
                return HttpNotFound();
            }
            return View(boot);
        }

        // POST: Boots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Boot boot = unit.BootsRepo.GetElement(x => x.Id == id);
            string categ = boot.Category.ToString();
            unit.BootsRepo.Delete(boot);
            unit.Commit();
            return RedirectToAction("Index", "Boots", new {categ = categ });
        }

        //View all boot categories to filter data by category
        public ActionResult BootsCategories()
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
