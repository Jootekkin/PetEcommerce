using MediatR;
using PetEcommerce.Core.Feature.Toy.Query.Result;
using PetEcommerce.Domain.BaseReponse;
using PetEcommerce.Domain.DTOs.ToyDtos;
using PetEcommerce.Domain.Pagination;

namespace PetEcommerce.Core.Feature.Toy.Query.Models
{
    public class GetAllToyQuery : ToyPagedRequest, IRequest<BaseResponse<PagedResult<GetAllToyQueryResult>>>
    {
    }
}
