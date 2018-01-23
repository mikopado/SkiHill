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
    public class BindingsController : Controller
    {
        private IUnitOfWork unit = new UnitOfWork(new SkiHillDb());

        // GET: Bindings by category
        public ActionResult Index(string categ = "Alpine")
        {

            ViewBag.Title = string.Join(" ", Regex.Split(categ, @"(?<!^)(?=[A-Z])")) + " Bindings";
            if (unit.BindingsRepo.Count() > 0)
            {
                return View(unit.BindingsRepo.GetElements(x => x.Category.ToString().Equals(categ)));

            }
            return RedirectToAction("Create");
        }

        // GET: Bindings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Binding binding = unit.BindingsRepo.GetElement(x => x.Id == id);
            if (binding == null)
            {
                return HttpNotFound();
            }
            return View(binding);
        }

        // GET: Bindings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bindings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price,Category,Model,Brand,Size")] Binding binding)
        {
            if (ModelState.IsValid)
            {
                unit.BindingsRepo.Add(binding);
                unit.Commit();
                return RedirectToAction("Index", "Bindings", new {categ = binding.Category.ToString() });
            }

            return View(binding);
        }

        // GET: Bindings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Binding binding = unit.BindingsRepo.GetElement(x => x.Id == id);
            if (binding == null)
            {
                return HttpNotFound();
            }
            return View(binding);
        }

        // POST: Bindings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,Category,Model,Brand,Size")] Binding binding)
        {
            if (ModelState.IsValid)
            {
                unit.BindingsRepo.Update(binding);
                unit.Commit();
                return RedirectToAction("Index", "Bindings", new {categ = binding.Category.ToString() });
            }
            return View(binding);
        }

        // GET: Bindings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Binding binding = unit.BindingsRepo.GetElement(x => x.Id == id);
            if (binding == null)
            {
                return HttpNotFound();
            }
            return View(binding);
        }

        // POST: Bindings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Binding binding = unit.BindingsRepo.GetElement(x => x.Id == id);
            string categ = binding.Category.ToString();
            unit.BindingsRepo.Delete(binding);
            unit.Commit();
            return RedirectToAction("Index", "Bindings", new {categ = categ });
        }

        //View all binding categories to filter data by category
        public ActionResult BindingsCategories()
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
