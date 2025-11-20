namespace PetEcommerce.Domain.Models
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; } = string.Empty; // e.g., "Acme Pet Foods"
        public string Description { get; set; } = string.Empty; // e.g., "High-quality pet food brand"
        public virtual ICollection<Food> Foods { get; set; } = new List<Food>();
    }
}
