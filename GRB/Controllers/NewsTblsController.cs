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
        public ActionResult Create([Bind(Include = "N_Id,N_Title,N_Desc,N_Date,N_Status, UploadedFile")] NewsImg newsTbl)
        {
            if (ModelState.IsValid)
            {

                NewsTbl nt = new NewsTbl
                {
                    N_Id = newsTbl.N_Id,
                    N_Title = newsTbl.N_Title,
                    N_Desc = newsTbl.N_Desc,
                    N_Date = newsTbl.N_Date,
                    N_Status = newsTbl.N_Status
                };

                if(newsTbl.UploadedFile != null)
                {
                    string fn = newsTbl.UploadedFile.FileName.Substring(newsTbl.UploadedFile.FileName.LastIndexOf('\\') + 1);
                    Random rd = new Random(DateTime.Today.Day);
                    fn = rd.Next(300, 800) + "_" + fn;
                    string SavePath = System.IO.Path.Combine(Server.MapPath("~/Uploads/Pictures/"), fn);
                    newsTbl.UploadedFile.SaveAs(SavePath);
                    nt.N_Pic = fn;
                }

                db.NewsTbls.Add(nt);
                db.SaveChanges();
                return RedirectToAction("Index");
                //db.NewsTbls.Add(newsTbl);
                //db.SaveChanges();
                //return RedirectToAction("Index");
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
            ViewBag.ExistingImg = newsTbl.N_Pic;
            if (newsTbl == null)
            {
                return HttpNotFound();
            }
            NewsImg ViewInfo = new NewsImg
            {
                N_Id = newsTbl.N_Id,
                N_Title = newsTbl.N_Title,
                N_Desc = newsTbl.N_Desc,
                N_Date = (DateTime)newsTbl.N_Date
            };
            ViewBag.ExistingFile = newsTbl.N_Pic;
            return View(ViewInfo);
        }

        // POST: NewsTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "N_Id,N_Title,N_Desc,N_Pic,N_Date,N_Status")] NewsTbl newsTbl)
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
