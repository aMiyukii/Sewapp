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
        public PatternController()
        {
            patternService = new PatternService();
        }

        public IActionResult Index()
        {
            var patterns = patternService.GetAllPatterns();
            return View(patterns);
        }

        public IActionResult AddPatternForm()
        {
            return View();
        }


        private readonly PatternService patternService;

        [HttpPost]
        public IActionResult AddPatternName(Pattern pattern)
        {
            Console.WriteLine($"Pattern Name: {pattern.Name}");
            patternService.AddPattern(pattern);
            ViewBag.PatternName = pattern.Name;
            return RedirectToAction("Index");
        }

        public IActionResult AddCategoryForm()
        {
            return View();
        }

        private readonly CategoryService categoryService;

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            Console.WriteLine($"Category Name: {category.Name}");

            // Use the instance of CategoryService to call AddCategory
            categoryService.AddCategory(category);

            ViewBag.PatternName = category.Name;
            return RedirectToAction("Index");
        }


    }
}
