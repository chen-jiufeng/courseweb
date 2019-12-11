using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseMange.Models;

namespace CourseMange.Models
{ 
    public class StudentController : Controller
    {
        private CourseMangeEntities db = new CourseMangeEntities();

        //
        // GET: /Student/

        public ViewResult Index()
        {
            return View(db.students.ToList());
        }

        //
        // GET: /Student/Details/5

        public ViewResult Details(int id)
        {
            students students = db.students.Find(id);
            return View(students);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(students students)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(students);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(students);
        }
        
        //
        // GET: /Student/Edit/5
 
        public ActionResult Edit(int id)
        {
            students students = db.students.Find(id);
            return View(students);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(students students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        //
        // GET: /Student/Delete/5
 
        public ActionResult Delete(int id)
        {
            students students = db.students.Find(id);
            return View(students);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            students students = db.students.Find(id);
            db.students.Remove(students);
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