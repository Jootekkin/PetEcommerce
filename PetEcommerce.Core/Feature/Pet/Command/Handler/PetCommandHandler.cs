using AutoMapper;
using MediatR;
using PetEcommerce.Core.Feature.Pet.Command.Models;
using PetEcommerce.Domain.BaseReponse;
using PetEcommerce.Service.BaseService;
using System.Net;

namespace PetEcommerce.Core.Feature.Pet.Command.Handler
{
    public class PetCommandHandler : ResponseHandler,
        IRequestHandler<CreatePetCommand, BaseResponse<bool>>,
        IRequestHandler<UpdatePetCommand, BaseResponse<bool>>,
        IRequestHandler<DeletePetCommand, BaseResponse<bool>>
    {
        #region Fields
        private readonly IPetService _petService;
        private readonly IMapper _mapper;
        private readonly IUploadFilesService _uploadFilesService;
        #endregion

        #region Constructors
        public PetCommandHandler(IPetService petService, IMapper mapper, IUploadFilesService uploadFilesService)
        {
            _petService = petService;
            _mapper = mapper;
            _uploadFilesService = uploadFilesService;
        }
        #endregion

        #region Methods

        public async Task<BaseResponse<bool>> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            var newPet = _mapper.Map<Domain.Models.Pet>(request);

            var result = await _petService.CreatePetAsync(newPet);

            if (!result)
                return Failure<bool>(HttpStatusCode.BadRequest, "Failed to create resource.");

            _uploadFilesService.UploadFiles(request.ImageUrl, request.Name, newPet.Id);

            return Created<bool>();
        }

        public async Task<BaseResponse<bool>> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
        {
            var newPet = _mapper.Map<Domain.Models.Pet>(request);

            var result = await _petService.UpdatePetAsync(newPet);
            if (!result)
                return Failure<bool>(HttpStatusCode.BadRequest, "Failed to create resource.");
            return Updated<bool>();
        }

        public async Task<BaseResponse<bool>> Handle(DeletePetCommand request, CancellationToken cancellationToken)
        {
            var result = await _petService.DeletePetAsync(request.Id);
            if (!result)
                return Failure<bool>(HttpStatusCode.BadRequest, "Failed to create resource.");
            return Deleted<bool>();
        }
        #endregion

        #region Helper

        #endregion
    }
}
