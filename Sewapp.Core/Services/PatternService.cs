using Sewapp.Core.Dto;
using Sewapp.Core.Models;

namespace Sewapp.Core.Services
{
    public class PatternService
    {
        public PatternDTO SavePattern(Pattern newPattern)
        {
            PatternDTO patternDto = new PatternDTO();

            patternDto.Name = newPattern.Name;
            patternDto.Category = new List<CategoryDTO>();

            foreach (var category in newPattern.Category)
            {
                CategoryDTO categoryDto = new CategoryDTO(category.Name);
                patternDto.Category.Add(categoryDto);
            }
            return patternDto;
        }
    }
}
