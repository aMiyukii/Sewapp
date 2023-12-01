namespace Sewapp.Core.Models
{
    public class Pattern
    {
        private int Id { get; set; }
        public string Name { get; set; }
        public List<Category> Category { get; set; }

        public Pattern()
        {
        }
    }
}
