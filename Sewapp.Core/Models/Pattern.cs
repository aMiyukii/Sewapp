namespace Sewapp.Core.Models
{
    public class Pattern
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> Category { get; set; }

        public Pattern()
        {
        }
    }
}
