using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            Data d = new Data();
            return View();
        }

        [HttpPost("rand")]
        public IActionResult getRandomString()
        {
            Data d = new Data();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random r = new Random();
            StringBuilder builder = new StringBuilder();
            char ch =  default(char);
            for(int i = 0; i < 14; i++)
            {
                // ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * r.NextDouble() + 65)));
                ch = alphabet[r.Next(alphabet.Length)];
                builder.Append(ch);
            }
            if(HttpContext.Session.GetInt32("count") == null)
            {
                HttpContext.Session.SetInt32("count", 0);
                ViewBag.Count = HttpContext.Session.GetInt32("count");
            }
            else
            {
                HttpContext.Session.SetInt32("count", (int)(HttpContext.Session.GetInt32("count")+1));
                d.count = HttpContext.Session.GetInt32("count");
                d.Randomstring = builder.ToString();
            }
            
            return Json(d);
        }

    }
}
