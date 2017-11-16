﻿using System;
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
    public class InmatesTblsController : Controller
    {
        private GoaRehabEntities db = new GoaRehabEntities();

        // GET: InmatesTbls
        public ActionResult Index()
        {
            var inmatesTbls = db.InmatesTbls.Include(i => i.ProjectsTbl);
            return View(inmatesTbls.ToList());
        }

        // GET: InmatesTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InmatesTbl inmatesTbl = db.InmatesTbls.Find(id);
            if (inmatesTbl == null)
            {
                return HttpNotFound();
            }
            return View(inmatesTbl);
        }

        // GET: InmatesTbls/Create
        public ActionResult Create()
        {
            ViewBag.Proj_Id = new SelectList(db.ProjectsTbls, "Proj_Id", "Proj_Title");
            return View();
        }

        // POST: InmatesTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "In_Id,In_Name,In_Addr,In_MNo,Gender,Proj_Id")] InmatesTbl inmatesTbl)
        {
            if (ModelState.IsValid)
            {
                db.InmatesTbls.Add(inmatesTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Proj_Id = new SelectList(db.ProjectsTbls, "Proj_Id", "Proj_Title", inmatesTbl.Proj_Id);
            return View(inmatesTbl);
        }

        // GET: InmatesTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InmatesTbl inmatesTbl = db.InmatesTbls.Find(id);
            if (inmatesTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Proj_Id = new SelectList(db.ProjectsTbls, "Proj_Id", "Proj_Title", inmatesTbl.Proj_Id);
            return View(inmatesTbl);
        }

        // POST: InmatesTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "In_Id,In_Name,In_Addr,In_MNo,Gender,Proj_Id")] InmatesTbl inmatesTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inmatesTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Proj_Id = new SelectList(db.ProjectsTbls, "Proj_Id", "Proj_Title", inmatesTbl.Proj_Id);
            return View(inmatesTbl);
        }

        // GET: InmatesTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InmatesTbl inmatesTbl = db.InmatesTbls.Find(id);
            if (inmatesTbl == null)
            {
                return HttpNotFound();
            }
            return View(inmatesTbl);
        }

        // POST: InmatesTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InmatesTbl inmatesTbl = db.InmatesTbls.Find(id);
            db.InmatesTbls.Remove(inmatesTbl);
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