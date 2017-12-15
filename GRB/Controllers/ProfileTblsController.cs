using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GRB.Models;
using System.IO;

namespace GRB.Controllers
{
    public class ProfileTblsController : EAController
    {        

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
        public ActionResult Create([Bind(Include = "P_Id,P_Name,P_Desc,P_Designation, UploadedFile")] ProfilesImg profileTbl)
        {
            if (ModelState.IsValid)
            {
                ProfileTbl pt = new ProfileTbl
                {
                    P_Id=profileTbl.P_Id,
                    P_Name=profileTbl.P_Name,
                    P_Designation=profileTbl.P_Designation,
                    P_Desc=profileTbl.P_Desc,
                };

                if (profileTbl.UploadedFile !=null)
                {
                    string fn = profileTbl.UploadedFile.FileName.Substring(profileTbl.UploadedFile.FileName.LastIndexOf('\\') + 1);
                    Random rd = new Random(DateTime.Today.Day);
                    fn = rd.Next(300,800) + "_" + fn;
                    string SavePath = System.IO.Path.Combine(Server.MapPath("~/Uploads/Pictures/Profiles/"), fn);
                    profileTbl.UploadedFile.SaveAs(SavePath);
                    pt.P_Pic = fn;
                } 


                db.ProfileTbls.Add(pt);
                db.SaveChanges();

                ViewData["FileName"] = pt.P_Pic;
                return RedirectToAction("Index");
            }
            /*if (ModelState.IsValid)
            {
                db.ProfileTbls.Add(profileTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }*/

            return View(profileTbl);
        }

        [AllowAnonymous]
        public ActionResult ProfilesList(int? id)
        {
            if(id != null)
            {
                ViewBag.results = db.ProfileTbls.Find(id);                
            }
            else
            {
                id = db.ProfileTbls.FirstOrDefault().P_Id;
                ViewBag.results = db.ProfileTbls.Find(id);
            }
            return View(db.ProfileTbls.ToList());
        }

        // GET: ProfileTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileTbl profileTbl = db.ProfileTbls.Find(id);
            ViewBag.ExistingImg = profileTbl.P_Pic;
            if (profileTbl == null)
            {
                return HttpNotFound();
            }
            ProfilesImg ViewInfo = new ProfilesImg
            {
                P_Id = profileTbl.P_Id,
                P_Desc = profileTbl.P_Desc,
                P_Name=profileTbl.P_Name,
                P_Designation = profileTbl.P_Designation
            };
            ViewBag.ExistingFile = profileTbl.P_Pic;
            return View(ViewInfo);
            //return View(profileTbl);
        }

        // POST: ProfileTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "P_Id,P_Name,P_Desc,P_Designation, UploadedFile")] ProfilesImg profileTbl,string P_Pic)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(profileTbl).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(profileTbl);
            if (ModelState.IsValid)
            {
                string fn = "";

                ProfileTbl pt = new ProfileTbl
                {
                    P_Id = profileTbl.P_Id,
                    P_Desc = profileTbl.P_Desc,
                    P_Name = profileTbl.P_Name,
                    P_Designation = profileTbl.P_Designation
                };

                if (profileTbl.UploadedFile != null)
                {
                    fn = profileTbl.UploadedFile.FileName.Substring(profileTbl.UploadedFile.FileName.LastIndexOf('\\') + 1);
                    fn = profileTbl.P_Id + "_" + fn;
                    string SavePath = System.IO.Path.Combine(Server.MapPath("~/Uploads/Pictures/Profiles/"), fn);
                    profileTbl.UploadedFile.SaveAs(SavePath);
                    pt.P_Pic = fn;
                }
                else
                {
                    pt.P_Pic = P_Pic;
                }

                db.Entry(pt).State = EntityState.Modified;
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
