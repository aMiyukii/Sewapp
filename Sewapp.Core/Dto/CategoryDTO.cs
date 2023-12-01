namespace Sewapp.Core.Dto;

public class CategoryDTO
{
    private int Id { get; set; }
    public string Name { get; set; }

    public CategoryDTO(string name)
    {
        Name = name;
    }
}