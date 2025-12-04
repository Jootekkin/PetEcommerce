using AutoMapper;
using MediatR;
using PetEcommerce.Core.Feature.Pet.Query.Models;
using PetEcommerce.Core.Feature.Pet.Query.Result;
using PetEcommerce.Domain.BaseReponse;
using PetEcommerce.Domain.Pagination;
using PetEcommerce.Service.BaseService;

namespace PetEcommerce.Core.Feature.Pet.Query.Handler
{
    public class PetQueryHandler : ResponseHandler,
        IRequestHandler<GetAllPetQuery, BaseResponse<PagedResult<GetAllPetResult>>>
    {
        #region Fields
        private readonly IPetService _petService;
        private readonly IUploadFilesService _uploadFilesService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public PetQueryHandler(IPetService petService, IMapper mapper, IUploadFilesService uploadFilesService)
        {
            _petService = petService;
            _mapper = mapper;
            _uploadFilesService = uploadFilesService;
        }
        #endregion

        #region Methods
        public async Task<BaseResponse<PagedResult<GetAllPetResult>>> Handle(GetAllPetQuery request, CancellationToken cancellationToken)
        {
            var pagedPets = await _petService.GetAllPetsAsync(request);
            if (pagedPets == null || pagedPets.Items.Count == 0)
            {
                return NotFound<PagedResult<GetAllPetResult>>();
            }
            var imageInfo = await _uploadFilesService.GetFileInfo(pagedPets.Items.Select(x => x.Id).ToString());

            var mappedPets = _mapper.Map<PagedResult<GetAllPetResult>>(pagedPets);
            return Success(mappedPets);
        }
        #endregion
    }
}
