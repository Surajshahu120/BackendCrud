using CrudBackend.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudBackend.Features.AddressFeature
{
    public class AddressRepresentationalModel
    {
        public int addressId { get; set; }
        public string? buildingNo { get; set; }
        public string? apartment { get; set; }
        public string? street { get; set; }
        public int employeeId { get; set; }
    }
}
