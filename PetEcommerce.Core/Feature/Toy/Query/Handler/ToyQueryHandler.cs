using AutoMapper;
using MediatR;
using PetEcommerce.Core.Feature.Toy.Query.Models;
using PetEcommerce.Core.Feature.Toy.Query.Result;
using PetEcommerce.Domain.BaseReponse;
using PetEcommerce.Domain.Pagination;
using PetEcommerce.Service.BaseService;

namespace PetEcommerce.Core.Feature.Toy.Query.Handler
{
    public class ToyQueryHandler : ResponseHandler, IRequestHandler<GetAllToyQuery, BaseResponse<PagedResult<GetAllToyQueryResult>>>
    {
        #region Fields
        private readonly IToyService _toyService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ToyQueryHandler(IToyService toyService, IMapper mapper)
        {
            _toyService = toyService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<BaseResponse<PagedResult<GetAllToyQueryResult>>> Handle(GetAllToyQuery request, CancellationToken cancellationToken)
        {
            var result = await _toyService.GetAllToysAsync(request);
            if (result == null)
            {
                return NotFound<PagedResult<GetAllToyQueryResult>>();
            }
            var mappedToy = _mapper.Map<PagedResult<GetAllToyQueryResult>>(result);
            return Success(mappedToy);

        }
        #endregion
    }
}
