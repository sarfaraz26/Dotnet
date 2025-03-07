using MediatR;
using Product.Application.Responses;
using Product.Core.Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeResponse>>
    {
        public Pagination Pagination { get; set; }

        public GetAllEmployeesQuery(Pagination pagination)
        {
            Pagination = pagination;
        }
    }
}
