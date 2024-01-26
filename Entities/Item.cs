using System.Security.Cryptography.X509Certificates;

namespace Catalog.Entities
{
    public record Item 
    {
        public Guid Id { get; init; }
        public required string Name { get; set;}

        public decimal Price { get; set; }

        public DateTimeOffset CreatedDate { get; init; }
    }
}