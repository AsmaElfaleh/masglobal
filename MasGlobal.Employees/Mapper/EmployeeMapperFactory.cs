using AutoMapper;
using MasGlobal.Employees.DTO;
using MasGlobal.Employees.Services;
using System;

namespace MasGlobal.Employees.Mapper
{
    public interface IEmployeeMapperFactory
    {
        Employee GetEmployee(Models.Employee employee);
    }
    public class EmployeeMapperFactory : IEmployeeMapperFactory
    {
        private readonly IMapper _mapper;
        private readonly ISalaryServiceFactory _salaryServiceFactory;
        public EmployeeMapperFactory(IMapper mapper, ISalaryServiceFactory salaryServiceFactory)
        {
            _mapper = mapper;
            _salaryServiceFactory = salaryServiceFactory;
        }
        public Employee GetEmployee(Models.Employee employee)
        {
            Employee employeeDTO;
            switch (Enum.Parse(typeof(Enums.ContractType), employee.ContractTypeName))
            {
                case Enums.ContractType.HourlySalaryEmployee:
                    employeeDTO = _mapper.Map<HourlySalaryEmployee>(employee);
                    break;
                case Enums.ContractType.MonthlySalaryEmployee:
                    employeeDTO = _mapper.Map<MonthlySalaryEmployee>(employee);
                    break;
                default:
                    throw new System.Exception("Contract type not found");
            }
            employeeDTO.AnnualSalary = _salaryServiceFactory.GetSalaryService((Enums.ContractType)Enum.Parse(typeof(Enums.ContractType), employee.ContractTypeName)).CalculateAnnualSalary(employeeDTO);
            return employeeDTO;
        }
    }
}
