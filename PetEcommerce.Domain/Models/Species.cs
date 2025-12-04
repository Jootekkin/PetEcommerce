namespace PetEcommerce.Domain.Models
{
    public class Species : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
        public virtual ICollection<Breed> Breeds { get; set; } = new List<Breed>();
    }
}
