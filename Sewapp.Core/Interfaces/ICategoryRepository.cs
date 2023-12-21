using Sewapp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sewapp.Core.Interfaces
{
    public interface ICategoryRepository
    {
        void AddCategory(Category newCategory);
        List<Category> GetAllCategories();
    }
}
