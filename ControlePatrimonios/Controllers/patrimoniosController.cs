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
    public class patrimoniosController : Controller
    {
        private controle_patrimonialEntities db = new controle_patrimonialEntities();

        // GET: patrimonios
        public ActionResult Index()
        {
            var patrimonios = db.patrimonios.Include(p => p.ben).Include(p => p.sala);
            return View(patrimonios.ToList());
        }

        // GET: patrimonios/Details/5
        public ActionResult Details(int? id, int? idBem,int? idCat, int? idSala, int? idPredio)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patrimonio patrimonio = db.patrimonios.Find(id, idBem, idCat, idSala, idPredio);
            if (patrimonio == null)
            {
                return HttpNotFound();
            }
            return View(patrimonio);
        }

        // GET: patrimonios/Create
        public ActionResult Create()
        {
            ViewBag.idBem = new SelectList(db.bens, "idBem", "descBem");
            ViewBag.idSala = new SelectList(db.salas, "idSala", "descSala");
            ViewBag.idCategoria = new SelectList(db.categorias, "idCategoria", "descCategoria");
            ViewBag.idPredio = new SelectList(db.predios, "idPredio", "descPredio");
            return View();
        }

        // POST: patrimonios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPatrimonio,numPatrimonio,idBem,idCategoria,idSala,idPredio")] patrimonio patrimonio)
        {
            if (ModelState.IsValid)
            {
                db.patrimonios.Add(patrimonio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBem = new SelectList(db.bens, "idBem", "descBem", patrimonio.idBem);
            ViewBag.idSala = new SelectList(db.salas, "idSala", "descSala", patrimonio.idSala);
            ViewBag.idCategoria = new SelectList(db.categorias, "idCategoria", "descCategoria", patrimonio.idCategoria);
            ViewBag.idPredio = new SelectList(db.predios, "idPredio", "descPredio", patrimonio.idPredio);
            return View(patrimonio);
        }

        // GET: patrimonios/Edit/5
        public ActionResult Edit(int? id, int? idBem, int? idCat, int? idSala, int? idPredio)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patrimonio patrimonio = db.patrimonios.Find(id, idBem, idCat, idSala, idPredio);
            if (patrimonio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBem = new SelectList(db.bens, "idBem", "descBem", patrimonio.idBem);
            ViewBag.idSala = new SelectList(db.salas, "idSala", "descSala", patrimonio.idSala);
            return View(patrimonio);
        }

        // POST: patrimonios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPatrimonio,numPatrimonio,idBem,idCategoria,idSala,idPredio")] patrimonio patrimonio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patrimonio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBem = new SelectList(db.bens, "idBem", "descBem", patrimonio.idBem);
            ViewBag.idSala = new SelectList(db.salas, "idSala", "descSala", patrimonio.idSala);
            return View(patrimonio);
        }

        // GET: patrimonios/Delete/5
        public ActionResult Delete(int? id, int? idBem, int? idCat, int? idSala, int? idPredio)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patrimonio patrimonio = db.patrimonios.Find(id, idBem, idCat, idSala, idPredio);
            if (patrimonio == null)
            {
                return HttpNotFound();
            }
            return View(patrimonio);
        }

        // POST: patrimonios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id, int? idBem, int? idCat, int? idSala, int? idPredio)
        {
            patrimonio patrimonio = db.patrimonios.Find(id, idBem, idCat, idSala, idPredio);
            db.patrimonios.Remove(patrimonio);
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
