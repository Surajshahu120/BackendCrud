namespace CrudBackend.Features.AddressFeature.AddAddress
{
    public class AddAddressResponseModel
    {
        public string message { get; set; } = "Data Added Successfully";
        public AddressRepresentationalModel address { get; set; }
    }
}
