using Product.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Responses
{
    public class EmployeeResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public bool Resigned { get; set; }
        public Guid? DepartmentId { get; set; }  //Foreign key
        public Department? Department { get; set; } //Navigation property
    }
}
