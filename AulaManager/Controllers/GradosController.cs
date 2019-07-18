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
    public class GradosController : Controller
    {
        private AulaManagerContext db = new AulaManagerContext();

        // GET: Grados
        public ActionResult Index()
        {
            var gradosAlumnos = db.GradosAlumnos.Include(g => g.Profesor);
            return View(gradosAlumnos.ToList());
        }

        // GET: Grados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = db.GradosAlumnos.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            return View(grado);
        }

        // GET: Grados/Create
        public ActionResult Create()
        {
            //ViewBag.ProfedorId = new SelectList(db.Profesores, "ProfesorId", "NombreCompleto");
            ViewBag.ProfesorId = new SelectList(db.Profesores, "Id", "NombreCompleto");
            return View();
        }

        // POST: Grados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,ProfesorId")] Grado grado)
        {
            if (ModelState.IsValid)
            {
                db.GradosAlumnos.Add(grado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfesorId = new SelectList(db.Profesores, "Id", "NombreCompleto", grado.ProfesorId);
            return View(grado);
        }

        // GET: Grados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = db.GradosAlumnos.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfesorId = new SelectList(db.Profesores, "Id", "NombreCompleto", grado.ProfesorId);
            return View(grado);
        }

        // POST: Grados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,ProfesorId")] Grado grado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfesorId = new SelectList(db.Profesores, "Id", "NombreCompleto", grado.ProfesorId);
            return View(grado);
        }

        // GET: Grados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = db.GradosAlumnos.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            return View(grado);
        }

        // POST: Grados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grado grado = db.GradosAlumnos.Find(id);
            db.GradosAlumnos.Remove(grado);

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
                return View(grado);
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
