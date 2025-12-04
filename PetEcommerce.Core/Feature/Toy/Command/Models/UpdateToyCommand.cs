using MediatR;
using PetEcommerce.Domain.BaseReponse;

namespace PetEcommerce.Core.Feature.Toy.Command.Models
{
    public class UpdateToyCommand : IRequest<BaseResponse<bool>>
    {
    }
}
