
namespace Sewapp.Core.Models
{
    public class Category
    {
        private int Id { get; set; }
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }
    }
}