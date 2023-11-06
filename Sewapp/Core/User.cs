namespace Sewapp.Core
{
    public class User
    {
        private int Id { get; set; }
        public string Name { get; set; }
        public List<Pattern> Patterns { get; set; }
    }
}
