namespace ProductCatalog.Application.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }  
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }

        public ProductDto() { }

        public ProductDto(Guid id, string name, string? description, decimal price, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CreatedAt = createdAt;
        }
    }
}
