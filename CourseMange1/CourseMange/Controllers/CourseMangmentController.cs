using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseMange.Models;

namespace CourseMange.Controllers
{ 
    public class Default1Controller : Controller
    {
        private CourseMangeEntities db = new CourseMangeEntities();

        //
        // GET: /Default1/

        public ViewResult Index()
        {
            return View(db.CouresMangments.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ViewResult Details(int id)
        {
            CouresMangments couresmangments = db.CouresMangments.Find(id);
            return View(couresmangments);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            var classes = db.Classes.ToList();
            ViewBag.Classes = classes;

            var Teachers = db.Teachers.ToList();
            ViewBag.Teachers = Teachers;

            var Course = db.Course.ToList();
            ViewBag.course = Course;

            return View();
        } 

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(CouresMangments couresmangments)
        {
            if (ModelState.IsValid)
            {
                db.CouresMangments.Add(couresmangments);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(couresmangments);
        }
        
        //
        // GET: /Default1/Edit/5
 
        public ActionResult Edit(int id)
        {
            CouresMangments couresmangments = db.CouresMangments.Find(id);
            return View(couresmangments);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(CouresMangments couresmangments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(couresmangments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(couresmangments);
        }

        //
        // GET: /Default1/Delete/5
 
        public ActionResult Delete(int id)
        {
            CouresMangments couresmangments = db.CouresMangments.Find(id);
            return View(couresmangments);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            CouresMangments couresmangments = db.CouresMangments.Find(id);
            db.CouresMangments.Remove(couresmangments);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}