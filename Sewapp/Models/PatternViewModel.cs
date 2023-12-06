namespace Sewapp.Models
{
    public class PatternViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }   

        public PatternViewModel(string name)
        {
            Name = name;
        }
    }
}