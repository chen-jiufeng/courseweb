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
    public class bookController : Controller
    {
        private CourseMangeEntities db = new CourseMangeEntities();

        //
        // GET: /book/

        public ViewResult Index()
        {
            return View(db.books.ToList());
        }

        //
        // GET: /book/Details/5

        public ViewResult Details(int id)
        {
            books books = db.books.Find(id);
            return View(books);
        }

        //
        // GET: /book/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /book/Create

        [HttpPost]
        public ActionResult Create(books books)
        {
            if (ModelState.IsValid)
            {
                db.books.Add(books);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(books);
        }
        
        //
        // GET: /book/Edit/5
 
        public ActionResult Edit(int id)
        {
            books books = db.books.Find(id);
            return View(books);
        }

        //
        // POST: /book/Edit/5

        [HttpPost]
        public ActionResult Edit(books books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(books);
        }

        //
        // GET: /book/Delete/5
 
        public ActionResult Delete(int id)
        {
            books books = db.books.Find(id);
            return View(books);
        }

        //
        // POST: /book/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            books books = db.books.Find(id);
            db.books.Remove(books);
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