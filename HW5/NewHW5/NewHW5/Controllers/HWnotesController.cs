using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewHW5.DAL;
using NewHW5.Models;

namespace NewHW5.Controllers
{
    public class HWnotesController : Controller
    {
        private NotesContext db = new NotesContext();

        // GET: HWnotes
        public ActionResult Index()
        {
            return View(db.Notes.ToList());
        }

        // GET: HWnotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HWnotes hWnotes = db.Notes.Find(id);
            if (hWnotes == null)
            {
                return HttpNotFound();
            }
            return View(hWnotes);
        }

        // GET: HWnotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HWnotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DueDate,DueTime,HomeworkTitle,Priority,Department,CourseNumber,Notes")] HWnotes hWnotes)
        {
            if (ModelState.IsValid)
            {
                db.Notes.Add(hWnotes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hWnotes);
        }

        // GET: HWnotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HWnotes hWnotes = db.Notes.Find(id);
            if (hWnotes == null)
            {
                return HttpNotFound();
            }
            return View(hWnotes);
        }

        // POST: HWnotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DueDate,DueTime,HomeworkTitle,Priority,Department,CourseNumber,Notes")] HWnotes hWnotes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hWnotes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hWnotes);
        }

        // GET: HWnotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HWnotes hWnotes = db.Notes.Find(id);
            if (hWnotes == null)
            {
                return HttpNotFound();
            }
            return View(hWnotes);
        }

        // POST: HWnotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HWnotes hWnotes = db.Notes.Find(id);
            db.Notes.Remove(hWnotes);
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
        public enum Priority
        {
            Low,
            Medium, 
            High
        }
    }
}
