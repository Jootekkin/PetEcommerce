namespace PetEcommerce.Domain.DTOs.ToyDtos
{
    public class ToyDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Material { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public bool IsDurable { get; set; }
    }
}
