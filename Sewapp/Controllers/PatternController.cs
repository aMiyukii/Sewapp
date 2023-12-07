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
            return View(patterns);
        }

        public IActionResult AddPatternForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPatternName(PatternViewModel patternViewModel)
        {
            var pattern = new Pattern { Name = patternViewModel.Name, };

            patternService.AddPattern(pattern);
            return RedirectToAction("Index");
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
