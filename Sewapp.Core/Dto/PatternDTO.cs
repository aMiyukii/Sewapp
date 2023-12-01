using Sewapp.Core;

namespace Sewapp.Core.Dto;

public class PatternDTO
{
    private int Id { get; set; }
    public string Name { get; set; }
    public List<CategoryDTO> Category { get; set; }
}