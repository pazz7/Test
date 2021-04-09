using AutoMapper;
using Test.Application.Employees.Models;
using Test.Domain.Employees;

namespace Test.Application.Shared
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeCreateModel>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateModel>().ReverseMap();
            CreateMap<Employee, EmployeeGetModel>().ReverseMap();
        }
    }
}
