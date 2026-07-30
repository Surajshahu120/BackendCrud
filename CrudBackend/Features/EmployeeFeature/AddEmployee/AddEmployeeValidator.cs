using AutoMapper;
using FluentValidation;

namespace CrudBackend.Features.EmployeeFeature.AddEmployee
{
    public class AddEmployeeValidator : AbstractValidator<AddEmployeeRequestModel>
    {
        public AddEmployeeValidator() {
            RuleFor(x => x.employee.city).NotEmpty().WithMessage("City cannot be null");
            RuleFor(x => x.employee.age).GreaterThanOrEqualTo(18).WithMessage("Age greater than or equal to 18");
        }
    }
}
