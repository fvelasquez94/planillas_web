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
    public class Estados_empleadoController : Controller
    {
        private Planillas_webEntities db = new Planillas_webEntities();

        // GET: Estados_empleado
        public ActionResult Index()
        {
            var estados_empleado = db.Estados_empleado.Include(e => e.Empresas);
            return View(estados_empleado.ToList());
        }

        // GET: Estados_empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estados_empleado estados_empleado = db.Estados_empleado.Find(id);
            if (estados_empleado == null)
            {
                return HttpNotFound();
            }
            return View(estados_empleado);
        }

        // GET: Estados_empleado/Create
        public ActionResult Create()
        {
            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre");
            return View();
        }

        // POST: Estados_empleado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_estado,descripcion,ID_empresa")] Estados_empleado estados_empleado)
        {
            if (ModelState.IsValid)
            {
                db.Estados_empleado.Add(estados_empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre", estados_empleado.ID_empresa);
            return View(estados_empleado);
        }

        // GET: Estados_empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estados_empleado estados_empleado = db.Estados_empleado.Find(id);
            if (estados_empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre", estados_empleado.ID_empresa);
            return View(estados_empleado);
        }

        // POST: Estados_empleado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_estado,descripcion,ID_empresa")] Estados_empleado estados_empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estados_empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre", estados_empleado.ID_empresa);
            return View(estados_empleado);
        }

        // GET: Estados_empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estados_empleado estados_empleado = db.Estados_empleado.Find(id);
            if (estados_empleado == null)
            {
                return HttpNotFound();
            }
            return View(estados_empleado);
        }

        // POST: Estados_empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estados_empleado estados_empleado = db.Estados_empleado.Find(id);
            db.Estados_empleado.Remove(estados_empleado);
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
