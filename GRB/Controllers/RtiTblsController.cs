using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GRB.Models;

namespace GRB.Controllers
{
    public class RtiTblsController : EAController
    {
        public ActionResult Upload()
        {
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string successFile;
                    successFile= SaveImage(Path.GetFileName(file.FileName), "Rti", 1, file);
                    ViewBag.Message = successFile+" upload successful. Upload another document?";
                }
                    return View("Edit");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Upload failed with error:" + ex.Message;
                return View("Edit");
            }
        }
        
        // GET: RtiTbls
        public ActionResult Index()
        {
            return View(db.RtiTbls.ToList());
        }

        [AllowAnonymous]
        public ActionResult RtiView()
        {
            return View(db.RtiTbls.Find(1));
        }

        [AllowAnonymous]
        public ActionResult PioView()
        {
            return View(db.RtiTbls.Find(1));
        }

        [AllowAnonymous]
        public ActionResult ApioView()
        {
            return View(db.RtiTbls.Find(1));
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

            existingRec.RTI = rtiTbl.RTI.Replace("href=\"", "href=\"/Uploads/");
            existingRec.RTI = rtiTbl.RTI.Replace("/Uploads//Uploads/", "/Uploads/");

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