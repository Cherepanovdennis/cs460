using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework8.Models;


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


        public ActionResult Athlete()
        {
            return View();
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