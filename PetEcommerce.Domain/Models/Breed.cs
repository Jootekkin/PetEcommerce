namespace PetEcommerce.Domain.Models
{
    public class Breed : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}
