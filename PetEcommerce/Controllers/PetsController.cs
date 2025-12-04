using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetEcommerce.Core.Feature.Pet.Command.Models;
using PetEcommerce.Core.Feature.Pet.Query.Models;
using PetEcommerce.Domain.BaseRoute;

namespace PetEcommerce.Api.Controllers
{

    [ApiController]
    public class PetsController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public PetsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods
        [HttpPost(ApiRoute.Pets.GetAllPets)]
        public async Task<IActionResult> GetAllPets(GetAllPetQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost(ApiRoute.Pets.CreatePet)]
        public async Task<IActionResult> CreatNewPet(CreatePetCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost(ApiRoute.Pets.UpdatePet)]
        public async Task<IActionResult> UpdatePet(UpdatePetCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost(ApiRoute.Pets.DeletePet)]
        public async Task<IActionResult> DeletePet(DeletePetCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        #endregion
    }
}
