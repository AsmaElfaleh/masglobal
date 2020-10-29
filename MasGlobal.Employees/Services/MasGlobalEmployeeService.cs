using MasGlobal.Employees.DTO;
using MasGlobal.Employees.Mapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasGlobal.Employees.Services
{
    public interface IMasGlobalEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int id);
    }

    public class MasGlobalEmployeeService : IMasGlobalEmployeeService
    {
        private readonly IMasGlobalEmployeeApiService _masGlobalEmployeeApiService;
        private readonly IEmployeeMapperFactory _employeeMapperFactory;

        public MasGlobalEmployeeService(IMasGlobalEmployeeApiService masGlobalEmployeeApiService,

                                        IEmployeeMapperFactory employeeMapperFactory)
        {
            _masGlobalEmployeeApiService = masGlobalEmployeeApiService;
            _employeeMapperFactory = employeeMapperFactory;
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _masGlobalEmployeeApiService.GetEmployeeById(id);
            var employeeDTO = _employeeMapperFactory.GetEmployee(employee);
            return employeeDTO;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _masGlobalEmployeeApiService.GetEmployees();
            var employeesDTO = employees.Select(e => _employeeMapperFactory.GetEmployee(e));
            return employeesDTO;
        }
    }
}
