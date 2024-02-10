using System.ComponentModel.DataAnnotations;

namespace Catalog.Api.ModelView
{
    public record UpdateProductViewModel
    {
        [Required]
        public required string  Name { get; init; }
        
        [Required]
        [Range(1, 1000)]
        public int Price { get; init; }

        public string? Description { get; set; }
    }
}