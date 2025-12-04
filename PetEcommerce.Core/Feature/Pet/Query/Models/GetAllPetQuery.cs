using MediatR;
using PetEcommerce.Core.Feature.Pet.Query.Result;
using PetEcommerce.Domain.BaseReponse;
using PetEcommerce.Domain.DTOs.PetDtos;
using PetEcommerce.Domain.Pagination;

namespace PetEcommerce.Core.Feature.Pet.Query.Models
{
    public class GetAllPetQuery : PetPagedRequest, IRequest<BaseResponse<PagedResult<GetAllPetResult>>>
    {

    }
}
