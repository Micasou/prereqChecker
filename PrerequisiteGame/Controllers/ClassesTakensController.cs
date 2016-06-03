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
    public class ClassesTakensController : Controller
    {
        private ClassContext db = new ClassContext();

        // GET: ClassesTakens
        public ActionResult Index()
        {
            var classesTakens = db.ClassesTakens.Include(c => c.CurrentClassOffering).Include(c => c.Student);
            return View(classesTakens.ToList());
        }

        // GET: ClassesTakens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassesTaken classesTaken = db.ClassesTakens.Find(id);
            if (classesTaken == null)
            {
                return HttpNotFound();
            }
            return View(classesTaken);
        }

        // GET: ClassesTakens/Create
        public ActionResult Create()
        {
            ViewBag.CID = new SelectList(db.CurrentClassOfferings, "CurrentClassOfferingID", "timeOffered");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "firstName");
            return View();
        }

        // POST: ClassesTakens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassesTakenID,StudentID,CID,GPA")] ClassesTaken classesTaken)
        {
            if (ModelState.IsValid)
            {
                db.ClassesTakens.Add(classesTaken);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CID = new SelectList(db.CurrentClassOfferings, "CurrentClassOfferingID", "timeOffered", classesTaken.CID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "firstName", classesTaken.StudentID);
            return View(classesTaken);
        }

        // GET: ClassesTakens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassesTaken classesTaken = db.ClassesTakens.Find(id);
            if (classesTaken == null)
            {
                return HttpNotFound();
            }
            ViewBag.CID = new SelectList(db.CurrentClassOfferings, "CurrentClassOfferingID", "timeOffered", classesTaken.CID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "firstName", classesTaken.StudentID);
            return View(classesTaken);
        }

        // POST: ClassesTakens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassesTakenID,StudentID,CID,GPA")] ClassesTaken classesTaken)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classesTaken).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CID = new SelectList(db.CurrentClassOfferings, "CurrentClassOfferingID", "timeOffered", classesTaken.CID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "firstName", classesTaken.StudentID);
            return View(classesTaken);
        }

        // GET: ClassesTakens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassesTaken classesTaken = db.ClassesTakens.Find(id);
            if (classesTaken == null)
            {
                return HttpNotFound();
            }
            return View(classesTaken);
        }

        // POST: ClassesTakens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassesTaken classesTaken = db.ClassesTakens.Find(id);
            db.ClassesTakens.Remove(classesTaken);
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
