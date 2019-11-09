using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HW6.Models.ViewModel
{
    public class StockItemModelView
    {
        public StockItemModelView(System.Linq.IQueryable<StockItem> stockItem)
        {

            foreach (StockItem Item in stockItem) {
                StockItemName.Add(Item.StockItemName);
                ItemSize.Add(Item.Size);
                ReccomendedPrice.Add(Item.RecommendedRetailPrice);
                ProductWeight.Add(Item.TypicalWeightPerUnit);
                LeadTimeDays.Add(Item.LeadTimeDays);
                ValidSince.Add(Item.ValidFrom);
                JObject country = Item.CustomFields;
                CountryOrigin.Add(country);



                    }


        }
        public List<string> StockItemName { get; private set; }

        public List<string> ItemSize { get; private set; }

        public List<decimal?> ReccomendedPrice { get; private set; }

        public List<decimal> ProductWeight { get; private set; }

        public List<int> LeadTimeDays { get; private set; }

        public List<DateTime> ValidSince { get; private set; }

        public List<string> CountryOrigin { get; private set; }

        public List<string[]> Tags { get; private set; }

        public List<byte[]> Photo { get; private set; }



    }
}