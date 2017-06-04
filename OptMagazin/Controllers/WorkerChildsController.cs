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
    public class WorkerChildsController : Controller
    {
        private MagazinContext db = new MagazinContext();

        // GET: WorkerChilds
        public ActionResult Index()
        {
            var workerChildren = db.WorkerChildren.Include(w => w.Worker);
            return View(workerChildren.ToList());
        }

        // GET: WorkerChilds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerChild workerChild = db.WorkerChildren.Include(w => w.Worker).First(w => w.WorkerChildId == id);
            if (workerChild == null)
            {
                return HttpNotFound();
            }
            return View(workerChild);
        }

        // GET: WorkerChilds/Create
        public ActionResult Create()
        {
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName");
            return View();
        }

        // POST: WorkerChilds/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkerChildId,WorkerId,ChildName,ChildGender,ChildBirthday,StudyPlace")] WorkerChild workerChild)
        {
            if (ModelState.IsValid)
            {
                db.WorkerChildren.Add(workerChild);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", workerChild.WorkerId);
            return View(workerChild);
        }

        // GET: WorkerChilds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerChild workerChild = db.WorkerChildren.Find(id);
            if (workerChild == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", workerChild.WorkerId);
            return View(workerChild);
        }

        // POST: WorkerChilds/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkerChildId,WorkerId,ChildName,ChildGender,ChildBirthday,StudyPlace")] WorkerChild workerChild)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workerChild).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", workerChild.WorkerId);
            return View(workerChild);
        }

        // GET: WorkerChilds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerChild workerChild = db.WorkerChildren.Find(id);
            if (workerChild == null)
            {
                return HttpNotFound();
            }
            return View(workerChild);
        }

        // POST: WorkerChilds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkerChild workerChild = db.WorkerChildren.Find(id);
            db.WorkerChildren.Remove(workerChild);
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
