using Sewapp.Core.Models;

namespace Sewapp.Models
{
    public class PatternViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
        public int CategoryId { get; set; }


        public PatternViewModel()
        {

        }

        public PatternViewModel(string name)
        {
            Name = name;
        }
    }
}