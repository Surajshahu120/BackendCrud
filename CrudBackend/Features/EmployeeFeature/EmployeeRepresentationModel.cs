using CrudBackend.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudBackend.Features.EmployeeFeature
{
    public class EmployeeRepresentationModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? age { get; set; }
        public string city { get; set; }
        public string gender { get; set; }
        public DateOnly birthday { get; set; }
        public bool isMarried { get; set; }
        public ICollection<Addresses> addresses { get; set; }
    }
}
