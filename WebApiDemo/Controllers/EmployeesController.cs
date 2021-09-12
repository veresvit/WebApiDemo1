using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Data.Dtos;
using WebApiDemo.Data.Models;
using WebApiDemo.Data.Repositories;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeesRepo _repo;

        public EmployeesController(IMapper mapper, IEmployeesRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<EmployeeDto> GetEmployees([FromQuery] FilterEmployeeDto filter)
        {
            var employees = _repo.GetEmployees(filter);
            var responseItems = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return responseItems;
        }

        // GET: api/Employees/5
        [HttpGet("{id:int}", Name = "GetEmployeeById")]
        public ActionResult<EmployeeDto> GetEmployeeById([FromRoute] int id)
        {
            var employee = _repo.GetEmployeeById(id);
            if (employee == null) return NotFound();

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        // POST: api/Employees
        [HttpPost]
        public ActionResult<EmployeeDto> CreateEmployee([FromBody] CreateEmployeeDto createEmployee)
        {
            var employeeModel = _mapper.Map<Employee>(createEmployee);
            _repo.CreateEmployee(employeeModel);

            var employeeDto = _mapper.Map<EmployeeDto>(employeeModel);

            return CreatedAtRoute(nameof(GetEmployeeById), new { employeeDto.Id }, employeeDto);
        }

        // PUT: api/Employees/5
        [HttpPut("{id:int}")]
        public ActionResult UpdateEmployee([FromRoute] int id, [FromBody] UpdateEmployeeDto updateEmployee)
        {
            if (id != updateEmployee.Id) return BadRequest();

            var employee = _repo.GetEmployeeById(id);
            if (employee == null) return NotFound();

            _mapper.Map(updateEmployee, employee);

            _repo.UpdateEmployee(employee);

            return NoContent();
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id:int}")]
        public ActionResult DeleteEmployee([FromRoute] int id)
        {
            var employee = _repo.GetEmployeeById(id);
            if (employee == null) return NotFound();

            _repo.DeleteEmployee(employee);

            return NoContent();
        }
    }
}