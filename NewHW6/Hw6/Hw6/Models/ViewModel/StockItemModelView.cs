using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hw6.Models;
using Newtonsoft.Json;

namespace Hw6.Models.ViewModel
{
    public class StockItemModelView
    {

        public StockItemModelView(StockItem stockItem)
        {


            StockItemName = stockItem.StockItemName;
            ItemSize = stockItem.Size;
            ReccomendedPrice = stockItem.RecommendedRetailPrice;
            ProductWeight = stockItem.TypicalWeightPerUnit;
            LeadTimeDays = stockItem.LeadTimeDays;
            ValidSince = stockItem.ValidFrom;
            dynamic json = JsonConvert.DeserializeObject(stockItem.CustomFields);
            CountryOrigin = ((string)json["CountryOfManufacture"]);
            Tags = stockItem.Tags;
            Photo = (stockItem.Photo);

            
            // Supplier
            Supplier supply = stockItem.Supplier;

            Company = supply.SupplierName;
            Phone = supply.PhoneNumber;
            Fax = supply.FaxNumber;
            Contact = supply.Person2.FullName;
            Website = supply.WebsiteURL;




        }
        public string StockItemName { get; private set; }

        public string ItemSize { get; private set; }

        public decimal? ReccomendedPrice { get; private set; }

        public decimal ProductWeight { get; private set; }

        public int LeadTimeDays { get; private set; }

        public DateTime ValidSince { get; private set; }

        public string CountryOrigin { get; private set; }

        public string Tags { get; private set; }

        public byte[] Photo { get; private set; }

        public string Company { get; private set; }

        public string Phone { get; private set; }

        public string Fax { get; private set; }
        public string Website { get; private set; }
        public string Contact { get; private set; }


    }
}