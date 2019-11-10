using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace HW6.Models.ViewModel
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




        }
        public string StockItemName { get; private set; }

        public string ItemSize { get; private set; }

        public decimal? ReccomendedPrice { get; private set; }

        public decimal ProductWeight { get; private set; }

        public int LeadTimeDays { get; private set; }

        public DateTime ValidSince { get; private set; }

        public string CountryOrigin{ get; private set; }

        public string Tags { get; private set; }

        public byte[] Photo { get; private set; }



    }
}