using System.ComponentModel;

namespace Product.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public bool Resigned { get; set; }
        public Guid? DepartmentId { get; set; }  //Foreign key
        public Department? Department { get; set; } //Navigation property
        public string CreatedBy { get; set; }
        public DateTime CreatedDtTm { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDtTm { get; set; }
    }
}
