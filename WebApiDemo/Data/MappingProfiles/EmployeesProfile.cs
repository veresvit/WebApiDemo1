using AutoMapper;
using WebApiDemo.Data.Models;
using WebApiSharedDtos;

namespace WebApiDemo.Data.MappingProfiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
        }
    }
}