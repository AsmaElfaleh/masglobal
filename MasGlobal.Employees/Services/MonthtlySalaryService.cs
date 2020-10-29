using MasGlobal.Employees.DTO;

namespace MasGlobal.Employees.Services
{
    public class MonthtlySalaryService : ISalaryService
    {
        public double? CalculateAnnualSalary(Employee employee) => ((MonthlySalaryEmployee)employee).MonthlySalary * 12;
    }
}
