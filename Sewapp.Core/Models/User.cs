namespace Sewapp.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pattern> Patterns { get; set; }
    }
}
