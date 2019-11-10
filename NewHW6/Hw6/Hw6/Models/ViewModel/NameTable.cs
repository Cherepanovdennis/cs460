using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hw6.Models.ViewModel
{
    public class NameTable
    {
        public List<string> Names { get; set; }
        public NameTable(List<string> name)
        {
            Names = new List<string>();
            foreach (string Name in name)
            {

                Names.Add(Name);
            }
        }




    }
}