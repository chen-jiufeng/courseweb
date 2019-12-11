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
    public class ClasController : Controller
    {
        private CourseMangeEntities db = new CourseMangeEntities();

        //
        // GET: /Clas/

        public ViewResult Index()
        {
            return View(db.Classes.ToList());
        }

        //
        // GET: /Clas/Details/5

        public ViewResult Details(int id)
        {
            Classes classes = db.Classes.Find(id);
            return View(classes);
        }

        //
        // GET: /Clas/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Clas/Create

        [HttpPost]
        public ActionResult Create(Classes classes)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(classes);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(classes);
        }
        
        //
        // GET: /Clas/Edit/5
 
        public ActionResult Edit(int id)
        {
            Classes classes = db.Classes.Find(id);
            return View(classes);
        }

        //
        // POST: /Clas/Edit/5

        [HttpPost]
        public ActionResult Edit(Classes classes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classes);
        }

        //
        // GET: /Clas/Delete/5
 
        public ActionResult Delete(int id)
        {
            Classes classes = db.Classes.Find(id);
            return View(classes);
        }

        //
        // POST: /Clas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Classes classes = db.Classes.Find(id);
            db.Classes.Remove(classes);
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