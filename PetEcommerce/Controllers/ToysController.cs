using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetEcommerce.Core.Feature.Toy.Query.Models;
using PetEcommerce.Domain.BaseRoute;

namespace PetEcommerce.Api.Controllers
{
    [ApiController]
    public class ToysController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public ToysController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods
        [HttpPost(ApiRoute.Toys.GetAllToys)]
        public async Task<IActionResult> GetAllToys(GetAllToyQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        #endregion
    }
}
