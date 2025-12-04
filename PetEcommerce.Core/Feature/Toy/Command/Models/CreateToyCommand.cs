using MediatR;
using PetEcommerce.Domain.BaseReponse;

namespace PetEcommerce.Core.Feature.Toy.Command.Models
{
    public class CreateToyCommand : IRequest<BaseResponse<bool>>
    {
    }
}
