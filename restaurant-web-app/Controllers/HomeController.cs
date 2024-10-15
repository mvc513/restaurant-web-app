using Microsoft.AspNetCore.Mvc;
using restaurant_web_app.Models;
using System.Diagnostics;

namespace restaurant_web_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static DB _db;

        public HomeController(ILogger<HomeController> logger, DB db)
        {
            _logger = logger;
            _db = db; //dependecy injection design pattern
        }

        public IActionResult Index()
        {
            var menutFundit = _db.Menu.Take(6).ToList();
            return View(menutFundit);
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
