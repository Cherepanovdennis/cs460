using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW6.DAL;
using HW6.Models;
using HW6.Models.ViewModel;


namespace HW6.Controllers
{
    public class SearchController : Controller
    {
        private WideWorldImportersContext db = new WideWorldImportersContext();
        // GET: Search

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(string ProductName)
        {
            if(string.IsNullOrEmpty(ProductName) == true)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
           System.Linq.IQueryable<StockItem> stockItem = db.StockItems.Where(Item => Item.StockItemName.Contains(ProductName));

            if(stockItem.Count)
            {
                return HttpNotFound();
            }

            System.Linq.IQueryable<StockItemModelView> StockItemTable = new System.Linq.IQueryable<StockItemModelView>(stockItem);

        }
    }
}