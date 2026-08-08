using MediatR;

namespace CrudBackend.Features.AddressFeature.DeleteAddress
{
    public class DeleteAddressRequestModel : IRequest<DeleteAddressResponseModel>
    {
        public int id { get; set; }
    }
}
