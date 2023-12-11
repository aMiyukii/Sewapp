﻿namespace Sewapp.Core.Models
{
    public class Pattern
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public Pattern()
        {
        }
    }
}
