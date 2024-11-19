using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ProductDto
    {
        //İmutable olmalı veri değişmemeli. O yüzden set yerine init deriz.
        public int ProductId { get; init; }
        public String? ProductName { get; init; } = String.Empty;
        public decimal Price { get; init; }
        public string? Summary { get; init; } = String.Empty;
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; init; }  
    }
}