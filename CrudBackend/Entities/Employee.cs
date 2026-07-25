using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudBackend.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string City { get; set; } = "Dombivli";
        public string Gender { get; set; }
        public DateOnly BirthDay { get; set; }
        public bool IsMarried { get; set; }
        public ICollection<Addresses> Addresses { get; set; }
    }
}
