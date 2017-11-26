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
    public class GoaRehabTblsController : Controller
    {
        private GoaRehabEntities db = new GoaRehabEntities();

        // GET: GoaRehabTbls
        public ActionResult Index()
        {
            return View(db.GoaRehabTbls.ToList());
        }

        // GET: GoaRehabTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoaRehabTbl goaRehabTbl = db.GoaRehabTbls.Find(id);
            if (goaRehabTbl == null)
            {
                return HttpNotFound();
            }
            return View(goaRehabTbl);
        }

        // GET: GoaRehabTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GoaRehabTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Desc,Addr,Mission,Vision,Location,Ph_No,File_Name")] GoaRehabTbl goaRehabTbl)
        {
            if (ModelState.IsValid)
            {
                db.GoaRehabTbls.Add(goaRehabTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(goaRehabTbl);
        }

        // GET: GoaRehabTbls/Edit/5
        public ActionResult EditMission(int? id)
        {
            id = 1;
            GoaRehabTbl goaRehabTbl = db.GoaRehabTbls.Find(id);
            if (goaRehabTbl == null)
            {
                return HttpNotFound();
            }
            GoaRehabImg ViewInfo = new GoaRehabImg
            {
                Id = goaRehabTbl.Id,
                Mission = goaRehabTbl.Mission,
                Vision = goaRehabTbl.Vision
            };
            return View(ViewInfo);
        }

        public ActionResult EditVision(int? id)
        {
            id = 1;
            GoaRehabTbl goaRehabTbl = db.GoaRehabTbls.Find(id);
            if (goaRehabTbl == null)
            {
                return HttpNotFound();
            }
            GoaRehabImg ViewInfo = new GoaRehabImg
            {
                Id = goaRehabTbl.Id,
                Mission = goaRehabTbl.Mission,
                Vision = goaRehabTbl.Vision
            };
            return View(ViewInfo);
        }

        public ActionResult EditStatutes(int? id)
        {
            id = 1;
            GoaRehabTbl goaRehabTbl = db.GoaRehabTbls.Find(id);
            if(goaRehabTbl.Statutes == null)
            {
                ViewBag.ExistingDoc = "No Existing File";
            }
            else
            {
                ViewBag.ExistingDoc = goaRehabTbl.Statutes;
            }
            if (goaRehabTbl == null)
            {
                return HttpNotFound();
            }
            GoaRehabImg ViewInfo = new GoaRehabImg
            {
                Id = goaRehabTbl.Id
            };
            return View(ViewInfo);
        }

        // POST: GoaRehabTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Title,Desc,Addr,Mission,Vision,Location,Ph_No,File_Name")] GoaRehabTbl goaRehabTbl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(goaRehabTbl).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(goaRehabTbl);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditVision([Bind(Include = "Id,Vision")] GoaRehabImg goaRehabTbl)
        {
            //if (ModelState.IsValid)
            //{
            var existingRec = db.GoaRehabTbls.Find(1);

            existingRec.Mission = goaRehabTbl.Vision;

            db.Entry(existingRec).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            //}
            //return View(goaRehabTbl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMission([Bind(Include = "Id,Mission")] GoaRehabImg goaRehabTbl)
        {
            var existingRec = db.GoaRehabTbls.Find(1);

            existingRec.Mission = goaRehabTbl.Mission;            

            db.Entry(existingRec).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStatutes([Bind(Include = "Id, UploadedFile")] GoaRehabImg goaRehabTbl, string filename)
        {
            //if (ModelState.IsValid)
            //{
            string fn = "";
            var existingRec = db.GoaRehabTbls.Find(1);
            //GoaRehabTbl goaRehab = new GoaRehabTbl
            //{
            //    Id = goaRehabTbl.Id
            //};

                if (goaRehabTbl.UploadedFile != null)
                {
                    fn = goaRehabTbl.UploadedFile.FileName.Substring(goaRehabTbl.UploadedFile.FileName.LastIndexOf('\\') + 1);
                    fn = goaRehabTbl.Id + "_" + fn;
                    string SavePath = System.IO.Path.Combine(Server.MapPath("~/Uploads/Documents/"), fn);
                    goaRehabTbl.UploadedFile.SaveAs(SavePath);
                    existingRec.Statutes = fn;
                }
                else
                {
                    existingRec.Statutes = filename;
                }

                db.Entry(existingRec).State = EntityState.Modified;
                db.SaveChanges();
            return RedirectToAction("Index");
            //}
            //return View(goaRehabTbl);
        }

        // GET: GoaRehabTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoaRehabTbl goaRehabTbl = db.GoaRehabTbls.Find(id);
            if (goaRehabTbl == null)
            {
                return HttpNotFound();
            }
            return View(goaRehabTbl);
        }

        // POST: GoaRehabTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GoaRehabTbl goaRehabTbl = db.GoaRehabTbls.Find(id);
            db.GoaRehabTbls.Remove(goaRehabTbl);
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
