using Sewapp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sewapp.Core.Interfaces
{
    public interface IPatternRepository
    {
        void AddPattern(Pattern newPattern);
        List<Pattern> GetAllPatterns();
    }
}
