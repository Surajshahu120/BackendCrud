using MediatR;

namespace CrudBackend.Features.EmployeeFeature.AddEmployee
{
    public class AddEmployeeRequestModel : IRequest<AddEmployeeResponseModel>
    {
        public AddOrUpdateEmployeeRepresentationModel employee { get; set; }
    }
}
