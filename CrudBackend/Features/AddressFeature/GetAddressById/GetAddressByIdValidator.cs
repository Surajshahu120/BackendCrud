using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using FluentValidation;

namespace CrudBackend.Features.AddressFeature.GetAddressById
{
    public class GetAddressByIdValidator : AbstractValidator<GetAddressByIdRequestModel>
    {
        private readonly IRepository<Addresses> _repository;

        public GetAddressByIdValidator(IRepository<Addresses> repository)
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
