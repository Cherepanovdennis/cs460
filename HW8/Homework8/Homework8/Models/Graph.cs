using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework8.Models
{
    public class Graph
    {
        public List<string> Teamnames { get; set; }

        public Graph(List<string> teams)
        {
            Teamnames = new List<string>();
            Teamnames = teams;
        }



    }
}