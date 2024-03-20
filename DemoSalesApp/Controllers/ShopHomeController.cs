using DemoSalesApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoSalesApp.Controllers
{
    public class ShopHomeController : Controller
    {
        private readonly ILogger<ShopHomeController> _logger;

        public ShopHomeController(ILogger<ShopHomeController> logger)
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