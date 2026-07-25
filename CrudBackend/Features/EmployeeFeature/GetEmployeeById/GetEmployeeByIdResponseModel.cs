namespace CrudBackend.Features.EmployeeFeature.GetEmployeeById
{
    public class GetEmployeeByIdResponseModel
    {
        public string message { get; set; } = "Data Fetched Successfully";
        public EmployeeRepresentationModel employee {  get; set; }
    }
}
