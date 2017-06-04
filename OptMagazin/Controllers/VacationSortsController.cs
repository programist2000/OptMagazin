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
    public class VacationSortsController : Controller
    {
        private MagazinContext db = new MagazinContext();

        // GET: VacationSorts
        public ActionResult Index()
        {
            return View(db.VacationSorts.ToList());
        }

        // GET: VacationSorts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VacationSort vacationSort = db.VacationSorts.Find(id);
            if (vacationSort == null)
            {
                return HttpNotFound();
            }
            return View(vacationSort);
        }

        // GET: VacationSorts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VacationSorts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VacationSortId,VacationName")] VacationSort vacationSort)
        {
            if (ModelState.IsValid)
            {
                db.VacationSorts.Add(vacationSort);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vacationSort);
        }

        // GET: VacationSorts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VacationSort vacationSort = db.VacationSorts.Find(id);
            if (vacationSort == null)
            {
                return HttpNotFound();
            }
            return View(vacationSort);
        }

        // POST: VacationSorts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VacationSortId,VacationName")] VacationSort vacationSort)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacationSort).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vacationSort);
        }

        // GET: VacationSorts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VacationSort vacationSort = db.VacationSorts.Find(id);
            if (vacationSort == null)
            {
                return HttpNotFound();
            }
            return View(vacationSort);
        }

        // POST: VacationSorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VacationSort vacationSort = db.VacationSorts.Find(id);
            db.VacationSorts.Remove(vacationSort);
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
