using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Studentdetail1;
using Studentdetail1.Data;

namespace Studentdetail1.Controllers
{
    public class Student_Table1Controller : Controller
    {
        private Studentdetail1Context db = new Studentdetail1Context();

        // GET: Student_Table1
        public ActionResult Index()
        {
            return View(db.Student_Table1.ToList());
        }

        public ActionResult Searching(string Searchby, string search)
        {
            if (Searchby == "Class")
            {
                var model = db.Student_Table1.Where(emp => emp.Class == search || search == null).ToList();
                return View(model);

            }
            else
            {
                var model = db.Student_Table1.Where(emp => emp.Subject.StartsWith(search) || search == null).ToList();
                return View(model);
            }
        }
        // GET: Student_Table1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Table1 student_Table1 = db.Student_Table1.Find(id);
            if (student_Table1 == null)
            {
                return HttpNotFound();
            }
            return View(student_Table1);
        }

        // GET: Student_Table1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student_Table1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,First_Name,Last_Name,Class,Subject,Marks")] Student_Table1 student_Table1)
        {
            if (ModelState.IsValid)
            {
                db.Student_Table1.Add(student_Table1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student_Table1);
        }

        // GET: Student_Table1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Table1 student_Table1 = db.Student_Table1.Find(id);
            if (student_Table1 == null)
            {
                return HttpNotFound();
            }
            return View(student_Table1);
        }

        // POST: Student_Table1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,First_Name,Last_Name,Class,Subject,Marks")] Student_Table1 student_Table1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Table1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student_Table1);
        }

        // GET: Student_Table1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Table1 student_Table1 = db.Student_Table1.Find(id);
            if (student_Table1 == null)
            {
                return HttpNotFound();
            }
            return View(student_Table1);
        }

        // POST: Student_Table1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Table1 student_Table1 = db.Student_Table1.Find(id);
            db.Student_Table1.Remove(student_Table1);
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
