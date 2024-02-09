namespace Catalog.Dtos

{
    public record ProductResponseViewModel 
    {
        public Guid Id { get; init; }
        public required string Name { get; set;}
        public required int Price { get; set; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}