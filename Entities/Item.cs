using System.Reflection;

namespace Catalog.Entities
{
    public record Product 
    {
        public Guid Id { get; init; }
        public required string Name { get; set;}

        public required Double Price { get; set; }

        public required byte[] Image { get; set; }
        public string? Description { get; set; }

        public DateTimeOffset CreatedDate { get; init; }
    }
}