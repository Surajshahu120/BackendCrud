using MediatR;

namespace CrudBackend.Features.EmployeeFeature.UpdateEmployee
{
    public class UpdateEmployeeRequestModel : IRequest<UpdateEmployeeResponseModel>
    {public AddOrUpdateEmployeeRepresentationModel representationModel {get;set;}
    }
}
