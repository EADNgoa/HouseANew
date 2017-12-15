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
    public class ProjectsTblsController : EAController
    {
        

        // GET: ProjectsTbls
        public ActionResult Index()
        {            
            return View(db.ProjectsTbls.ToList());
        }

        // GET: ProjectsTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsTbl projectsTbl = db.ProjectsTbls.Find(id);
            if (projectsTbl == null)
            {
                return HttpNotFound();
            }
            return View(projectsTbl);
        }

        // GET: ProjectsTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectsTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Proj_Id,Proj_Title,Proj_Desc,Proj_Status, UploadedFile")] ProjectsImg projectsTbl)
        {
            if (ModelState.IsValid)
            {
                ProjectsTbl pt = new ProjectsTbl
                {
                    Proj_Id=projectsTbl.Proj_Id,
                    Proj_Desc=projectsTbl.Proj_Desc,
                    Proj_Status=projectsTbl.Proj_Status,
                    Proj_Title=projectsTbl.Proj_Title                 
                };

                if (projectsTbl.UploadedFile !=null)
                {
                    string fn = projectsTbl.UploadedFile.FileName.Substring(projectsTbl.UploadedFile.FileName.LastIndexOf('\\') + 1);
                    Random rd = new Random(DateTime.Today.Day);
                    fn = rd.Next(300,800) + "_" + fn;
                    string SavePath = System.IO.Path.Combine(Server.MapPath("~/Uploads/Pictures/Projects"), fn);
                    projectsTbl.UploadedFile.SaveAs(SavePath);
                    pt.Proj_Pic = fn;    
                } 

                    db.ProjectsTbls.Add(pt);
                    db.SaveChanges();
                
                return RedirectToAction("Index");
            }

            return View(projectsTbl);
        }

        // GET: ProjectsTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsTbl projectsTbl = db.ProjectsTbls.Find(id);
            ViewBag.ExistingImg = projectsTbl.Proj_Pic;
            if (projectsTbl == null)
            {
                return HttpNotFound();
            }

            ProjectsImg ViewInfo = new ProjectsImg
            {
                Proj_Id = projectsTbl.Proj_Id,
                Proj_Desc = projectsTbl.Proj_Desc,
                Proj_Status = projectsTbl.Proj_Status,
                Proj_Title = projectsTbl.Proj_Title
            };
            ViewBag.ExistingFile = projectsTbl.Proj_Pic;
            return View(ViewInfo);
        }

        // POST: ProjectsTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Proj_Id,Proj_Title,Proj_Desc,Proj_Status, UploadedFile")] ProjectsImg projectsTbl, string Proj_Pic)
        {
            if (ModelState.IsValid)
            {
                string fn = "";

                ProjectsTbl pt = new ProjectsTbl
                {
                    Proj_Id = projectsTbl.Proj_Id,
                    Proj_Desc = projectsTbl.Proj_Desc,
                    Proj_Status = projectsTbl.Proj_Status,
                    Proj_Title = projectsTbl.Proj_Title                  
                };

                if (projectsTbl.UploadedFile != null)
                {
                    fn = projectsTbl.UploadedFile.FileName.Substring(projectsTbl.UploadedFile.FileName.LastIndexOf('\\') + 1);
                    fn = projectsTbl.Proj_Id + "_" + fn;
                    string SavePath = System.IO.Path.Combine(Server.MapPath("~/Uploads/Pictures/Projects"), fn);
                    projectsTbl.UploadedFile.SaveAs(SavePath);
                    pt.Proj_Pic = fn;
                }
                else {
                    pt.Proj_Pic = Proj_Pic;
                }
                
                db.Entry(pt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectsTbl);
        }

        // GET: ProjectsTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsTbl projectsTbl = db.ProjectsTbls.Find(id);
            if (projectsTbl == null)
            {
                return HttpNotFound();
            }
            return View(projectsTbl);
        }

        // POST: ProjectsTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectsTbl projectsTbl = db.ProjectsTbls.Find(id);
            db.ProjectsTbls.Remove(projectsTbl);
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
