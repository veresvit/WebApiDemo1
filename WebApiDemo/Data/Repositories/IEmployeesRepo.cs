using System.Collections.Generic;
using WebApiDemo.Data.Models;
using WebApiSharedDtos;

namespace WebApiDemo.Data.Repositories
{
    public interface IEmployeesRepo
    {
        IEnumerable<Employee> GetEmployees(FilterEmployeeDto filter);

        Employee GetEmployeeById(int id);

        void UpdateEmployee(Employee employee);

        void CreateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);
    }
}