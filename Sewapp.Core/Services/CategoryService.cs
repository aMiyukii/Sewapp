using Sewapp.Core.Models;
using Sewapp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sewapp.Core.Services
{
    public class CategoryService
    {
        public void AddCategory(Category newCategory)
        {
            CategoryRepository categoryRepository = new CategoryRepository(newCategory.Name);
            categoryRepository.SendCategoryToDatabase();
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();

            List<CategoryRepository> categoryRepositoryList = CategoryRepository.GetAllCategoriesFromDatabase();

            foreach (var categoryRepository in categoryRepositoryList)
            {
                Category category = new Category
                {
                    Id = categoryRepository.CategoryId,
                    Name = categoryRepository.Name,
                };

                categories.Add(category);
            }

            return categories;
        }
    }
}
