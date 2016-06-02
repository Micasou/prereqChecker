using System;
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
    public class CurrentClassOfferingsController : Controller
    {
        private ClassContext db = new ClassContext();

        // GET: CurrentClassOfferings
        public ActionResult Index()
        {
            var currentClassOfferings = db.CurrentClassOfferings.Include(c => c.ClassOffering);
            return View(currentClassOfferings.ToList());
        }

        // GET: CurrentClassOfferings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentClassOffering currentClassOffering = db.CurrentClassOfferings.Find(id);
            if (currentClassOffering == null)
            {
                return HttpNotFound();
            }
            return View(currentClassOffering);
        }

        // GET: CurrentClassOfferings/Create
        public ActionResult Create()
        {
            ViewBag.CID = new SelectList(db.ClassOfferings, "ClassOfferingID", "CourseCode");
            return View();
        }

        // POST: CurrentClassOfferings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CurrentClassOfferingID,CID,Quarter,Year,timeOffered")] CurrentClassOffering currentClassOffering)
        {
            if (ModelState.IsValid)
            {
                db.CurrentClassOfferings.Add(currentClassOffering);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CID = new SelectList(db.ClassOfferings, "ClassOfferingID", "CourseCode", currentClassOffering.CID);
            return View(currentClassOffering);
        }

        // GET: CurrentClassOfferings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentClassOffering currentClassOffering = db.CurrentClassOfferings.Find(id);
            if (currentClassOffering == null)
            {
                return HttpNotFound();
            }
            ViewBag.CID = new SelectList(db.ClassOfferings, "ClassOfferingID", "CourseCode", currentClassOffering.CID);
            return View(currentClassOffering);
        }

        // POST: CurrentClassOfferings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CurrentClassOfferingID,CID,Quarter,Year,timeOffered")] CurrentClassOffering currentClassOffering)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currentClassOffering).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CID = new SelectList(db.ClassOfferings, "ClassOfferingID", "CourseCode", currentClassOffering.CID);
            return View(currentClassOffering);
        }

        // GET: CurrentClassOfferings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentClassOffering currentClassOffering = db.CurrentClassOfferings.Find(id);
            if (currentClassOffering == null)
            {
                return HttpNotFound();
            }
            return View(currentClassOffering);
        }

        // POST: CurrentClassOfferings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CurrentClassOffering currentClassOffering = db.CurrentClassOfferings.Find(id);
            db.CurrentClassOfferings.Remove(currentClassOffering);
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
