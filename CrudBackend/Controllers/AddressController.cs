using CrudBackend.Features.AddressFeature.DeleteAddress;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrudBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }        
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteAddressResponseModel>> DeleteAddress([FromRoute]DeleteAddressRequestModel request)
        {
            // Implementation for deleting address
            return Ok(_mediator.Send(request));
        }
    }
}
