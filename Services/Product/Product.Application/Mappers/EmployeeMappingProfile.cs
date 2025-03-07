using AutoMapper;
using Product.Application.Commands;
using Product.Application.Queries;
using Product.Application.Responses;
using Product.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Mappers
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<CreateEmployeeCommand, Employee>()
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => "admin@test.com"))  
                .ForMember(dest => dest.CreatedDtTm, opt => opt.MapFrom(src => DateTime.UtcNow))  
                .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())  
                .ForMember(dest => dest.ModifiedDtTm, opt => opt.Ignore());

            CreateMap<Employee, EmployeeResponse>();

            CreateMap<GetEmployeeByIdQuery, Employee>();
        }
    }
}
