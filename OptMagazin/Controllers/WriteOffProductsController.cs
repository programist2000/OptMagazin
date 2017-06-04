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
    public class WriteOffProductsController : Controller
    {
        private MagazinContext db = new MagazinContext();

        // GET: WriteOffProducts
        public ActionResult Index()
        {
            var writeOffProducts = db.WriteOffProducts.Include(w => w.Cause).Include(w => w.Product);
            return View(writeOffProducts.ToList());
        }

        // GET: WriteOffProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WriteOffProduct writeOffProduct = db.WriteOffProducts.Find(id);
            if (writeOffProduct == null)
            {
                return HttpNotFound();
            }
            return View(writeOffProduct);
        }

        // GET: WriteOffProducts/Create
        public ActionResult Create()
        {
            ViewBag.CauseId = new SelectList(db.Causes, "CauseId", "CauseName");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: WriteOffProducts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WriteOffProductId,WriteOffAmount,ProductId,WriteOffDate,CauseId")] WriteOffProduct writeOffProduct)
        {
            if (ModelState.IsValid)
            {
                db.WriteOffProducts.Add(writeOffProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CauseId = new SelectList(db.Causes, "CauseId", "CauseName", writeOffProduct.CauseId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", writeOffProduct.ProductId);
            return View(writeOffProduct);
        }

        // GET: WriteOffProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WriteOffProduct writeOffProduct = db.WriteOffProducts.Find(id);
            if (writeOffProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.CauseId = new SelectList(db.Causes, "CauseId", "CauseName", writeOffProduct.CauseId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", writeOffProduct.ProductId);
            return View(writeOffProduct);
        }

        // POST: WriteOffProducts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WriteOffProductId,WriteOffAmount,ProductId,WriteOffDate,CauseId")] WriteOffProduct writeOffProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(writeOffProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CauseId = new SelectList(db.Causes, "CauseId", "CauseName", writeOffProduct.CauseId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", writeOffProduct.ProductId);
            return View(writeOffProduct);
        }

        // GET: WriteOffProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WriteOffProduct writeOffProduct = db.WriteOffProducts.Find(id);
            if (writeOffProduct == null)
            {
                return HttpNotFound();
            }
            return View(writeOffProduct);
        }

        // POST: WriteOffProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WriteOffProduct writeOffProduct = db.WriteOffProducts.Find(id);
            db.WriteOffProducts.Remove(writeOffProduct);
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
