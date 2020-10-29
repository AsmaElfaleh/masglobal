using MasGlobal.Employees.DTO;

namespace MasGlobal.Employees.Services
{
    public class HourlySalaryService : ISalaryService
    {
        public double? CalculateAnnualSalary(Employee employee) => 120 * ((HourlySalaryEmployee)employee).HourlySalary * 12;
    }
}
