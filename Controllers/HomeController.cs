using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace passcode.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? count = HttpContext.Session.GetInt32("count");
            if(count == null)
            {
                count = 0;
            }
            count += 1;
            string result = "";
            string letter_list = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string passcode = "";
            Random rand = new Random();
            for(var i = 0; i < 14; i++)
            {
                passcode = passcode +letter_list[rand.Next(0,letter_list.Length)];
            }
            ViewBag.passcode = passcode;
            ViewBag.CountNumber = count;
            HttpContext.Session.SetInt32("count", (int)count);
            return View();      
        }
    }
}
