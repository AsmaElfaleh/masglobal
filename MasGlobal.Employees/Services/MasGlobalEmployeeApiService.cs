using MasGlobal.Employees.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MasGlobal.Employees.Services
{
    public interface IMasGlobalEmployeeApiService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int id);
    }
    public class MasGlobalEmployeeApiService : IMasGlobalEmployeeApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly Settings _settings;

        public MasGlobalEmployeeApiService(IOptions<Settings> settings, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _settings = settings.Value;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await GetEmployeesFromMasGlobalApi();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employees = await GetEmployeesFromMasGlobalApi();
            return employees.Where(e => e.Id == id).FirstOrDefault();
        }

        private async Task<IEnumerable<Employee>> GetEmployeesFromMasGlobalApi()
        {
            var httpClient = _clientFactory.CreateClient();
            var employees = await httpClient.GetFromJsonAsync<IEnumerable<Employee>>(_settings.MasGlobalEmployeeApiUrl);
            return employees;
        }

    }
}
