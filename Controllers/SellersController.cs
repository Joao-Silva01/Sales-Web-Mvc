using Microsoft.AspNetCore.Mvc;

namespace Sales_Web_Mvc.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
