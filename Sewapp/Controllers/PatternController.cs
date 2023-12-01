using Microsoft.AspNetCore.Mvc;
using Sewapp.Core.Models;
using Sewapp.Core.Services;
using Sewapp.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Sewapp.Controllers
{
    public class PatternController : Controller
	    {
        PatternService patternService = new PatternService();


            public IActionResult Index()
            {
                return View();
            }

        
        public IActionResult AddPatternForm()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddPatternName(Pattern pattern)
        {
            //Console.WriteLine($"Pattern Name: {pattern.Name}");

            //patternService.AddPattern(pattern);

            ViewBag.PatternName = pattern.Name;

            return View("Index");
        }
    }

}

