using PetEcommerce.Core.Feature.Pet.Query.Result;
using PetEcommerce.Domain.Models;

namespace PetEcommerce.Core.Mapping
{
    public partial class Profiling
    {
        private void PetQueryMapping()
        {
            // CreateMap<Source, Destination>();
            CreateMap<Pet, GetAllPetResult>()
                .ForMember(dest => dest.BreedName, opt => opt.MapFrom(src => src.Breed != null ? src.Breed.Name : string.Empty))
                .ForMember(dest => dest.SpeciesName, opt => opt.MapFrom(src => src.Species != null ? src.Species.Name : string.Empty));
        }
    }
}
