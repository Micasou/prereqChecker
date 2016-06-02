﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrerequisiteGame.Models;

namespace PrerequisiteGame.Controllers
{
    public class ClassOfferingsController : Controller
    {
        private ClassContext db = new ClassContext();

        // GET: ClassOfferings
        public ActionResult Index()
        {
            return View(db.ClassOfferings.ToList());
        }

        // GET: ClassOfferings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassOffering classOffering = db.ClassOfferings.Find(id);
            if (classOffering == null)
            {
                return HttpNotFound();
            }
            return View(classOffering);
        }

        // GET: ClassOfferings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassOfferings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassOfferingID,CID,CourseCode,CourseName,CourseDescription")] ClassOffering classOffering)
        {
            if (ModelState.IsValid)
            {
                db.ClassOfferings.Add(classOffering);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classOffering);
        }

        // GET: ClassOfferings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassOffering classOffering = db.ClassOfferings.Find(id);
            if (classOffering == null)
            {
                return HttpNotFound();
            }
            return View(classOffering);
        }

        // POST: ClassOfferings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassOfferingID,CID,CourseCode,CourseName,CourseDescription")] ClassOffering classOffering)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classOffering).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classOffering);
        }

        // GET: ClassOfferings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassOffering classOffering = db.ClassOfferings.Find(id);
            if (classOffering == null)
            {
                return HttpNotFound();
            }
            return View(classOffering);
        }

        // POST: ClassOfferings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassOffering classOffering = db.ClassOfferings.Find(id);
            db.ClassOfferings.Remove(classOffering);
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