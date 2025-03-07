using AutoMapper;
using MediatR;
using Product.Application.Commands;
using Product.Application.Responses;
using Product.Core.Entities;
using Product.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = _mapper.Map<Employee>(request);
            var newEmployee = await _employeeRepository.CreateEmployee(employeeEntity);
            var employeeResponse = _mapper.Map<EmployeeResponse>(newEmployee);
            return employeeResponse;
        }
    }
}
