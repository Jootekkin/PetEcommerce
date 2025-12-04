using System.ComponentModel.DataAnnotations.Schema;

namespace PetEcommerce.Domain.Models
{
    public class Breed : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        [ForeignKey("Species")]
        public Guid? SpeciesId { get; set; }
        public virtual Species? Species { get; set; }
        public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}
