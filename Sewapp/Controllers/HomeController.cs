using Microsoft.AspNetCore.Mvc;
using Sewapp.Models;
using System.Diagnostics;

namespace Sewapp.Controllers
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

        public IActionResult AddPatternPage()
        {
            return View("AddPatternPage");
        }

        public IActionResult Error()
        {
            var viewModel = new CustomErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}