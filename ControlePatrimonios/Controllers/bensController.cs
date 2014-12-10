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
    public class bensController : Controller
    {
        private controle_patrimonialEntities db = new controle_patrimonialEntities();

        // GET: bens
        public ActionResult Index()
        {
            var bens = db.bens.Include(b => b.categoria);
            return View(bens.ToList());
        }

        // GET: bens/Details/5
        public ActionResult Details(int? id, int? idCat)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ben ben = db.bens.Find(id, idCat);
            if (ben == null)
            {
                return HttpNotFound();
            }
            return View(ben);
        }

        // GET: bens/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.categorias, "idCategoria", "descCategoria");
            return View();
        }

        // POST: bens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBem,descBem,idCategoria")] ben ben)
        {
            if (ModelState.IsValid)
            {
                db.bens.Add(ben);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.categorias, "idCategoria", "descCategoria", ben.idCategoria);
            return View(ben);
        }

        // GET: bens/Edit/5
        public ActionResult Edit(int? id, int? idCat)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ben ben = db.bens.Find(id, idCat);
            if (ben == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.categorias, "idCategoria", "descCategoria", ben.idCategoria);
            return View(ben);
        }

        // POST: bens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBem,descBem,idCategoria")] ben ben)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ben).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.categorias, "idCategoria", "descCategoria", ben.idCategoria);
            return View(ben);
        }

        // GET: bens/Delete/5
        public ActionResult Delete(int? id, int? idCat)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ben ben = db.bens.Find(id, idCat);
            if (ben == null)
            {
                return HttpNotFound();
            }
            return View(ben);
        }

        // POST: bens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int idCat)
        {
            ben ben = db.bens.Find(id, idCat);
            db.bens.Remove(ben);
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
