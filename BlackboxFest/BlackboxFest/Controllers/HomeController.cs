using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlackboxFest.Models;

namespace BlackboxFest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View();
            }
            //  ViewBag.ImagePath = "../images/festivalBackground.jpeg";
            return View("IndexUser");
        }
        public IActionResult IndexUser()
        {
            //if (User.IsInRole("Admin"))
            //{
            //    return RedirectToAction();
            //}
            //  ViewBag.ImagePath = "../images/festivalBackground.jpeg";
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
