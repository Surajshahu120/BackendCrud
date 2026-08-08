using CrudBackend.Features.AddressFeature.AddAddress;
using CrudBackend.Features.AddressFeature.DeleteAddress;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [HttpPost]
        public async Task<ActionResult<AddAddressResponseModel>> AddAddress([FromBody] AddAddressRequestModel request)
        {
            var req = await _mediator.Send(request);
            return Created(HttpStatusCode.Created.ToString(), req);
        }        
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteAddressResponseModel>> DeleteAddress([FromRoute] DeleteAddressRequestModel request)
        {
            var req = await _mediator.Send(request);
            return Accepted(req);
        }
    }
}
