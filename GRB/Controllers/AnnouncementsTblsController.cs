using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoaRehabWeb.Models;

namespace GoaRehabWeb.Controllers
{
    public class AnnouncementsTblsController : Controller
    {
        private GoaRehabEntities db = new GoaRehabEntities();

        // GET: AnnouncementsTbls
        public ActionResult Index()
        {
            return View(db.AnnouncementsTbls.ToList());
        }

        // GET: AnnouncementsTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnouncementsTbl announcementsTbl = db.AnnouncementsTbls.Find(id);
            if (announcementsTbl == null)
            {
                return HttpNotFound();
            }
            return View(announcementsTbl);
        }

        // GET: AnnouncementsTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnnouncementsTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "A_Id,A_Title,A_Desc,A_Pic,A_Date")] AnnouncementsTbl announcementsTbl)
        {
            if (ModelState.IsValid)
            {
                db.AnnouncementsTbls.Add(announcementsTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(announcementsTbl);
        }

        // GET: AnnouncementsTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnouncementsTbl announcementsTbl = db.AnnouncementsTbls.Find(id);
            if (announcementsTbl == null)
            {
                return HttpNotFound();
            }
            return View(announcementsTbl);
        }

        // POST: AnnouncementsTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "A_Id,A_Title,A_Desc,A_Pic,A_Date")] AnnouncementsTbl announcementsTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(announcementsTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(announcementsTbl);
        }

        // GET: AnnouncementsTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnouncementsTbl announcementsTbl = db.AnnouncementsTbls.Find(id);
            if (announcementsTbl == null)
            {
                return HttpNotFound();
            }
            return View(announcementsTbl);
        }

        // POST: AnnouncementsTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnnouncementsTbl announcementsTbl = db.AnnouncementsTbls.Find(id);
            db.AnnouncementsTbls.Remove(announcementsTbl);
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
