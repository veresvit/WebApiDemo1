using System.Collections.Generic;
using System.Linq;
using WebApiDemo.Data.Dtos;
using WebApiDemo.Data.Models;

namespace WebApiDemo.Data.Repositories
{
    public class InMemoryEmployeesRepo : IEmployeesRepo
    {
        private static readonly List<Employee> _employees = new();

        public IEnumerable<Employee> GetEmployees(FilterEmployeeDto filter)
        {
            var filtered = _employees;

            if (filter == null) return filtered;

            var tempFiltered = (IEnumerable<Employee>)filtered;

            if (!string.IsNullOrEmpty(filter.Email)) tempFiltered = tempFiltered.Where(e => e.Email == filter.Email);

            if (!string.IsNullOrEmpty(filter.Name)) tempFiltered = tempFiltered.Where(e => e.Name == filter.Name);

            if (!string.IsNullOrEmpty(filter.Surname))
                tempFiltered = tempFiltered.Where(e => e.Surname == filter.Surname);

            if (!string.IsNullOrEmpty(filter.PhoneNumber))
                tempFiltered = tempFiltered.Where(e => e.PhoneNumber == filter.PhoneNumber);

            if (filter.MinStartDate != null) tempFiltered = tempFiltered.Where(e => e.StartDate >= filter.MinStartDate);

            if (filter.MaxStartDate != null) tempFiltered = tempFiltered.Where(e => e.StartDate <= filter.MinStartDate);

            filtered = tempFiltered.ToList();

            return filtered;
        }

        public Employee GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public void UpdateEmployee(Employee employee)
        {
            var employeeId = employee.Id;

            var storedEmployee = _employees.First(e => e.Id == employeeId);
            _employees.Remove(storedEmployee);

            employee.Id = employeeId;
            _employees.Add(employee);
        }

        public void CreateEmployee(Employee employee)
        {
            employee.Id = _employees.Count == 0 ? 0 : _employees[^1].Id + 1;
            _employees.Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            var storedEmployee = _employees.First(e => e.Id == employee.Id);
            _employees.Remove(storedEmployee);
        }
    }
}