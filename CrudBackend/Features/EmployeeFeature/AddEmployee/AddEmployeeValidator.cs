using AutoMapper;
using FluentValidation;

namespace CrudBackend.Features.EmployeeFeature.AddEmployee
{
    public class AddEmployeeValidator : AbstractValidator<AddEmployeeRequestModel>
    {
        public AddEmployeeValidator() { 
            
        }
    }
}
