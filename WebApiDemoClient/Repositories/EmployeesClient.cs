using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebApiSharedDtos;

namespace WebApiDemoClient.Repositories
{
    public class EmployeesClient
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;

        private JsonSerializerOptions _options;

        public EmployeesClient(HttpClient client, string baseUrl)
        {
            _client = client;
            _baseUrl = baseUrl;

            _options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public async Task<List<EmployeeDto>> GetEmployeesByIds(List<int> ids)
        {
            List<EmployeeDto> employees = new List<EmployeeDto>();

            foreach (var id in ids)
            {
                try
                {
                    var streamTask = _client.GetStreamAsync($"{_baseUrl}/api/Employees/{id}");
                    var employee = await JsonSerializer.DeserializeAsync<EmployeeDto>(await streamTask, _options);

                    if (employee != null)
                    {
                        employees.Add(employee);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return employees;
        }
    }
}