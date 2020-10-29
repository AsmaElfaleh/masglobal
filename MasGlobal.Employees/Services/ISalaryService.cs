using MasGlobal.Employees.DTO;

namespace MasGlobal.Employees.Services
{
    public interface ISalaryService
    {
        double? CalculateAnnualSalary(Employee employee);
    }
}
