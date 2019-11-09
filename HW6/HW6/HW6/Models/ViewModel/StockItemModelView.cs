using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW6.Models.ViewModel
{
    public class StockItemModelView
    {
        public StockItemModelView(StockItem stockItem)
        {



        }
        public string StockItemName { get; private set; }

        public string ItemSize { get; private set; }

        public double ReccomendedPrice { get; private set; }

        public double ProductWeight { get; private set; }

        public int LeadTimeDays { get; private set; }

        public DateTime ValidSince { get; private set; }

        public string CountryOrigin { get; private set; }

        public string[] Tags { get; private set; }

        public byte[] Photo { get; private set; }



    }
}