using FluentValidation;

namespace CrudBackend.Features.EmployeeFeature.BulkAddEmployee
{
    public class BulkAddEmployeeValidation : AbstractValidator<BulkAddEmployeeRequestModel>
    {
        public BulkAddEmployeeValidation() { 
        }
    }
}
