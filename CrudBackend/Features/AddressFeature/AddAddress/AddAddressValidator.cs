using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using FluentValidation;

namespace CrudBackend.Features.AddressFeature.AddAddress
{
    public class AddAddressValidator : AbstractValidator<AddAddressRequestModel>
    {
        private readonly IRepository<Employee> _employeeRepository;
        public AddAddressValidator(IRepository<Employee> employeeRepository) {
            _employeeRepository = employeeRepository;
            RuleFor(x => x.address.employeeId).NotEmpty().WithMessage("It cannot be null or empty")
                .Must(IsValidId).WithMessage("employee id does not exist");
        }
        public bool IsValidId(int id)
        {
            var data = _employeeRepository.GetDataById(id);
            if (data == null) { 
            return false;
            }
            return true;
        }
    }
}
