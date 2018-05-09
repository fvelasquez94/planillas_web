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
    public class Tipos_ingresosController : Controller
    {
        private Planillas_webEntities db = new Planillas_webEntities();

        // GET: Tipos_ingresos
        public ActionResult Index()
        {
            var tipos_ingresos = db.Tipos_ingresos.Include(t => t.Empresas);
            return View(tipos_ingresos.ToList());
        }

        // GET: Tipos_ingresos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_ingresos tipos_ingresos = db.Tipos_ingresos.Find(id);
            if (tipos_ingresos == null)
            {
                return HttpNotFound();
            }
            return View(tipos_ingresos);
        }

        // GET: Tipos_ingresos/Create
        public ActionResult Create()
        {
            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre");
            return View();
        }

        // POST: Tipos_ingresos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_tipo_ingreso,descripcion,ID_empresa")] Tipos_ingresos tipos_ingresos)
        {
            if (ModelState.IsValid)
            {
                db.Tipos_ingresos.Add(tipos_ingresos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre", tipos_ingresos.ID_empresa);
            return View(tipos_ingresos);
        }

        // GET: Tipos_ingresos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_ingresos tipos_ingresos = db.Tipos_ingresos.Find(id);
            if (tipos_ingresos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre", tipos_ingresos.ID_empresa);
            return View(tipos_ingresos);
        }

        // POST: Tipos_ingresos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_tipo_ingreso,descripcion,ID_empresa")] Tipos_ingresos tipos_ingresos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipos_ingresos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre", tipos_ingresos.ID_empresa);
            return View(tipos_ingresos);
        }

        // GET: Tipos_ingresos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_ingresos tipos_ingresos = db.Tipos_ingresos.Find(id);
            if (tipos_ingresos == null)
            {
                return HttpNotFound();
            }
            return View(tipos_ingresos);
        }

        // POST: Tipos_ingresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipos_ingresos tipos_ingresos = db.Tipos_ingresos.Find(id);
            db.Tipos_ingresos.Remove(tipos_ingresos);
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
