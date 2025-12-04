using System.ComponentModel.DataAnnotations.Schema;

namespace PetEcommerce.Domain.Models
{
    public class Pet : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [ForeignKey("Breed")]
        public Guid BreedId { get; set; }
        public virtual Breed? Breed { get; set; } // e.g., Labrador, Siamese
        [ForeignKey("Species")]
        public Guid SpeciesId { get; set; }
        public virtual Species? Species { get; set; } // e.g., Dog, Cat
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

    }
}
