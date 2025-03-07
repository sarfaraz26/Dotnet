using AutoMapper;
using MediatR;
using Product.Application.Commands;
using Product.Core.Entities;
using Product.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Handlers
{
    public class UpdateEmployeeByIdHandler : IRequestHandler<UpdateEmployeeByIdCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeByIdHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateEmployeeByIdCommand request, CancellationToken cancellationToken)
        {
            var employeeFound = await _employeeRepository.GetEmployeeById(request.Id);

            if(employeeFound is null)
            {
                throw new Exception($"Employee with id - {request.Id} not found");
            }
            else
            {
                employeeFound.Email = request.Email;
                employeeFound.Resigned = (bool)request.IsResigned;

                var response = await _employeeRepository.UpdateEmployee(employeeFound);
                return response > 0;
            }
        }
    }

}
