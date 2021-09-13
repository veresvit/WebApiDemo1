using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApiDemoClient.Repositories;

namespace WebApiDemoClient
{
    class Program
    {
        private static readonly HttpClient Client = new HttpClient();
        private static readonly string BaseUrl = "https://localhost:5001";


        static async Task Main(string[] args)
        {
            var client = new EmployeesClient(Client, BaseUrl);
            var employees = await client.GetEmployeesByIds(new[] { 1, 2, 3, 4, 5, 6, 7 }.ToList());

            Console.WriteLine($"Employees found: {employees.Count}");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}