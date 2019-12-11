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
    public class TeacherController : Controller
    {
        private CourseMangeEntities db = new CourseMangeEntities();

        //
        // GET: /Teacher/

        public ViewResult Index()
        {
            return View(db.Teachers.ToList());
        }

        //
        // GET: /Teacher/Details/5

        public ViewResult Details(int id)
        {
            Teachers teachers = db.Teachers.Find(id);
            return View(teachers);
        }

        //
        // GET: /Teacher/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Teacher/Create

        [HttpPost]
        public ActionResult Create(Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teachers);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(teachers);
        }
        
        //
        // GET: /Teacher/Edit/5
 
        public ActionResult Edit(int id)
        {
            Teachers teachers = db.Teachers.Find(id);
            return View(teachers);
        }

        //
        // POST: /Teacher/Edit/5

        [HttpPost]
        public ActionResult Edit(Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teachers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teachers);
        }

        //
        // GET: /Teacher/Delete/5
 
        public ActionResult Delete(int id)
        {
            Teachers teachers = db.Teachers.Find(id);
            return View(teachers);
        }

        //
        // POST: /Teacher/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Teachers teachers = db.Teachers.Find(id);
            db.Teachers.Remove(teachers);
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