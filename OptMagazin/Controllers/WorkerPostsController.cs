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
    public class WorkerPostsController : Controller
    {
        private MagazinContext db = new MagazinContext();

        // GET: WorkerPosts
        public ActionResult Index()
        {
            var workerPosts = db.WorkerPosts.Include(w => w.Post).Include(w => w.Worker);
            return View(workerPosts.ToList());
        }

        // GET: WorkerPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerPost workerPost = db.WorkerPosts.Find(id);
            if (workerPost == null)
            {
                return HttpNotFound();
            }
            return View(workerPost);
        }

        // GET: WorkerPosts/Create
        public ActionResult Create()
        {
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostName");
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName");
            return View();
        }

        // POST: WorkerPosts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkerPostId,PostId,WorkerId")] WorkerPost workerPost)
        {
            if (ModelState.IsValid)
            {
                db.WorkerPosts.Add(workerPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostName", workerPost.PostId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", workerPost.WorkerId);
            return View(workerPost);
        }

        // GET: WorkerPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerPost workerPost = db.WorkerPosts.Find(id);
            if (workerPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostName", workerPost.PostId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", workerPost.WorkerId);
            return View(workerPost);
        }

        // POST: WorkerPosts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkerPostId,PostId,WorkerId")] WorkerPost workerPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workerPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostName", workerPost.PostId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", workerPost.WorkerId);
            return View(workerPost);
        }

        // GET: WorkerPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerPost workerPost = db.WorkerPosts.Find(id);
            if (workerPost == null)
            {
                return HttpNotFound();
            }
            return View(workerPost);
        }

        // POST: WorkerPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkerPost workerPost = db.WorkerPosts.Find(id);
            db.WorkerPosts.Remove(workerPost);
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
