using MediatR;

namespace CrudBackend.Features.EmployeeFeature.BulkAddEmployee
{
    public class BulkAddEmployeeRequestModel : IRequest<BulkAddEmployeeResponseModel>
    {
        public List<AddOrUpdateEmployeeRepresentationModel> employee { get; set; }
    }
}
