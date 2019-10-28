using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace HW4.Controllers
{
    public class RGBTableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string hexfirstcolor, string hexsecondcolor, int? steps)
        {
            string test = hexfirstcolor;
            string test2 = hexsecondcolor;
           test =  test.Remove(0, 1);
            test2 = test2.Remove(0, 1);
            bool testifhex1 = System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
            bool testifhex2 = System.Text.RegularExpressions.Regex.IsMatch(test2, @"\A\b[0-9a-fA-F]+\b\Z");


            if (steps == null || !ModelState.IsValid || hexfirstcolor[0] != '#' || hexfirstcolor[0] != '#' || testifhex1 == false || testifhex2 ==false ) //if int is null or invalid
            {
                ViewBag.HexValue = false;
                return View(); 
            }
            else
            {
                ViewBag.success = true;
                if(hexfirstcolor.Length != 7 || hexsecondcolor.Length != 7)
                {
                    int x = hexfirstcolor.Length;
                    int z = hexsecondcolor.Length;
                    while(hexfirstcolor.Length < 7)
                    {
                        hexfirstcolor += hexfirstcolor[x - 1];
                        hexsecondcolor += hexsecondcolor[z - 1];
                    }
                }
                List<string> Hex = new List<string>();
                Color firstcolor = ColorTranslator.FromHtml(hexfirstcolor);
                Color secondcolor = ColorTranslator.FromHtml(hexsecondcolor);

                double value = firstcolor.GetBrightness();
                double saturation = firstcolor.GetSaturation();
                double hue = firstcolor.GetHue();
                double value2 = secondcolor.GetBrightness();
                double saturation2 = secondcolor.GetSaturation();
                double hu2 = secondcolor.GetHue();

                ColorToHSV(firstcolor, out hue, out saturation, out value);
                ColorToHSV(secondcolor, out hu2, out saturation2, out value2);
                Color holder;
                double hueincrement = (hue - hu2) / Convert.ToDouble(steps);
                double valueincrement = (value - value2) / Convert.ToDouble(steps);
                double saturationincrement = (saturation - saturation2) / Convert.ToDouble(steps);
                Hex.Add(hexfirstcolor);
                
                if(hueincrement < 0)
                {
                    hueincrement *= -1;
                }

                if (valueincrement < 0)
                {
                    valueincrement *= -1;
                }

                if(saturationincrement < 0)
                {
                    saturationincrement *= -1;
                }


                for (int i = 0; i < steps; i++)
                {
                    if (hue == hu2) //they are both equal and we are done
                    {

                    }

                    else if (hue > hu2)
                    { hue -= hueincrement; }

                    else
                    { hue += hueincrement; }

                    if (saturation == saturation2)
                    {

                    }
                    else if (saturation > saturation2)
                    {
                        saturation -= saturationincrement;
                    }
                    else
                    { saturation += saturationincrement; }


                    if (value == value2)
                    {

                    }
                    else if (value > value2)
                    { value -= valueincrement; }

                    else
                    { value += valueincrement; }

                    holder = ColorFromHSV(hue, saturation, value);
                    Hex.Add(ColorTranslator.ToHtml(holder));
                }
                ViewBag.hexlist = Hex;
                return View();
            }
        }

        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

    }
}