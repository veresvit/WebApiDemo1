using System.Collections.Generic;
using System.Linq;
using WebApiDemo.Data.Dtos;
using WebApiDemo.Data.Models;

namespace WebApiDemo.Data.Repositories
{
    public class EmployeesRepo : IEmployeesRepo
    {
        private readonly AppDbContext _context;

        public EmployeesRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployees(FilterEmployeeDto filter)
        {
            var query = _context.Employees.AsQueryable();

            if (filter == null) return query.ToList();

            if (!string.IsNullOrEmpty(filter.Email))
            {
                query = query.Where(e => e.Email == filter.Email);
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(e => e.Name == filter.Name);
            }

            if (!string.IsNullOrEmpty(filter.Surname))
            {
                query = query.Where(e => e.Surname == filter.Surname);
            }

            if (!string.IsNullOrEmpty(filter.PhoneNumber))
            {
                query = query.Where(e => e.PhoneNumber == filter.PhoneNumber);
            }

            if (filter.MinStartDate != null)
            {
                query = query.Where(e => e.StartDate >= filter.MinStartDate);
            }

            if (filter.MaxStartDate != null)
            {
                query = query.Where(e => e.StartDate <= filter.MinStartDate);
            }

            return query.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.Find(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            // Changes were made to the entity by automapper
            _context.SaveChanges();
        }

        public void CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            _context.Remove(employee);
            _context.SaveChanges();
        }
    }
}