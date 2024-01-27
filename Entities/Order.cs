namespace Orders.Entities
{
    public record Order
    {
        public Guid Id { get; init; }

        public required List<Product> Products { get; set; }
        
        public required Double TotalPrice { get; init; }

        public DateTimeOffset CreatedDate { get; init; }
    }
}