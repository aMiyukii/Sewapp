using Sewapp.Core;

namespace Sewapp.Data;

public class PatternDTO
{
    private int Id { get; set; }
    public string Name { get; set; }
    public List<CategoryDTO> Category { get; set; }
}