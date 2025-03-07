using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Commands
{
    public class DeleteEmployeeByIdCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteEmployeeByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
