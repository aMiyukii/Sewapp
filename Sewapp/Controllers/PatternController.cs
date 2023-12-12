using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
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
        private readonly CategoryService categoryService;

        public PatternController()
        {
            patternService = new PatternService();
            categoryService = new CategoryService();
        }

        public IActionResult Index()
        {
            var patterns = patternService.GetAllPatterns();
            Console.WriteLine($"Number of patterns retrieved: {patterns.Count}");
            return View(patterns);
        }


        public IActionResult AddPatternForm()
        {
            var patternViewModel = new PatternViewModel
            {
                Categories = categoryService.GetAllCategories()
            };

            return View(patternViewModel);
        }


        [HttpPost]
        public IActionResult AddPatternName(PatternViewModel patternViewModel)
        {
            var pattern = new Pattern
            {
                Name = patternViewModel.Name,
                CategoryId = patternViewModel.CategoryId
            };

            patternService.AddPattern(pattern);
            var patterns = patternService.GetAllPatterns();

            return View("Index", patterns);
        }



        public IActionResult AddCategoryForm()
        {
            return View();
        }

        

        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel categoryViewModel)
        {
            var category = new Category { Name = categoryViewModel.Name, };

            categoryService.AddCategory(category);
            return RedirectToAction("Index");
        }


    }
}
