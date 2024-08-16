using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsAcademy.Models;
using System.Diagnostics;

namespace SportsAcademy.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Coaching()
        {
            return View();
        }

        public IActionResult Coaching1()
        {
            return View(Coaching1);
        }
        public IActionResult Coaching2()
        {
            return View(Coaching2);
        }
        public IActionResult Coaching3()
        {
            return View(Coaching3);
        }
        public IActionResult Coaching4()
        {
            return View(Coaching4);
        }

        public IActionResult Facilities()
        {
            return View();
        }

        public IActionResult ContactUs()
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
