using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OptMagazin;
using OptMagazin.Models;

namespace OptMagazin.Controllers
{
    public class WorkerEducationsController : Controller
    {
        private MagazinContext db = new MagazinContext();

        // GET: WorkerEducations
        public ActionResult Index()
        {
            var workerEducations = db.WorkerEducations.Include(w => w.EducationSpecialty).Include(w => w.University).Include(w => w.Worker);
            return View(workerEducations.ToList());
        }

        // GET: WorkerEducations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerEducation workerEducation = db.WorkerEducations.Find(id);
            if (workerEducation == null)
            {
                return HttpNotFound();
            }
            return View(workerEducation);
        }

        // GET: WorkerEducations/Create
        public ActionResult Create()
        {
            ViewBag.EducationSpecialtyId = new SelectList(db.EducationSpecialties, "EducationSpecialtyId", "EducationSpecialtyName");
            ViewBag.UniversityId = new SelectList(db.Universities, "UniversityId", "UniversityName");
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName");
            return View();
        }

        // POST: WorkerEducations/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkerEducationId,WorkerId,UniversityId,EducationStart,EducationEnd,EducationSpecialtyId")] WorkerEducation workerEducation)
        {
            if (ModelState.IsValid)
            {
                db.WorkerEducations.Add(workerEducation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EducationSpecialtyId = new SelectList(db.EducationSpecialties, "EducationSpecialtyId", "EducationSpecialtyName", workerEducation.EducationSpecialtyId);
            ViewBag.UniversityId = new SelectList(db.Universities, "UniversityId", "UniversityName", workerEducation.UniversityId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", workerEducation.WorkerId);
            return View(workerEducation);
        }

        // GET: WorkerEducations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerEducation workerEducation = db.WorkerEducations.Find(id);
            if (workerEducation == null)
            {
                return HttpNotFound();
            }
            ViewBag.EducationSpecialtyId = new SelectList(db.EducationSpecialties, "EducationSpecialtyId", "EducationSpecialtyName", workerEducation.EducationSpecialtyId);
            ViewBag.UniversityId = new SelectList(db.Universities, "UniversityId", "UniversityName", workerEducation.UniversityId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", workerEducation.WorkerId);
            return View(workerEducation);
        }

        // POST: WorkerEducations/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkerEducationId,WorkerId,UniversityId,EducationStart,EducationEnd,EducationSpecialtyId")] WorkerEducation workerEducation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workerEducation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EducationSpecialtyId = new SelectList(db.EducationSpecialties, "EducationSpecialtyId", "EducationSpecialtyName", workerEducation.EducationSpecialtyId);
            ViewBag.UniversityId = new SelectList(db.Universities, "UniversityId", "UniversityName", workerEducation.UniversityId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", workerEducation.WorkerId);
            return View(workerEducation);
        }

        // GET: WorkerEducations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerEducation workerEducation = db.WorkerEducations.Find(id);
            if (workerEducation == null)
            {
                return HttpNotFound();
            }
            return View(workerEducation);
        }

        // POST: WorkerEducations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkerEducation workerEducation = db.WorkerEducations.Find(id);
            db.WorkerEducations.Remove(workerEducation);
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
