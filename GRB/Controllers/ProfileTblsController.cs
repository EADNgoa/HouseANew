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
    public class ProfileTblsController : Controller
    {
        private GoaRehabEntities db = new GoaRehabEntities();

        // GET: ProfileTbls
        public ActionResult Index()
        {
            return View(db.ProfileTbls.ToList());
        }

        // GET: ProfileTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileTbl profileTbl = db.ProfileTbls.Find(id);
            if (profileTbl == null)
            {
                return HttpNotFound();
            }
            return View(profileTbl);
        }

        // GET: ProfileTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "P_Id,P_Name,P_Pic,P_Desc")] ProfileTbl profileTbl)
        {
            if (ModelState.IsValid)
            {
                db.ProfileTbls.Add(profileTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profileTbl);
        }

        // GET: ProfileTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileTbl profileTbl = db.ProfileTbls.Find(id);
            if (profileTbl == null)
            {
                return HttpNotFound();
            }
            return View(profileTbl);
        }

        // POST: ProfileTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "P_Id,P_Name,P_Pic,P_Desc")] ProfileTbl profileTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profileTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profileTbl);
        }

        // GET: ProfileTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileTbl profileTbl = db.ProfileTbls.Find(id);
            if (profileTbl == null)
            {
                return HttpNotFound();
            }
            return View(profileTbl);
        }

        // POST: ProfileTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfileTbl profileTbl = db.ProfileTbls.Find(id);
            db.ProfileTbls.Remove(profileTbl);
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
