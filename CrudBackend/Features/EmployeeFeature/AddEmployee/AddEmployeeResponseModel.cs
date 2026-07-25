namespace CrudBackend.Features.EmployeeFeature.AddEmployee
{
    public class AddEmployeeResponseModel
    {
        public string message { get; set; } = "Data Added Successfully";
        public EmployeeRepresentationModel employeeData { get; set; }
    }
}
