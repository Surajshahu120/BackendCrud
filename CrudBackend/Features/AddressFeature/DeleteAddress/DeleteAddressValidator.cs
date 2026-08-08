using FluentValidation;
using CrudBackend.RepositoryPattern;
using CrudBackend.Entities;

namespace CrudBackend.Features.AddressFeature.DeleteAddress
{
    public class DeleteAddressValidator : AbstractValidator<DeleteAddressRequestModel>
    {
        private readonly IRepository<Addresses> _repository;

        public DeleteAddressValidator(IRepository<Addresses> repository)
        {
            _repository = repository;
            RuleFor(x => x.id)
                .NotEmpty().WithMessage("Address ID should not be null or empty")
                .Must(IsValidId).WithMessage("Invalid address ID");
        }

        private bool IsValidId(int id)
        {
            return _repository.GetAllQueryable().Any(x => x.AddressId == id);
        }
    }
}
