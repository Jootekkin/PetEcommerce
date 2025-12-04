using MediatR;
using PetEcommerce.Domain.BaseReponse;

namespace PetEcommerce.Core.Feature.Pet.Command.Models
{
    public class DeletePetCommand : IRequest<BaseResponse<bool>>
    {
        public Guid Id { get; set; }

        public DeletePetCommand(Guid id)
        {
            Id = id;
        }
    }
}
