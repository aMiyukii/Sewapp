namespace Sewapp.Core.Models
{
    public class User
    {
        private int Id { get; set; }
        public string Name { get; set; }
        public List<Pattern> Patterns { get; set; }
    }
}
