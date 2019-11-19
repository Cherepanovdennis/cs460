using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace HW7.Models
{
    public class gitInfo
    {
        public gitInfo(JObject userData, JArray repos)
        {
            name = (string)userData["name"];
            username = (string)userData["login"];
            email = (string)userData["email"];
            photouri = (string)userData["avatar_url"];
            user_homepage = (string)userData["html_url"];
            size = repos.Count;
            Reponame = new List<string>();
            Repofullname = new List<string>();
            login = new List<string>();
            RepoURL = new List<string>();
            PhotoUrl = new List<string>();
            updatedat = new List<string>();
            for (int i = 0; i < size; i++)
            {
                Reponame.Add((string)repos[i]["name"]);
                Repofullname.Add((string)repos[i]["full_name"]);
                login.Add((string)repos[i]["owner"]["login"]);
                RepoURL.Add((string)repos[i]["html_url"]);
                PhotoUrl.Add((string)repos[i]["owner"]["avatar_url"]);
                updatedat.Add((string)repos[i]["updated_at"]);


            }

        }

        public string name { get; private set; }

        public string username { get; private set; }
        public string email { get; private set; }

        public string photouri { get; private set; }

        public string user_homepage { get; private set; }

        public List<string> Reponame { get; private set; }
        public List<string> Repofullname { get; private set; }
        public List<string> login { get; private set; }
        public List<string> RepoURL { get; private set; }
        public List<string> PhotoUrl { get; private set; }

        public List<string> updatedat { get; private set; }

        public int size { get; private set; }







    }
}