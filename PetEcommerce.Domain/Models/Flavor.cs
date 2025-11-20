namespace PetEcommerce.Domain.Models
{
    public class Flavor : BaseEntity
    {
        public string Name { get; set; } = string.Empty; // e.g., "Chicken", "Beef", "Salmon"
        public string Description { get; set; } = string.Empty; // e.g., "A savory chicken flavor loved by dogs."
        public virtual ICollection<Food> Foods { get; set; } = new List<Food>();
    }
}
