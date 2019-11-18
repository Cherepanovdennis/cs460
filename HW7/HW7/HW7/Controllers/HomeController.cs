using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW7.Models;

namespace HW7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string token = System.IO.File.ReadAllText(@"C:\Users\Dennis\Desktop\Token.txt");
            string uri = "https://api.github.com/user";
            string data = SendRequest(uri, token, "Cherepanovdennis");
            JObject obj = JObject.Parse(data);
            gitInfo userinfo = new gitInfo(obj);

            return View(userinfo);
        }

        public JsonResult Gimme(int? id = 100)
        {
            Random gen = new Random();
            var data = new
            {
                message = "Random Numbers API",
                num = (int)id,
                numbers1 = Enumerable.Range(1, (int)id),
                numbers = Enumerable.Range(1, (int)id).Select(x => gen.Next(1000))
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GitToken()
        {


            var json = new
            {
                X = 5,
                y= 2,
               seven = 2
            };
            return Json(json, JsonRequestBehavior.AllowGet);




        }



        // GET air quality data from: https://docs.openaq.org/

        private string SendRequest(string uri, string credentials, string username)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", "token " + credentials);
            request.UserAgent = username;       // Required, see: https://developer.github.com/v3/#user-agent-required
            request.Accept = "application/json";

            string jsonString = null;
            // TODO: You should handle exceptions here
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }
    }
}
