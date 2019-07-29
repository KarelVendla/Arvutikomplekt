using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Helpers;
using System.Web.Mvc;
using ArvutikomplektUL.Models;

namespace ArvutikomplektUL.Controllers
{
    public class ArvutikomplektsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Arvutikomplekts
        public ActionResult Index()
        {
            return View(db.Arvutikomplekts.ToList());
        }
        public ActionResult Assembly()
        {
            var model = db.Arvutikomplekts.Where(m => m.Korpus == 0 || m.Kuvar == 0).ToList();
            return View(model);
        }
       
        


        public ActionResult Assemble(int assemble,int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Arvutikomplekt arvutikomplekt = db.Arvutikomplekts.Find(id);
            if(arvutikomplekt == null)
            {
                return HttpNotFound();
            }
            if(ModelState.IsValid)
            {
                if (assemble == 1)
                {
                    arvutikomplekt.Korpus = 1;
                } else if (assemble == 2)
                {
                    arvutikomplekt.Kuvar = 1;
                }
                db.Entry(arvutikomplekt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Assembly");
            }
            return RedirectToAction("Assembly");
        }

        public ActionResult Statistics()
        {
            var model = db.Arvutikomplekts.Where(m => m.Pakitud == 1).ToList();
            return View(model);
        }

        public ActionResult MyChart()
        {
            var model = db.Arvutikomplekts.Count();
            var lopetatud = db.Arvutikomplekts.Where(m => m.Pakitud == 1).Count();

            new Chart(width: 600, height: 300)
                .AddSeries(
                chartType: "doughnut",
                xValue: new[] { "Tellimuste arv","Lõpetatud" },
                yValues: new[] { model, lopetatud })
                .Write("png");
            return null;
        } 

        public ActionResult Packing()
        {
            var model = db.Arvutikomplekts.Where(m => m.Korpus == 1 && m.Kuvar == 1 && m.Pakitud == 0).ToList();
            return View(model);
        }

        public ActionResult Packed(int packed, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Arvutikomplekt arvutikomplekt = db.Arvutikomplekts.Find(id);
            if (arvutikomplekt == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                if (packed == 1)
                {
                    arvutikomplekt.Pakitud = 1;
                }
                db.Entry(arvutikomplekt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Packing");
            }
            return RedirectToAction("Packing");
        }

        // GET: Arvutikomplekts/Order

        public ActionResult Order()
        {
            return View();
        }

        // POST: Arvutikomplekts/Order
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order([Bind(Include = "Kirjeldus,Korpus,Kuvar")] Arvutikomplekt arvutikomplekt)
        {


            if (ModelState.IsValid)
            {
                db.Arvutikomplekts.Add(arvutikomplekt);
                db.SaveChanges();
                return RedirectToAction("Assembly");
            }

            return View(arvutikomplekt);
        }

        // GET: Arvutikomplekts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arvutikomplekt arvutikomplekt = db.Arvutikomplekts.Find(id);
            if (arvutikomplekt == null)
            {
                return HttpNotFound();
            }
            return View(arvutikomplekt);
        }

        // GET: Arvutikomplekts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arvutikomplekts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Kirjeldus,Korpus,Kuvar")] Arvutikomplekt arvutikomplekt)
        {
            if (ModelState.IsValid)
            {
                db.Arvutikomplekts.Add(arvutikomplekt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arvutikomplekt);
        }

        // GET: Arvutikomplekts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arvutikomplekt arvutikomplekt = db.Arvutikomplekts.Find(id);
            if (arvutikomplekt == null)
            {
                return HttpNotFound();
            }
            return View(arvutikomplekt);
        }

        // POST: Arvutikomplekts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Kirjeldus,Korpus,Kuvar")] Arvutikomplekt arvutikomplekt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arvutikomplekt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arvutikomplekt);
        }

        // GET: Arvutikomplekts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arvutikomplekt arvutikomplekt = db.Arvutikomplekts.Find(id);
            if (arvutikomplekt == null)
            {
                return HttpNotFound();
            }
            return View(arvutikomplekt);
        }

        // POST: Arvutikomplekts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arvutikomplekt arvutikomplekt = db.Arvutikomplekts.Find(id);
            db.Arvutikomplekts.Remove(arvutikomplekt);
            db.SaveChanges();
            return RedirectToAction("Order");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
