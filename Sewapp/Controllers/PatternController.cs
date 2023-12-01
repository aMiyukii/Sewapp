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
        private readonly PatternService patternService;

        public PatternController(PatternService patternService)
        {
            this.patternService = patternService;
        }

        public IActionResult Index()
        {
            var patterns = patternService.GetPatterns();
            return View(patterns);
        }

        public IActionResult AddPatternForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPatternName(Pattern pattern)
        {
            if (ModelState.IsValid)
            {
                patternService.AddPattern(pattern);

                ViewBag.PatternName = pattern.Name;

                return View("Index");
            }
            else
            {
                return View("YourFormView", pattern);
            }
        }
    }
}
