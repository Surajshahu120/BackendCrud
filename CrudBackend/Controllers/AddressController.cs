using CrudBackend.Features.AddressFeature.AddAddress;
using CrudBackend.Features.AddressFeature.DeleteAddress;
using CrudBackend.Features.AddressFeature.GetAddressById;
using CrudBackend.Features.AddressFeature.GetAllAddress;
using CrudBackend.Features.AddressFeature.UpdateAddress;
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
        [HttpGet]
        public async Task<ActionResult<GetAllAddressResponseModel>> GetAllAddress()
        {
            var req = await _mediator.Send(new GetAllAddressRequestModel());
            return Ok(req);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAddressByIdResponseModel>> GetAddressById([FromRoute]GetAddressByIdRequestModel request)
        {
            var req = await _mediator.Send(request);
            return Ok(req);
        }
        [HttpPut]
        public async Task<ActionResult<UpdateAddressResponseModel>> GetAllAddress([FromBody]UpdateAddressRequestModel request)
        {
            var req = await _mediator.Send(request);
            return Ok(req);
        }

    }
}
