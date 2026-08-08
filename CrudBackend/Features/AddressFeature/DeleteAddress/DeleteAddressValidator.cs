using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using FluentValidation;

namespace CrudBackend.Features.AddressFeature.DeleteAddress
{
    public class DeleteAddressValidator : AbstractValidator<DeleteAddressRequestModel>
    {
        private readonly IRepository<Addresses> _addressRepository;
        public DeleteAddressValidator(IRepository<Addresses> addressRepository)
        {
            _addressRepository = addressRepository;
            RuleFor(x => x.id).NotEmpty().WithMessage("Id cannot br null or empty")
                .Must(IsvalidId).WithMessage("Invalid Id");
        }

        private bool IsvalidId(int id)
        {
            return _addressRepository.GetAllQueryable().Any(x => x.AddressId == id);
        }
    }
}
