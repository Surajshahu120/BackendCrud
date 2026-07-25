using CrudBackend.Features.EmployeeFeature.GetAllEmployee;
using CrudBackend.Features.EmployeeFeature.GetEmployeeById;
using MediatR;

namespace CrudBackend.Features.EmployeeFeature.GetAllEmployeeById
{
    public class GetEmployeeByIdRequestModel : IRequest<GetEmployeeByIdResponseModel>
    {
        public int id { get; set; }
    }
}
