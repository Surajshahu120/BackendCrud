using FluentValidation;

namespace CrudBackend.Features.AddressFeature.AddAddress
{
    public class AddAddressValidator : AbstractValidator<AddAddressRequestModel>
    {
        public AddAddressValidator() {
        }
    }
}
