namespace Catalog.Entities
{
    public record Product 
    {
        public Guid Id { get; init; }
        public required string Name { get; set;}

        public Double Price { get; set; }

        public DateTimeOffset CreatedDate { get; init; }
    }
}