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
    public class EmpleadosController : Controller
    {
        private Planillas_webEntities db = new Planillas_webEntities();

        // GET: Empleados
        public ActionResult Index()
        {
            var empleados = db.Empleados.Include(e => e.Cargos).Include(e => e.Departamentos).Include(e => e.Empresas).Include(e => e.Estados_empleado);
            return View(empleados.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.ID_cargo = new SelectList(db.Cargos, "ID_cargo", "descripcion");
            ViewBag.ID_departamento = new SelectList(db.Departamentos, "ID_departamento", "nombre");
            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre");
            ViewBag.ID_estado = new SelectList(db.Estados_empleado, "ID_estado", "descripcion");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_empleado,nombres,apellidos,dui,nit,celular,edad,estado_civil,horas_laborales,salario_mensual,fecha_nacimiento,fecha_contratacion,ID_cargo,ID_departamento,ID_estado,ID_empresa")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_cargo = new SelectList(db.Cargos, "ID_cargo", "descripcion", empleados.ID_cargo);
            ViewBag.ID_departamento = new SelectList(db.Departamentos, "ID_departamento", "nombre", empleados.ID_departamento);
            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre", empleados.ID_empresa);
            ViewBag.ID_estado = new SelectList(db.Estados_empleado, "ID_estado", "descripcion", empleados.ID_estado);
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_cargo = new SelectList(db.Cargos, "ID_cargo", "descripcion", empleados.ID_cargo);
            ViewBag.ID_departamento = new SelectList(db.Departamentos, "ID_departamento", "nombre", empleados.ID_departamento);
            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre", empleados.ID_empresa);
            ViewBag.ID_estado = new SelectList(db.Estados_empleado, "ID_estado", "descripcion", empleados.ID_estado);

            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_empleado,nombres,apellidos,dui,nit,celular,edad,estado_civil,horas_laborales,salario_mensual,fecha_nacimiento,fecha_contratacion,ID_cargo,ID_departamento,ID_estado,ID_empresa")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_cargo = new SelectList(db.Cargos, "ID_cargo", "descripcion", empleados.ID_cargo);
            ViewBag.ID_departamento = new SelectList(db.Departamentos, "ID_departamento", "nombre", empleados.ID_departamento);
            ViewBag.ID_empresa = new SelectList(db.Empresas, "ID_empresa", "nombre", empleados.ID_empresa);
            ViewBag.ID_estado = new SelectList(db.Estados_empleado, "ID_estado", "descripcion", empleados.ID_estado);
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleados empleados = db.Empleados.Find(id);
            db.Empleados.Remove(empleados);
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
