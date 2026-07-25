namespace CrudBackend.Features.EmployeeFeature
{
    public class AddOrUpdateEmployeeRepresentationModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? age { get; set; }
        public string city { get; set; }
        public string gender { get; set; }
        public DateOnly birthday { get; set; }
        public bool isMarried { get; set; }
    }
}
