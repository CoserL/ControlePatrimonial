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
    public class salasController : Controller
    {
        private controle_patrimonialEntities db = new controle_patrimonialEntities();

        // GET: salas
        public ActionResult Index()
        {
            var salas = db.salas.Include(s => s.predio);
            return View(salas.ToList());
        }

        // GET: salas/Details/5
        public ActionResult Details(int? id, int? idPredio)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sala sala = db.salas.Find(id, idPredio);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // GET: salas/Create
        public ActionResult Create()
        {
            ViewBag.idPredio = new SelectList(db.predios, "idPredio", "descPredio");
            return View();
        }

        // POST: salas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSala,descSala,idPredio")] sala sala)
        {
            if (ModelState.IsValid)
            {
                db.salas.Add(sala);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPredio = new SelectList(db.predios, "idPredio", "descPredio", sala.idPredio);
            return View(sala);
        }

        // GET: salas/Edit/5
        public ActionResult Edit(int? id, int? idPredio)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sala sala = db.salas.Find(id, idPredio);
            if (sala == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPredio = new SelectList(db.predios, "idPredio", "descPredio", sala.idPredio);
            return View(sala);
        }

        // POST: salas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSala,descSala,idPredio")] sala sala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sala).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPredio = new SelectList(db.predios, "idPredio", "descPredio", sala.idPredio);
            return View(sala);
        }

        // GET: salas/Delete/5
        public ActionResult Delete(int? id, int? idPredio)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sala sala = db.salas.Find(id, idPredio);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // POST: salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int idPredio)
        {
            sala sala = db.salas.Find(id, idPredio);
            db.salas.Remove(sala);
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
