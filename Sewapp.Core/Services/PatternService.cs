using Sewapp.Core.Dto;
using Sewapp.Core.Models;
using Sewapp.Data;

namespace Sewapp.Core.Services
{
    public class PatternService
    {
        public void AddPattern(Pattern newPattern)
        {
            PatternRepository patternRepository = new PatternRepository(newPattern.Name);
            patternRepository.SendPatternToDatabase();
        }

        public List<Pattern> GetAllPatterns()
        {
            List<Pattern> patterns = new List<Pattern>();

            List<PatternRepository> patternDataList = PatternRepository.GetAllPatternsFromDatabase();

            foreach (var patternData in patternDataList)
            {
                Pattern pattern = new Pattern
                {
                    Id = patternData.Id,
                    Name = patternData.Name,
                };

                patterns.Add(pattern);
            }

            return patterns;
        }
    }
}
