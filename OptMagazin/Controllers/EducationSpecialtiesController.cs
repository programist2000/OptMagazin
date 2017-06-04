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
    public class EducationSpecialtiesController : Controller
    {
        private MagazinContext db = new MagazinContext();

        // GET: EducationSpecialties
        public ActionResult Index()
        {
            return View(db.EducationSpecialties.ToList());
        }

        // GET: EducationSpecialties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationSpecialty educationSpecialty = db.EducationSpecialties.Find(id);
            if (educationSpecialty == null)
            {
                return HttpNotFound();
            }
            return View(educationSpecialty);
        }

        // GET: EducationSpecialties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EducationSpecialties/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EducationSpecialtyId,EducationSpecialtyName")] EducationSpecialty educationSpecialty)
        {
            if (ModelState.IsValid)
            {
                db.EducationSpecialties.Add(educationSpecialty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(educationSpecialty);
        }

        // GET: EducationSpecialties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationSpecialty educationSpecialty = db.EducationSpecialties.Find(id);
            if (educationSpecialty == null)
            {
                return HttpNotFound();
            }
            return View(educationSpecialty);
        }

        // POST: EducationSpecialties/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EducationSpecialtyId,EducationSpecialtyName")] EducationSpecialty educationSpecialty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(educationSpecialty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(educationSpecialty);
        }

        // GET: EducationSpecialties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationSpecialty educationSpecialty = db.EducationSpecialties.Find(id);
            if (educationSpecialty == null)
            {
                return HttpNotFound();
            }
            return View(educationSpecialty);
        }

        // POST: EducationSpecialties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EducationSpecialty educationSpecialty = db.EducationSpecialties.Find(id);
            db.EducationSpecialties.Remove(educationSpecialty);
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
