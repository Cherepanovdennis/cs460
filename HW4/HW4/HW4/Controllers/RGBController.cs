using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Drawing;

namespace HW4.Controllers
{
    public class RGBController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            if (Request.Query["red"].ToString() == "")
            {
                ViewBag.Success = false;
                return View();
            }
            else
            {
                string ColorRed = Request.Query["red"].ToString();
                string colorblue = Request.Query["blue"].ToString();
                string colorgreen = Request.Query["green"].ToString();
                ViewBag.RedRGB = System.Convert.ToInt32(ColorRed);
                ViewBag.BlueRGB = System.Convert.ToInt32(colorblue);
                ViewBag.GreenRGB = System.Convert.ToInt32(colorgreen);
                Color mycolor = Color.FromArgb(System.Convert.ToInt32(ColorRed), System.Convert.ToInt32(colorgreen), System.Convert.ToInt32(colorblue));
                ViewBag.Hex = mycolor.R.ToString("X2") + mycolor.G.ToString("X2") + mycolor.B.ToString("X2");
                ViewBag.Success = true;
                return View();
            }
        }

        


    }
}