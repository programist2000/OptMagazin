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
    public class WorkerPrizesController : Controller
    {
        private MagazinContext db = new MagazinContext();

        // GET: WorkerPrizes
        public ActionResult Index()
        {
            var workerPrizes = db.WorkerPrizes.Include(w => w.Prize).Include(w => w.Worker);
            return View(workerPrizes.ToList());
        }

        // GET: WorkerPrizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerPrize workerPrize = db.WorkerPrizes.Find(id);
            if (workerPrize == null)
            {
                return HttpNotFound();
            }
            return View(workerPrize);
        }

        // GET: WorkerPrizes/Create
        public ActionResult Create()
        {
            ViewBag.PrizeId = new SelectList(db.Prizes, "PrizeId", "PrizeName");
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName");
            return View();
        }

        // POST: WorkerPrizes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkerPrizeId,WorkerId,PrizeDate,PrizeId,PrizeAmount")] WorkerPrize workerPrize)
        {
            if (ModelState.IsValid)
            {
                db.WorkerPrizes.Add(workerPrize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrizeId = new SelectList(db.Prizes, "PrizeId", "PrizeName", workerPrize.PrizeId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", workerPrize.WorkerId);
            return View(workerPrize);
        }

        // GET: WorkerPrizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerPrize workerPrize = db.WorkerPrizes.Find(id);
            if (workerPrize == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrizeId = new SelectList(db.Prizes, "PrizeId", "PrizeName", workerPrize.PrizeId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", workerPrize.WorkerId);
            return View(workerPrize);
        }

        // POST: WorkerPrizes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkerPrizeId,WorkerId,PrizeDate,PrizeId,PrizeAmount")] WorkerPrize workerPrize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workerPrize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrizeId = new SelectList(db.Prizes, "PrizeId", "PrizeName", workerPrize.PrizeId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", workerPrize.WorkerId);
            return View(workerPrize);
        }

        // GET: WorkerPrizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerPrize workerPrize = db.WorkerPrizes.Find(id);
            if (workerPrize == null)
            {
                return HttpNotFound();
            }
            return View(workerPrize);
        }

        // POST: WorkerPrizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkerPrize workerPrize = db.WorkerPrizes.Find(id);
            db.WorkerPrizes.Remove(workerPrize);
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
