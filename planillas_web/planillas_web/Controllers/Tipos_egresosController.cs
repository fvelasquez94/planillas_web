using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using planillas_web.Models;

namespace planillas_web.Controllers
{
    public class Tipos_egresosController : Controller
    {
        private Planillas_webEntities db = new Planillas_webEntities();

        // GET: Tipos_egresos
        public ActionResult Index()
        {
            var tipos_egresos = db.Tipos_egresos.Include(t => t.Empresas);
            return View(tipos_egresos.ToList());
        }

        // GET: Tipos_egresos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_egresos tipos_egresos = db.Tipos_egresos.Find(id);
            if (tipos_egresos == null)
            {
                return HttpNotFound();
            }
            return View(tipos_egresos);
        }

        // GET: Tipos_egresos/Create
        public ActionResult Create()
        {
            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre");
            return View();
        }

        // POST: Tipos_egresos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_tipo_egreso,descripcion,ID_empresa")] Tipos_egresos tipos_egresos)
        {
            if (ModelState.IsValid)
            {
                db.Tipos_egresos.Add(tipos_egresos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre", tipos_egresos.ID_empresa);
            return View(tipos_egresos);
        }

        // GET: Tipos_egresos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_egresos tipos_egresos = db.Tipos_egresos.Find(id);
            if (tipos_egresos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre", tipos_egresos.ID_empresa);
            return View(tipos_egresos);
        }

        // POST: Tipos_egresos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_tipo_egreso,descripcion,ID_empresa")] Tipos_egresos tipos_egresos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipos_egresos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre", tipos_egresos.ID_empresa);
            return View(tipos_egresos);
        }

        // GET: Tipos_egresos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_egresos tipos_egresos = db.Tipos_egresos.Find(id);
            if (tipos_egresos == null)
            {
                return HttpNotFound();
            }
            return View(tipos_egresos);
        }

        // POST: Tipos_egresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipos_egresos tipos_egresos = db.Tipos_egresos.Find(id);
            db.Tipos_egresos.Remove(tipos_egresos);
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
