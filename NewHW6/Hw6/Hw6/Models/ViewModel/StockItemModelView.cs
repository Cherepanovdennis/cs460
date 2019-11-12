using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hw6.Models;
using Newtonsoft.Json;
using Hw6.Dal;
using Hw6.Models.ViewModel;
using System.Data.Entity.Infrastructure;

namespace Hw6.Models.ViewModel
{
    public class StockItemModelView
    {
        private readonly WideWorldImportersContext db = new WideWorldImportersContext();

        public List<string> ListNames { get; private set; }

        public List<int> ListOrders { get; private set; }
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


            List<OrderLine> TopPurchasers = db.OrderLines.Where(item => item.StockItemID == stockItem.StockItemID).OrderByDescending(x => x.Quantity).ToList();
            HashSet<string> names = new HashSet<string>();
            List<string> ListNames = new List<string>();
            NumberOfSales = TopPurchasers.Count();
            int NumberSold = 0;



            foreach (OrderLine item in TopPurchasers)
            {
                names.Add(item.Person.FullName);
                NumberSold += item.Quantity;

            }
            int[] TopOrders = new int[names.Count()];

            GrossSales = NumberSold * stockItem.UnitPrice;

            NetSales = GrossSales - (GrossSales * (stockItem.TaxRate * (decimal).01));

            foreach (string item in names)
            {
                ListNames.Add(item);
            }

            foreach (OrderLine item in TopPurchasers)
            {
                TopOrders[ListNames.IndexOf(item.Person.FullName)] += item.Quantity;
            }

            List<int> ListOrders = new List<int>();
            ListOrders = TopOrders.ToList();



            while (ListOrders.Count() != 10)
            {
                int x = ListOrders.FindIndex(y => y == ListOrders.Min());
                ListOrders.RemoveAt(x);
                ListNames.RemoveAt(x);
            }

             OrderedOrderList = new List<int>();
             OrderedNameList = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                int x = ListOrders.IndexOf(ListOrders.Max());
                OrderedOrderList.Add(ListOrders.ElementAt(x));
                OrderedNameList.Add(ListNames.ElementAt(x));
                ListOrders.RemoveAt(x);
                ListNames.RemoveAt(x);
            }




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

        public int NumberOfSales { get; private set; }

        public decimal GrossSales { get; private set; }

        public decimal NetSales { get; private set; }

        public List<string> OrderedNameList{ get; private set; }

        public List<int> OrderedOrderList { get; private set; }







    }
}