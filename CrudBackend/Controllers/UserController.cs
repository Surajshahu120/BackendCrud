using CrudBackend.Features.LoginFeature;
using CrudBackend.Features.UserFeature.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("CreateUser")]
        public async Task<ActionResult<CreateUserResponseModel>> CreateUser([FromBody] CreateUserRequestModel request)
        {
            var data = await _mediator.Send(request);
            return data;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("LogIn")]
        public async Task<ActionResult<LoginResponseModel>> Login([FromBody] LoginRequestModel request)
        {
            var data = await _mediator.Send(request);
            return data;
        }
    }
}
