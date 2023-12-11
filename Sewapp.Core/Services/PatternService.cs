using Sewapp.Core.Dto;
using Sewapp.Core.Models;
using Sewapp.Data;

namespace Sewapp.Core.Services
{
    public class PatternService
    {

        public void AddPattern(Pattern newPattern)
        {
            PatternRepository patternRepository = new PatternRepository(newPattern.Name, newPattern.CategoryId);
            patternRepository.SendPatternToDatabase();
        }

        public List<Pattern> GetAllPatterns()
        {
            List<Pattern> patterns = new List<Pattern>();

            List<PatternRepository> patternDataList = PatternRepository.GetPatternsFromDatabase();


            foreach (var patternData in patternDataList)
            {
                Pattern pattern = new Pattern
                {
                    Id = patternData.Id,
                    Name = patternData.Name,
                    CategoryId = patternData.CategoryId,
                };

                pattern.Category = GetCategoryById(patternData.CategoryId);

                patterns.Add(pattern);
            }

            return patterns;
        } 

        private Category GetCategoryById(int categoryId)
        {
            CategoryRepository categoryRepository = CategoryRepository.GetCategoryByIdFromDatabase(categoryId);

            if (categoryRepository != null)
            {
                return new Category
                {
                    Id = categoryRepository.CategoryId,
                    Name = categoryRepository.Name,
                };
            }

            return null;
        }

    }
}
