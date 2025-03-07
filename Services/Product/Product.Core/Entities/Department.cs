using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Product.Core.Entities
{
    public class Department : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<Employee> Employees { get; set; }        //Fluent validation

        [Required]
        [MaxLength(100)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDtTm { get; set; }

        [MaxLength(100)]
        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDtTm { get; set; }
    }
}
