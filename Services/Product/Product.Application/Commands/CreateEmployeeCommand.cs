using MediatR;
using Product.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Commands
{
    public class CreateEmployeeCommand : IRequest<EmployeeResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public bool Resigned { get; set; }
        public Guid? DepartmentId { get; set; }  //Foreign key
    }
}
