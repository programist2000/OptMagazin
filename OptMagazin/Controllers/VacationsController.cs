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
    public class VacationsController : Controller
    {
        private MagazinContext db = new MagazinContext();

        // GET: Vacations
        public ActionResult Index()
        {
            var vacations = db.Vacations.Include(v => v.VacationSort).Include(v => v.Worker);
            return View(vacations.ToList());
        }

        // GET: Vacations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacation vacation = db.Vacations.Find(id);
            if (vacation == null)
            {
                return HttpNotFound();
            }
            return View(vacation);
        }

        // GET: Vacations/Create
        public ActionResult Create()
        {
            ViewBag.VacationSortId = new SelectList(db.VacationSorts, "VacationSortId", "VacationName");
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName");
            return View();
        }

        // POST: Vacations/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VacationId,WorkerId,VacationStart,VacationEnd,VacationSortId,VacationStatus")] Vacation vacation)
        {
            if (ModelState.IsValid)
            {
                db.Vacations.Add(vacation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VacationSortId = new SelectList(db.VacationSorts, "VacationSortId", "VacationName", vacation.VacationSortId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", vacation.WorkerId);
            return View(vacation);
        }

        // GET: Vacations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacation vacation = db.Vacations.Find(id);
            if (vacation == null)
            {
                return HttpNotFound();
            }
            ViewBag.VacationSortId = new SelectList(db.VacationSorts, "VacationSortId", "VacationName", vacation.VacationSortId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", vacation.WorkerId);
            return View(vacation);
        }

        // POST: Vacations/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VacationId,WorkerId,VacationStart,VacationEnd,VacationSortId,VacationStatus")] Vacation vacation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VacationSortId = new SelectList(db.VacationSorts, "VacationSortId", "VacationName", vacation.VacationSortId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", vacation.WorkerId);
            return View(vacation);
        }

        // GET: Vacations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacation vacation = db.Vacations.Find(id);
            if (vacation == null)
            {
                return HttpNotFound();
            }
            return View(vacation);
        }

        // POST: Vacations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacation vacation = db.Vacations.Find(id);
            db.Vacations.Remove(vacation);
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
