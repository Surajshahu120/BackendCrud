using MediatR;

namespace CrudBackend.Features.AddressFeature.AddAddress
{
    public class AddAddressRequestModel :IRequest<AddAddressResponseModel>
    {
        public AddOrUpdateAddressRepresentationalModel address { get; set; }
    }
}
