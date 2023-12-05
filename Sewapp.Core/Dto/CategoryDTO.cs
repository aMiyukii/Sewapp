﻿namespace Sewapp.Core.Dto;

public class CategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public CategoryDTO(string name)
    {
        Name = name;
    }
}