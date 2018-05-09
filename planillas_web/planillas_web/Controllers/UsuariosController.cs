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
    public class UsuariosController : Controller
    {
        private Planillas_webEntities db = new Planillas_webEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.Empresas).Include(u => u.Tipo_usuarios);
            return View(usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre");
            ViewBag.ID_tipousuario = new SelectList(db.Tipo_usuarios, "ID_tipousuario", "descripcion");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_usuario,nombre_completo,correo,contrasena,fecha_registro,ID_empresa,ID_tipousuario")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre", usuarios.ID_empresa);
            ViewBag.ID_tipousuario = new SelectList(db.Tipo_usuarios, "ID_tipousuario", "descripcion", usuarios.ID_tipousuario);
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre", usuarios.ID_empresa);
            ViewBag.ID_tipousuario = new SelectList(db.Tipo_usuarios, "ID_tipousuario", "descripcion", usuarios.ID_tipousuario);
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_usuario,nombre_completo,correo,contrasena,fecha_registro,ID_empresa,ID_tipousuario")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre", usuarios.ID_empresa);
            ViewBag.ID_tipousuario = new SelectList(db.Tipo_usuarios, "ID_tipousuario", "descripcion", usuarios.ID_tipousuario);
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarios);
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
