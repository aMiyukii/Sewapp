using Google.Protobuf.WellKnownTypes;

namespace Sewapp.Core
{
    public class Category
    {
        private int Id { get; set; }
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }
    }
}