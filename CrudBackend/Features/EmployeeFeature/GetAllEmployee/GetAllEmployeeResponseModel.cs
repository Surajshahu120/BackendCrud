namespace CrudBackend.Features.EmployeeFeature.GetAllEmployee
{
    public class GetAllEmployeeResponseModel
    {
        public string message { get; set; } = "Data Fetched Successfully";
        public IEnumerable<EmployeeRepresentationModel> Employees { get; set; }
    }
}
