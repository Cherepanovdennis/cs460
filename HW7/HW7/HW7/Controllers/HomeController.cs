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
using Newtonsoft.Json;

namespace HW7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string token = System.IO.File.ReadAllText(@"C:\Users\Dennis\Desktop\Token.txt");
            string uri = "https://api.github.com/user";
            string uriRepos = "https://api.github.com/user/repos";
            string data = SendRequest(uri, token, "Cherepanovdennis");
            string repo = SendRequest(uriRepos, token, "Cherepanovdennis");
            JObject obj = JObject.Parse(data);
            JArray repos = JArray.Parse(repo);
            gitInfo userinfo = new gitInfo(obj,repos);

            return View(userinfo);
        }

        public ActionResult CommitHistory()
        {
            string user, repo;
            user = Request.QueryString["user"];
            repo = Request.QueryString["repo"];
            string token = System.IO.File.ReadAllText(@"C:\Users\Dennis\Desktop\Token.txt");
            string uri = "https://api.github.com/repos/" + user + "/" + repo + "/commits";
            string CommitHistory = SendRequest(uri, token, user);
            JArray JsonCommit = JArray.Parse(CommitHistory);
            int count = JsonCommit.Count;
            List<CommitInfo> CommitInformation = new List<CommitInfo>();
            for(int i = 0; i < count; i++)
            {
                CommitInformation.Add(new CommitInfo() { 
                    Hash = (string)JsonCommit[i]["sha"], 
                    CommitUri = (string)JsonCommit[i]["html_url"], 
                    CommitDateTime = (string)JsonCommit[i]["commit"]["committer"]["date"], 
                    CommitMessage = (string)JsonCommit[i]["commit"]["message"],
                    WhoCommited = (string)JsonCommit[i]["commit"]["committer"]["name"]});

            }

            return new ContentResult
            {
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8,
                Content = JsonConvert.SerializeObject(CommitInformation)


            };

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
