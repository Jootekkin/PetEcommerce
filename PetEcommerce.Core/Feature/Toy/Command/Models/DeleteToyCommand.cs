using MediatR;
using PetEcommerce.Domain.BaseReponse;

namespace PetEcommerce.Core.Feature.Toy.Command.Models
{
    public class DeleteToyCommand : IRequest<BaseResponse<bool>>
    {
    }
}
