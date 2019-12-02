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
    public class AthletesController : Controller
    {
        private RaceEventContext db = new RaceEventContext();

        // GET: Athletes
        public ActionResult Index()
        {
            var athletes = db.Athletes.Include(a => a.Team);
            return View(athletes.ToList());
        }

        // GET: Athletes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Athlete athlete = db.Athletes.Find(id);

            List<string> Distance = db.RACEEVENTs.Where(item => item.ATHLETEID == id).Select(item => item.DISTANCE).ToList();
            
            List<int> IntDistance = Distance.Select(int.Parse).ToList();
            List<MeetLocation> query1 = db.RACEEVENTs.Where(item => item.ATHLETEID == id).Select(item=> item.MeetLocation).ToList();
            
            List<string> MeetName = query1.Select(item => item.NLocation).ToList();
            List<DateTime> dates = query1.Select(item => item.MeetDate).ToList();
            List<float> time = db.RACEEVENTs.Where(item => item.ATHLETEID == id).Select(item => item.RACETIME).ToList();

            List<AthleteDetails> Details = new List<AthleteDetails>();

            for(int i = 0; i < query1.Count(); i++)
            {
                Details.Add(new AthleteDetails 
                { Distance = IntDistance.ElementAt(i), Location = MeetName.ElementAt(i), 
                    LocationDate = dates.ElementAt(i), Time = time.ElementAt(i) });

            }

            Details = Details.OrderByDescending(item => item.LocationDate).ThenByDescending(item => item.Distance).ToList();

            ViewModel Vm = new ViewModel(Details);
;
            if (athlete == null)
            {
                return HttpNotFound();
            }
            return View(Vm);
        }

        // GET: Athletes/Create
        public ActionResult Create()
        {
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName");
            return View();
        }

        // POST: Athletes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AthleteId,AthleteName,AthleteGender,TeamID")] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                db.Athletes.Add(athlete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", athlete.TeamID);
            return View(athlete);
        }

        // GET: Athletes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Athlete athlete = db.Athletes.Find(id);
            if (athlete == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", athlete.TeamID);
            return View(athlete);
        }

        // POST: Athletes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AthleteId,AthleteName,AthleteGender,TeamID")] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(athlete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", athlete.TeamID);
            return View(athlete);
        }

        // GET: Athletes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Athlete athlete = db.Athletes.Find(id);
            if (athlete == null)
            {
                return HttpNotFound();
            }
            return View(athlete);
        }

        // POST: Athletes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Athlete athlete = db.Athletes.Find(id);
            db.Athletes.Remove(athlete);
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
