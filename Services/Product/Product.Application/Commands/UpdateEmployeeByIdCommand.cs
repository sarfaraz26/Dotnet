using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Commands
{
    public class UpdateEmployeeByIdCommand : IRequest<bool>
    {
        public UpdateEmployeeByIdCommand(Guid id, string? email, bool? isResigned)
        {
            Id = id;
            Email = email;
            IsResigned = isResigned;
        }

        public Guid Id { get; set; } = Guid.Empty;
        public string? Email { get; set; }
        public bool? IsResigned { get; set; }
    }
}
