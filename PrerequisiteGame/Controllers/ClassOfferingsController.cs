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
    public class ClassOfferingsController : Controller
    {
        private ClassContext db = new ClassContext();

        // GET: ClassOfferings
        public ActionResult Index()
        {
            return View(db.ClassOfferings.ToList());
        }

        public ActionResult Search(string searchString)
        {
            return View(db.ClassOfferings.Where(a => a.CourseCode.Contains(searchString) || a.CourseDescription.Contains(searchString) || a.CourseName.Contains(searchString)));
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

            PreReqModelView PreReqModelView = new PreReqModelView(classOffering);
            PreReqModelView.PrereqFor = db.ClassOfferings.Where(a => a.CourseDescription.Contains(classOffering.CourseCode)).ToList();  //We are getting everything that this class will open up 
            List<ClassOffering> temp = db.ClassOfferings.ToList();
            LinkedList<ClassOffering> theStuff = new LinkedList<ClassOffering>();
            foreach(ClassOffering k in temp) 
            {
                if(classOffering.CourseDescription.Contains(k.CourseCode))
                {
                    theStuff.AddLast(k);
                }
            }
            PreReqModelView.Requires = theStuff.ToList();//We are getting everything that is requires this class to be taken
           //We are getting everything that is requires this class to be taken

            return View(PreReqModelView);
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
