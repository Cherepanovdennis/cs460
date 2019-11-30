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
    public class RACEEVENTsController : Controller
    {
        private RaceEventContext db = new RaceEventContext();

        // GET: RACEEVENTs
        public ActionResult Index()
        {
            var rACEEVENTs = db.RACEEVENTs.Include(r => r.Athlete).Include(r => r.MeetLocation);
            return View(rACEEVENTs.ToList());
        }

        // GET: RACEEVENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RACEEVENT rACEEVENT = db.RACEEVENTs.Find(id);
            if (rACEEVENT == null)
            {
                return HttpNotFound();
            }
            return View(rACEEVENT);
        }

        // GET: RACEEVENTs/Create
        public ActionResult Create()
        {
            ViewBag.ATHLETEID = new SelectList(db.Athletes, "AthleteId", "AthleteName");
            ViewBag.LOCATIONID = new SelectList(db.MeetLocations, "LocationID", "NLocation");
            return View();
        }

        // POST: RACEEVENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DISTANCE,LOCATIONID,ATHLETEID,RACETIME")] RACEEVENT rACEEVENT)
        {
            if (ModelState.IsValid)
            {
                db.RACEEVENTs.Add(rACEEVENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ATHLETEID = new SelectList(db.Athletes, "AthleteId", "AthleteName", rACEEVENT.ATHLETEID);
            ViewBag.LOCATIONID = new SelectList(db.MeetLocations, "LocationID", "NLocation", rACEEVENT.LOCATIONID);
            return View(rACEEVENT);
        }

        // GET: RACEEVENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RACEEVENT rACEEVENT = db.RACEEVENTs.Find(id);
            if (rACEEVENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.ATHLETEID = new SelectList(db.Athletes, "AthleteId", "AthleteName", rACEEVENT.ATHLETEID);
            ViewBag.LOCATIONID = new SelectList(db.MeetLocations, "LocationID", "NLocation", rACEEVENT.LOCATIONID);
            return View(rACEEVENT);
        }

        // POST: RACEEVENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DISTANCE,LOCATIONID,ATHLETEID,RACETIME")] RACEEVENT rACEEVENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rACEEVENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ATHLETEID = new SelectList(db.Athletes, "AthleteId", "AthleteName", rACEEVENT.ATHLETEID);
            ViewBag.LOCATIONID = new SelectList(db.MeetLocations, "LocationID", "NLocation", rACEEVENT.LOCATIONID);
            return View(rACEEVENT);
        }

        // GET: RACEEVENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RACEEVENT rACEEVENT = db.RACEEVENTs.Find(id);
            if (rACEEVENT == null)
            {
                return HttpNotFound();
            }
            return View(rACEEVENT);
        }

        // POST: RACEEVENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RACEEVENT rACEEVENT = db.RACEEVENTs.Find(id);
            db.RACEEVENTs.Remove(rACEEVENT);
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
