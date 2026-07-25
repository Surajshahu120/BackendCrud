using CrudBackend.Features.EmployeeFeature.AddEmployee;
using CrudBackend.Features.EmployeeFeature.DeleteEmployeeById;
using CrudBackend.Features.EmployeeFeature.GetAllEmployee;
using CrudBackend.Features.EmployeeFeature.GetAllEmployeeById;
using CrudBackend.Features.EmployeeFeature.GetEmployeeById;
using CrudBackend.Features.EmployeeFeature.UpdateEmployee;
using CrudBackend.Features.LoginFeature;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<AddEmployeeResponseModel>> AddEmployee([FromBody] AddEmployeeRequestModel request)
        {
            var data = await _mediator.Send(request);
            return data;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<GetAllEmployeeResponseModel>> GetAllEmployee()
        {
            var data = await _mediator.Send(new GetAllEmployeeRequestModel());
            return data;
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<GetEmployeeByIdResponseModel>> GetEmployeeById([FromRoute]GetEmployeeByIdRequestModel request)
        {
            var data= await _mediator.Send(request);
            return data;
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<DeleteEmployeeByIdResponseModel>> DeleteEmployee([FromRoute]DeleteEmployeeByIdRequestModel request)
        {
            var data = await _mediator.Send(request);
            return data;
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UpdateEmployeeResponseModel>> Handle(UpdateEmployeeRequestModel request)
        {
            var data = await _mediator.Send(request);
            return data;
        }
    }
}
