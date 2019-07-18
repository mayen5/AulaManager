using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AulaManager.Models;

namespace AulaManager.Controllers
{
    public class AlumnosGradoController : Controller
    {
        private AulaManagerContext db = new AulaManagerContext();

        // GET: AlumnosGrado
        public ActionResult Index()
        {
            var alumnosGrado = db.AlumnosGrado.Include(a => a.Alumno).Include(a => a.Grado);
            return View(alumnosGrado.ToList());
        }

        // GET: AlumnosGrado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoGrado alumnoGrado = db.AlumnosGrado.Find(id);
            if (alumnoGrado == null)
            {
                return HttpNotFound();
            }
            return View(alumnoGrado);
        }

        // GET: AlumnosGrado/Create
        public ActionResult Create()
        {
            ViewBag.AlumnoId = new SelectList(db.Alumnos, "Id", "NombreCompleto");
            ViewBag.GradoId = new SelectList(db.GradosAlumnos, "Id", "Nombre");
            return View();
        }

        // POST: AlumnosGrado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AlumnoId,GradoId,Seccion")] AlumnoGrado alumnoGrado)
        {
            if (ModelState.IsValid)
            {
                db.AlumnosGrado.Add(alumnoGrado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlumnoId = new SelectList(db.Alumnos, "Id", "NombreCompleto", alumnoGrado.AlumnoId);
            ViewBag.GradoId = new SelectList(db.GradosAlumnos, "Id", "Nombre", alumnoGrado.GradoId);
            return View(alumnoGrado);
        }

        // GET: AlumnosGrado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoGrado alumnoGrado = db.AlumnosGrado.Find(id);
            if (alumnoGrado == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlumnoId = new SelectList(db.Alumnos, "Id", "NombreCompleto", alumnoGrado.AlumnoId);
            ViewBag.GradoId = new SelectList(db.GradosAlumnos, "Id", "Nombre", alumnoGrado.GradoId);
            return View(alumnoGrado);
        }

        // POST: AlumnosGrado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AlumnoId,GradoId,Seccion")] AlumnoGrado alumnoGrado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnoGrado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlumnoId = new SelectList(db.Alumnos, "Id", "NombreCompleto", alumnoGrado.AlumnoId);
            ViewBag.GradoId = new SelectList(db.GradosAlumnos, "Id", "Nombre", alumnoGrado.GradoId);
            return View(alumnoGrado);
        }

        // GET: AlumnosGrado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoGrado alumnoGrado = db.AlumnosGrado.Find(id);
            if (alumnoGrado == null)
            {
                return HttpNotFound();
            }
            return View(alumnoGrado);
        }

        // POST: AlumnosGrado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlumnoGrado alumnoGrado = db.AlumnosGrado.Find(id);
            db.AlumnosGrado.Remove(alumnoGrado);

            try
            {
                db.SaveChanges();

            }
            catch (Exception ex)
            {

                if (ex.InnerException != null && ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    ModelState.AddModelError(string.Empty, "El registro no se puede eliminar porque tiene datos relacionados.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return View(alumnoGrado);
            }
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
