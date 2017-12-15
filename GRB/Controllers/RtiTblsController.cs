using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GRB.Models;

namespace GRB.Controllers
{
    public class RtiTblsController : EAController
    {
        
        // GET: RtiTbls
        public ActionResult Index()
        {
            return View(db.RtiTbls.ToList());
        }

        [AllowAnonymous]
        public ActionResult RtiView()
        {
            var id = 1;
            ViewBag.info = db.RtiTbls.Find(id);
            return View(db.RtiTbls.ToList());
        }

        [AllowAnonymous]
        public ActionResult PioView()
        {
            var id = 1;
            ViewBag.info = db.RtiTbls.Find(id);
            return View(db.RtiTbls.ToList());
        }

        [AllowAnonymous]
        public ActionResult ApioView()
        {
            var id = 1;
            ViewBag.info = db.RtiTbls.Find(id);
            return View(db.RtiTbls.ToList());
        }

        // GET: RtiTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RtiTbl rtiTbl = db.RtiTbls.Find(id);
            if (rtiTbl == null)
            {
                return HttpNotFound();
            }
            return View(rtiTbl);
        }

        // GET: RtiTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RtiTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RTI,PIO,APIO")] RtiTbl rtiTbl)
        {
            if (ModelState.IsValid)
            {
                db.RtiTbls.Add(rtiTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rtiTbl);
        }

        // GET: RtiTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RtiTbl rtiTbl = db.RtiTbls.Find(id);
            if (rtiTbl == null)
            {
                return HttpNotFound();
            }
            return View(rtiTbl);
        }

        public ActionResult EditRti()
        {   
            RtiTbl rtiTbl = db.RtiTbls.Find(1);
            if (rtiTbl == null)
            {
                return HttpNotFound();
            }
            return View(rtiTbl);
        }

        public ActionResult EditPIO()
        {            
            RtiTbl rtiTbl = db.RtiTbls.Find(1);
            if (rtiTbl == null)
            {
                return HttpNotFound();
            }
            return View(rtiTbl);
        }

        public ActionResult EditAPIO()
        {
            RtiTbl rtiTbl = db.RtiTbls.Find(1);
            if (rtiTbl == null)
            {
                return HttpNotFound();
            }
            return View(rtiTbl);
        }
        // POST: RtiTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RTI,PIO,APIO")] RtiTbl rtiTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rtiTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rtiTbl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRti([Bind(Include = "Id,RTI")] RtiTbl rtiTbl)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(rtiTbl).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            var existingRec = db.RtiTbls.Find(1);

            existingRec.RTI = rtiTbl.RTI;

            db.Entry(existingRec).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("InnerCircle", "Home");
            //return View(rtiTbl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPIO([Bind(Include = "Id,PIO")] RtiTbl rtiTbl)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(rtiTbl).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            var existingRec = db.RtiTbls.Find(1);

            existingRec.PIO = rtiTbl.PIO;

            db.Entry(existingRec).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("InnerCircle", "Home");
            //return View(rtiTbl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAPIO([Bind(Include = "Id,APIO")] RtiTbl rtiTbl)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(rtiTbl).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            var existingRec = db.RtiTbls.Find(1);

            existingRec.APIO = rtiTbl.APIO;

            db.Entry(existingRec).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("InnerCircle", "Home");
            //return View(rtiTbl);
        }

        // GET: RtiTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RtiTbl rtiTbl = db.RtiTbls.Find(id);
            if (rtiTbl == null)
            {
                return HttpNotFound();
            }
            return View(rtiTbl);
        }

        // POST: RtiTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RtiTbl rtiTbl = db.RtiTbls.Find(id);
            db.RtiTbls.Remove(rtiTbl);
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