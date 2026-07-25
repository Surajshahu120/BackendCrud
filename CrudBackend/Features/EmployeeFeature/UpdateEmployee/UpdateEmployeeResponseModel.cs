namespace CrudBackend.Features.EmployeeFeature.UpdateEmployee
{
    public class UpdateEmployeeResponseModel
    {
        public string message { get; set; } = "Data Updated Successfully";
        public EmployeeRepresentationModel employee { get; set; }
    }
}
