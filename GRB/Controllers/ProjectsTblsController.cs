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
    public class ProjectsTblsController : Controller
    {
        private GoaRehabEntities db = new GoaRehabEntities();

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
        public ActionResult Create([Bind(Include = "Proj_Id,Proj_Title,Proj_Desc,Proj_Pic,Proj_Status")] ProjectsTbl projectsTbl)
        {
            if (ModelState.IsValid)
            {
                db.ProjectsTbls.Add(projectsTbl);
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
            if (projectsTbl == null)
            {
                return HttpNotFound();
            }
            return View(projectsTbl);
        }

        // POST: ProjectsTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Proj_Id,Proj_Title,Proj_Desc,Proj_Pic,Proj_Status")] ProjectsTbl projectsTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectsTbl).State = EntityState.Modified;
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
