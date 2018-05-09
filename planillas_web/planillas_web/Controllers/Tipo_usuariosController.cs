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
    public class Tipo_usuariosController : Controller
    {
        private Planillas_webEntities db = new Planillas_webEntities();

        // GET: Tipo_usuarios
        public ActionResult Index()
        {
            return View(db.Tipo_usuarios.ToList());
        }

        // GET: Tipo_usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_usuarios tipo_usuarios = db.Tipo_usuarios.Find(id);
            if (tipo_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tipo_usuarios);
        }

        // GET: Tipo_usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_tipousuario,descripcion")] Tipo_usuarios tipo_usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_usuarios.Add(tipo_usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_usuarios);
        }

        // GET: Tipo_usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_usuarios tipo_usuarios = db.Tipo_usuarios.Find(id);
            if (tipo_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tipo_usuarios);
        }

        // POST: Tipo_usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_tipousuario,descripcion")] Tipo_usuarios tipo_usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_usuarios);
        }

        // GET: Tipo_usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_usuarios tipo_usuarios = db.Tipo_usuarios.Find(id);
            if (tipo_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tipo_usuarios);
        }

        // POST: Tipo_usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_usuarios tipo_usuarios = db.Tipo_usuarios.Find(id);
            db.Tipo_usuarios.Remove(tipo_usuarios);
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
