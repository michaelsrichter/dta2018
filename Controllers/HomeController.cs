using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DTA2018.Helpers;
using Microsoft.AspNetCore.Mvc;
using DTA2018.Models;
using Microsoft.AspNetCore.Http.Extensions;

namespace DTA2018.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var ui = new UserInfo(new Uri(Request.GetEncodedUrl()));
            return View(ui);





        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
