namespace CrudBackend.Features.EmployeeFeature.BulkAddEmployee
{
    public class BulkAddEmployeeResponseModel
    {
        public string message { get; set; } = "Data Added Successfully";
        public List<AddOrUpdateEmployeeRepresentationModel> employeeData { get; set; }
    }
}
