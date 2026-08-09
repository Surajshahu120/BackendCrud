using MediatR;

namespace CrudBackend.Features.AddressFeature.GetAddressById
{
    public class GetAddressByIdRequestModel : IRequest<GetAddressByIdResponseModel>
    {
        public int id { get; set; }
    }
}
