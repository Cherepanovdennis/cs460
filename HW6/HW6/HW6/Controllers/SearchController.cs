using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW6.DAL;
using HW6.Models;
using HW6.Models.ViewModel;
using System.Data.Entity.Infrastructure;


namespace HW6.Controllers
{
    public class SearchController : Controller
    {
        private WideWorldImportersContext db = new WideWorldImportersContext();
        // GET: Search

        


        [HttpGet]
        public ActionResult Index()
        {
   

            if (Request.QueryString["="] == null)
            {
                ViewBag.input = false;
                return View();
            }
            string userinput = Request.QueryString["="].ToString();
            ViewBag.input = true;
            List<string> Name = db.StockItems.Where(Item => Item.StockItemName.Contains(userinput)).Select(x =>  x.StockItemName).ToList();
            NameTable ListofProducts = new NameTable(Name);
            return View(ListofProducts);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            
            
            if(string.IsNullOrEmpty(id) == true)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
          StockItem stockItem = db.StockItems.First(Item => Item.StockItemName == id);

            if(stockItem == null)
            {
                return HttpNotFound();
            }

           StockItemModelView StockItemTable = new StockItemModelView(stockItem);

            return View(StockItemTable);
        }
    }
}