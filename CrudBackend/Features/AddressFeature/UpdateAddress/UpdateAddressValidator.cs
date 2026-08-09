using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using FluentValidation;

namespace CrudBackend.Features.AddressFeature.UpdateAddress
{
    public class UpdateAddressValidator : AbstractValidator<UpdateAddressRequestModel>
    {
        private readonly IRepository<Addresses> _addressesRepository;
        private readonly IRepository<Employee> _employeeRepository;
        public UpdateAddressValidator(IRepository<Addresses> addressesRepository, IRepository<Employee> employeeRepository) { 
                  _addressesRepository = addressesRepository;
            _employeeRepository = employeeRepository;
            RuleFor(x => x.address.id).NotEmpty().WithMessage("Id should not be empty or null")
          .Must(IsValidId).WithMessage("Id does not exist");
            RuleFor(x => x.address.employeeId).NotEmpty().WithMessage("It should not be null or empty")
                .Must(IsValidEmployeeId).WithMessage("Invalid Employee id");


        }

        private bool IsValidEmployeeId(int id)
        {
            return _employeeRepository.GetAllQueryable().Any(x => x.Id == id );
        }

        private bool IsValidId(int id)
        {
            return _addressesRepository.GetAllQueryable().Any(x => x.AddressId == id);
        }
    }
}
