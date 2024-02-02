namespace Catalog.Dtos

{
    public record ProductResponseViewModel 
    {
        public Guid Id { get; init; }
        public required string Name { get; set;}

        public required Double Price { get; set; }

        public string? Description { get; set; }

        public DateTimeOffset CreatedDate { get; init; }
    }
}