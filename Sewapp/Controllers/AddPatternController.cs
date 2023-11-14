using Microsoft.AspNetCore.Mvc;
using Sewapp.Models;
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

        [HttpPost]
        public async Task<IActionResult> AddPattern(AddPatternViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null && model.File.Length > 0)
                {
                    var filePath = Path.Combine("your_upload_directory", model.File.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.File.CopyToAsync(stream);
                    }
                }

                string patternName = model.PatternName;
                string category = model.Category;

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
