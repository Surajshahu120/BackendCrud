using MediatR;

namespace CrudBackend.Features.EmployeeFeature.DeleteEmployeeById
{
    public class DeleteEmployeeByIdRequestModel : IRequest<DeleteEmployeeByIdResponseModel>
    {
        public int id { get; set; }
    }
}
