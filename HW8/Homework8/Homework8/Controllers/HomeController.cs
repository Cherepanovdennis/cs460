using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework8.Models;
using Newtonsoft.Json;


namespace Homework8.Controllers
{
    public class HomeController : Controller
    {
        private RaceEventContext db = new RaceEventContext();

        [HttpGet]
        public ActionResult Index()
        {


            if(Request.QueryString["Teams"] == null)
            {
                ViewBag.Sucess = false;
                ViewBag.teams = new SelectList(db.Teams, "TeamName", "TeamName");
                List<string> Teams = db.Teams.Select(item => item.TeamName).ToList();
                Graph newteams = new Graph(Teams);
                return View(newteams);
            }
            string team = Request.QueryString["Teams"].ToString();
            int key = db.Teams.Where(item => item.TeamName == team).Select(item => item.TeamID).First();
            List<string> athletes = db.Athletes.Where(item => item.TeamID == key).Select(item => item.AthleteName).ToList();
            Graph athletenames = new Graph(athletes);
            return View(athletenames);

        }

        public ActionResult convert()
        {
            if (Request.QueryString["athlete"] == null)
            {
                return View();
            }

            string athlete = Request.QueryString["athlete"].ToString();
            string distance = Request.QueryString["distance"].ToString();

            int athletekey = db.Athletes.Where(item => item.AthleteName == athlete).Select(item => item.AthleteId).First();

            List<DateTime> dates = db.RACEEVENTs.Where(item => item.ATHLETEID == athletekey && item.DISTANCE == distance)
                .Select(item => item.MeetLocation.MeetDate).ToList();

            List<float> times = db.RACEEVENTs.Where(item => item.ATHLETEID == athletekey && item.DISTANCE == distance)
                .Select(item => item.RACETIME).ToList();
            List<JsonDate> values = new List<JsonDate>();


            for (int i = 0; i < times.Count(); i++)
            {
                values.Add(new JsonDate { dates = dates.ElementAt(i), time = times.ElementAt(i) });
            }


            return new ContentResult
            {
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8,
                Content = JsonConvert.SerializeObject(values)
            };
        }





        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}