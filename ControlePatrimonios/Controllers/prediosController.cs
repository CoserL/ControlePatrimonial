using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControlePatrimonios;

namespace ControlePatrimonios.Controllers
{
    public class prediosController : Controller
    {
        private controle_patrimonialEntities db = new controle_patrimonialEntities();

        // GET: predios
        public ActionResult Index()
        {
            return View(db.predios.ToList());
        }

        // GET: predios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            predio predio = db.predios.Find(id);
            if (predio == null)
            {
                return HttpNotFound();
            }
            return View(predio);
        }

        // GET: predios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: predios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPredio,descPredio")] predio predio)
        {
            if (ModelState.IsValid)
            {
                db.predios.Add(predio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(predio);
        }

        // GET: predios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            predio predio = db.predios.Find(id);
            if (predio == null)
            {
                return HttpNotFound();
            }
            return View(predio);
        }

        // POST: predios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPredio,descPredio")] predio predio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(predio);
        }

        // GET: predios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            predio predio = db.predios.Find(id);
            if (predio == null)
            {
                return HttpNotFound();
            }
            return View(predio);
        }

        // POST: predios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            predio predio = db.predios.Find(id);
            db.predios.Remove(predio);
            db.SaveChanges();
            return RedirectToAction("Index");
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
