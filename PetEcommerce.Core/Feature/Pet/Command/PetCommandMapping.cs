using PetEcommerce.Core.Feature.Pet.Command.Models;

namespace PetEcommerce.Core.Mapping
{
    public partial class Profiling
    {
        public void PetCommandMapping()
        {
            CreateMap<CreatePetCommand, Domain.Models.Pet>();
        }
    }
}
