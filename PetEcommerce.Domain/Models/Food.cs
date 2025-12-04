using System.ComponentModel.DataAnnotations.Schema;

namespace PetEcommerce.Domain.Models
{
    public class Food : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [ForeignKey("Brand")]
        public Guid BrandId { get; set; }
        public virtual Brand? Brand { get; set; } // e.g., "Acme Pet Foods"
        [ForeignKey("Flavor")]
        public Guid FlavorId { get; set; }
        public virtual Flavor? Flavor { get; set; } // e.g., "Chicken"
        public string Size { get; set; } = string.Empty; // e.g., "2 lbs", "5 kg"
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
