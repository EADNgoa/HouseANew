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
    public class NewsTblsController : Controller
    {
        private GoaRehabEntities db = new GoaRehabEntities();

        // GET: NewsTbls
        public ActionResult Index()
        {
            return View(db.NewsTbls.ToList());
        }

        // GET: NewsTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsTbl newsTbl = db.NewsTbls.Find(id);
            if (newsTbl == null)
            {
                return HttpNotFound();
            }
            return View(newsTbl);
        }

        // GET: NewsTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "N_Id,N_Title,N_Desc,N_Pic,N_Date")] NewsTbl newsTbl)
        {
            if (ModelState.IsValid)
            {
                db.NewsTbls.Add(newsTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsTbl);
        }

        // GET: NewsTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsTbl newsTbl = db.NewsTbls.Find(id);
            if (newsTbl == null)
            {
                return HttpNotFound();
            }
            return View(newsTbl);
        }

        // POST: NewsTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "N_Id,N_Title,N_Desc,N_Pic,N_Date")] NewsTbl newsTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsTbl);
        }

        // GET: NewsTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsTbl newsTbl = db.NewsTbls.Find(id);
            if (newsTbl == null)
            {
                return HttpNotFound();
            }
            return View(newsTbl);
        }

        // POST: NewsTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsTbl newsTbl = db.NewsTbls.Find(id);
            db.NewsTbls.Remove(newsTbl);
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
