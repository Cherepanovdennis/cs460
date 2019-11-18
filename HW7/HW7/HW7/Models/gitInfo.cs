using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace HW7.Models
{
    public class gitInfo
    {
        public gitInfo(JObject information)
        {
            name = (string)information["name"];
            username = (string)information["login"];
            email = (string)information["email"];
            photouri = (string)information["avatar_url"];
            user_homepage = (string)information["html_url"];
        }

        public string name {get; private set;}

        public string username { get; private set; }
        public string email { get; private set; }

        public string photouri { get; private set; }

        public string user_homepage { get; private set; }






    }
}