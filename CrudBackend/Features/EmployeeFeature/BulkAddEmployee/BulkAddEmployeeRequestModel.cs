using MediatR;

namespace CrudBackend.Features.EmployeeFeature.BulkAddEmployee
{
    public class BulkAddEmployeeRequestModel : IRequest<BulkAddEmployeeRequestModel>
    {
        public List<AddOrUpdateEmployeeRepresentationModel> employee { get; set; }
    }
}
