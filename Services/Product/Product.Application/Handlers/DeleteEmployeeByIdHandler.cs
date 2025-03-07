using MediatR;
using Product.Application.Commands;
using Product.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Handlers
{
    public class DeleteEmployeeByIdHandler : IRequestHandler<DeleteEmployeeByIdCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeByIdHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
        {
            var employeeFound = await _employeeRepository.GetEmployeeById(request.Id);

            if (employeeFound is null)
                throw new Exception("Employee not found");

            var response = await _employeeRepository.DeleteEmployee(employeeFound);

            return response > 0;
        }
    }
}
