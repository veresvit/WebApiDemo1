using AutoMapper;
using WebApiDemo.Data.Dtos;
using WebApiDemo.Data.Models;

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