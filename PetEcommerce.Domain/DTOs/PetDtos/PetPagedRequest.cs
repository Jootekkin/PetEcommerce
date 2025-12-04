using PetEcommerce.Domain.Models;
using PetEcommerce.Domain.Pagination;

namespace PetEcommerce.Domain.DTOs.PetDtos
{
    public class PetPagedRequest : BasePagedRequest<Pet>
    {

        public string? SpeciesName { get; set; }
        public string? BreedName { get; set; }
        public string? Gender { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }


        public void ApplyFilters()
        {
            if (!string.IsNullOrEmpty(SpeciesName))
            {
                AddFilter(p => p.Species != null && p.Species.Name.ToLower() == SpeciesName.ToLower());
            }
            if (!string.IsNullOrEmpty(BreedName))
            {
                AddFilter(p => p.Breed != null && p.Breed.Name.ToLower() == BreedName.ToLower());
            }
            if (!string.IsNullOrEmpty(Gender))
            {
                AddFilter(p => p.Gender != null && p.Gender.ToLower() == Gender.ToLower());
            }
            if (MinPrice.HasValue)
            {
                AddFilter(p => p.Price >= MinPrice.Value);
            }
            if (MaxPrice.HasValue)
            {
                AddFilter(p => p.Price <= MaxPrice.Value);
            }
        }

    }
}
