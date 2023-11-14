using Sewapp.Data;

namespace Sewapp.Core
{
    public class Add_Pattern
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
