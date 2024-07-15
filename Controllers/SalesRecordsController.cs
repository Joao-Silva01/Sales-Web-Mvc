using Microsoft.AspNetCore.Mvc;
using Sales_Web_Mvc.Services;

namespace Sales_Web_Mvc.Controllers
{
    public class SalesRecordsController(SalesRecordsService salesRS) : Controller
    {
        private readonly SalesRecordsService _salesRecordsService = salesRS;
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue) minDate = new DateTime(2018,01,01);
            ViewData["MinDate"] = minDate.Value.ToString("yyyy-MM-dd");

            if (!maxDate.HasValue) maxDate = new DateTime(2018,12,31);
            ViewData["MaxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordsService.FindByDateAsync(minDate, maxDate);
            return View(result);

        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue) minDate = new DateTime(2018, 01, 01);
            ViewData["MinDate"] = minDate.Value.ToString("yyyy-MM-dd");

            if (!maxDate.HasValue) maxDate = new DateTime(2018, 12, 31);
            ViewData["MaxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordsService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);

        }
    }
}
