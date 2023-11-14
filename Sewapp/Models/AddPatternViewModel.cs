namespace Sewapp.Models
{
    public class AddPatternViewModel
    {
        public string PatternName { get; set; }
        public string Category { get; set; }
        public IFormFile File { get; set; }     
    }
}