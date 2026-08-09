namespace CrudBackend.Features.AddressFeature.GetAllAddress
{
    public class GetAllAddressResponseModel
    {
        public string message { get; set; }
        public List<AddressRepresentationalModel> address { get; set; }

    }
}
