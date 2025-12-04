using AutoMapper;
using MediatR;
using PetEcommerce.Core.Feature.Toy.Command.Models;
using PetEcommerce.Domain.BaseReponse;
using PetEcommerce.Service.BaseService;

namespace PetEcommerce.Core.Feature.Toy.Command.Handler
{
    public class ToyCommandHandler : ResponseHandler,
        IRequestHandler<CreateToyCommand, BaseResponse<bool>>,
        IRequestHandler<UpdateToyCommand, BaseResponse<bool>>,
        IRequestHandler<DeleteToyCommand, BaseResponse<bool>>
    {
        #region Fields
        private readonly IToyService _toyService;
        private readonly IMapper _mapper;
        private readonly IUploadFilesService _uploadFilesService;
        #endregion

        #region Constructor
        public ToyCommandHandler(IToyService toyService, IMapper mapper, IUploadFilesService uploadFiles)
        {
            _toyService = toyService;
            _mapper = mapper;
            _uploadFilesService = uploadFiles;
        }
        #endregion

        #region Methods
        public Task<BaseResponse<bool>> Handle(CreateToyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> Handle(UpdateToyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> Handle(DeleteToyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
