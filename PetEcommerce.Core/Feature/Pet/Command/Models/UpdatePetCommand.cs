using MediatR;
using PetEcommerce.Domain.BaseReponse;

namespace PetEcommerce.Core.Feature.Pet.Command.Models
{
    public class UpdatePetCommand : IRequest<BaseResponse<bool>>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid? BreedId { get; set; } // e.g., Labrador, Siamese
        public Guid? SpeciesId { get; set; } // e.g., Dog, Cat
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
