namespace Catalog.Api.ModelView

{
    public record ProductResponseViewModel 
    {
        public Guid Id { get; init; }
        public required string Name { get; set;}
        public required int Price { get; set; }     
        public DateTimeOffset CreatedDate { get; init; }
        public string? Description { get; set; }
    }
}