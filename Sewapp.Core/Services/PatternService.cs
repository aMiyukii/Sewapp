using Sewapp.Core.Dto;
using Sewapp.Core.Models;
using Sewapp.Data;

namespace Sewapp.Core.Services
{
    public class PatternService
    {
        public void AddPattern(Pattern newPattern)
        {
            PatternData patternData = new PatternData(newPattern.Name);
            patternData.SendPatternToDatabase();
        }

        public List<Pattern> GetAllPatterns()
        {
            List<Pattern> patterns = new List<Pattern>();

            List<PatternData> patternDataList = PatternData.GetAllPatternsFromDatabase();

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
