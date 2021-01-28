using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BeanSeans.Models;
using BeanSeans.Data;

namespace BeanSeans.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;//add

        public IActionResult RedirectUser()
        {
          
             if (User.IsInRole("Manager") && User.IsInRole("Staff"))
            {
                return RedirectToAction("Index", "Sitting", new { Area = "Staff" });

            }
             if (User.IsInRole("Staff") && !User.IsInRole("Manager"))
            {
                return RedirectToAction("Index", "Reservation", new { Area = "Staff" });

            }

            return RedirectToAction("Index");


        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
