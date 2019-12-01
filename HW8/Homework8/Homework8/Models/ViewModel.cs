using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework8.Models
{
    public class ViewModel
    {

        public List<AthleteDetails> NewDetails {get; set;}

        public ViewModel(List<AthleteDetails> input)
        {
            NewDetails = new List<AthleteDetails>();
            NewDetails = input;
        }
    }
}