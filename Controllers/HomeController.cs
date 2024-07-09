using Microsoft.AspNetCore.Mvc;
using Sales_Web_Mvc.Models;
using System.Diagnostics;
using Sales_Web_Mvc.Models.ViewModels;

namespace Sales_Web_Mvc.Controllers
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
        public IActionResult About() 
        {
            ViewData["Message"] = "Salles Web MVC App from Course";
            ViewData["Professor"] = "N�lio Alves";

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