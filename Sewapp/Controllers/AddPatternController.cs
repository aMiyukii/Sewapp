using Microsoft.AspNetCore.Mvc;
using Sewapp.Core;
using Sewapp.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Sewapp.Controllers
{
	public class AddPatternController : Controller
	{
        public IActionResult Index()
        {
            return View();
        }

        public void Create()
        {

        }

        [HttpPost]
        public IActionResult AddPattern(Pattern pattern)
        {
            Console.WriteLine($"Patter" + pattern);
            return View("Index");
        }
    }
}
