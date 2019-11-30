using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework8.Models;

namespace Homework8.Controllers
{
    public class MeetLocationsController : Controller
    {
        private RaceEventContext db = new RaceEventContext();

        // GET: MeetLocations
        public ActionResult Index()
        {
            return View(db.MeetLocations.ToList());
        }

        // GET: MeetLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetLocation meetLocation = db.MeetLocations.Find(id);
            if (meetLocation == null)
            {
                return HttpNotFound();
            }
            return View(meetLocation);
        }

        // GET: MeetLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MeetLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocationID,NLocation,MeetDate")] MeetLocation meetLocation)
        {
            if (ModelState.IsValid)
            {
                db.MeetLocations.Add(meetLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meetLocation);
        }

        // GET: MeetLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetLocation meetLocation = db.MeetLocations.Find(id);
            if (meetLocation == null)
            {
                return HttpNotFound();
            }
            return View(meetLocation);
        }

        // POST: MeetLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationID,NLocation,MeetDate")] MeetLocation meetLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meetLocation);
        }

        // GET: MeetLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetLocation meetLocation = db.MeetLocations.Find(id);
            if (meetLocation == null)
            {
                return HttpNotFound();
            }
            return View(meetLocation);
        }

        // POST: MeetLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeetLocation meetLocation = db.MeetLocations.Find(id);
            db.MeetLocations.Remove(meetLocation);
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
