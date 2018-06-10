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
    public class StaffTblsController : EAController
    {
        

        // GET: StaffTbls
        public ActionResult Index()
        {
            return View(db.StaffTbls.ToList());
        }

        // GET: StaffTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffTbl staffTbl = db.StaffTbls.Find(id);
            if (staffTbl == null)
            {
                return HttpNotFound();
            }
            return View(staffTbl);
        }

        // GET: StaffTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "S_Id,S_Name,S_Responsibilities")] StaffTbl staffTbl)
        {
            if (ModelState.IsValid)
            {
                db.StaffTbls.Add(staffTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(staffTbl);
        }

        [AllowAnonymous]
        public ActionResult StaffList(int? id)
        {
            if (id != null)            
                ViewBag.results = db.StaffTbls.Find(id);            
            else                
                ViewBag.results = db.StaffTbls.FirstOrDefault();
            
            return View(db.StaffTbls.ToList());
        }

        // GET: StaffTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffTbl staffTbl = db.StaffTbls.Find(id);
            if (staffTbl == null)
            {
                return HttpNotFound();
            }
            return View(staffTbl);
        }

        // POST: StaffTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "S_Id,S_Name,S_Responsibilities")] StaffTbl staffTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staffTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staffTbl);
        }

        // GET: StaffTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffTbl staffTbl = db.StaffTbls.Find(id);
            if (staffTbl == null)
            {
                return HttpNotFound();
            }
            return View(staffTbl);
        }

        // POST: StaffTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StaffTbl staffTbl = db.StaffTbls.Find(id);
            db.StaffTbls.Remove(staffTbl);
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
