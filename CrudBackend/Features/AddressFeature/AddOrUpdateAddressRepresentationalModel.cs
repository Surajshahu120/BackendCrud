namespace CrudBackend.Features.AddressFeature
{
    public class AddOrUpdateAddressRepresentationalModel
    {
        public int id { get; set; }
        public string? buildingNo { get; set; }
        public string? apartment { get; set; }
        public string? street { get; set; }
        public int employeeId { get; set; }
    }
}
