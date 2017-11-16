using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoaRehabWeb.Models;
using System.IO;

namespace GoaRehabWeb.Controllers
{
    public class PicturesTblsController : Controller
    {
        private GoaRehabEntities db = new GoaRehabEntities();

        // GET: PicturesTbls
        public ActionResult Index()
        {
            return View(db.PicturesTbls.ToList());
        }

        // GET: PicturesTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PicturesTbl picturesTbl = db.PicturesTbls.Find(id);
            if (picturesTbl == null)
            {
                return HttpNotFound();
            }
            return View(picturesTbl);
        }

        // GET: PicturesTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PicturesTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pic_Id,Pic_Name,Pic_Path")] PicturesTbl picturesTbl)
        {
            if (ModelState.IsValid)
            {
                db.PicturesTbls.Add(picturesTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(picturesTbl);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/Pictures/"), fileName);
                    file.SaveAs(path);
                }
                ViewBag.Message = "Upload successful";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("Create");
            }
        }

        // GET: PicturesTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PicturesTbl picturesTbl = db.PicturesTbls.Find(id);
            if (picturesTbl == null)
            {
                return HttpNotFound();
            }
            return View(picturesTbl);
        }

        // POST: PicturesTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pic_Id,Pic_Name,Pic_Path")] PicturesTbl picturesTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(picturesTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(picturesTbl);
        }

        // GET: PicturesTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PicturesTbl picturesTbl = db.PicturesTbls.Find(id);
            if (picturesTbl == null)
            {
                return HttpNotFound();
            }
            return View(picturesTbl);
        }

        // POST: PicturesTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PicturesTbl picturesTbl = db.PicturesTbls.Find(id);
            db.PicturesTbls.Remove(picturesTbl);
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
