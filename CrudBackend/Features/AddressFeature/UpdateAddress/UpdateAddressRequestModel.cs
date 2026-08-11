using MediatR;

namespace CrudBackend.Features.AddressFeature.UpdateAddress
{
    public class UpdateAddressRequestModel : IRequest<UpdateAddressResponseModel>
    {
        public AddOrUpdateAddressRepresentationalModel address { get; set; }
    }
}
