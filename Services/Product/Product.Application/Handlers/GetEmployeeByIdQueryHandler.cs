using AutoMapper;
using MediatR;
using Product.Application.Queries;
using Product.Application.Responses;
using Product.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Handlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employeeFound = await _employeeRepository.GetEmployeeById(request.Id);

            if(employeeFound == null)
            {
                throw new Exception("Employee not found");
            }

            var response = _mapper.Map<EmployeeResponse>(employeeFound);
            return response;
        }
    }
}
