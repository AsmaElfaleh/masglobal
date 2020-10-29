using MasGlobal.Employees.Enums;

namespace MasGlobal.Employees.DTO
{
    public abstract class Employee
    {
        public int? Id { get; set; }
        public ContractType ContractTypeName { get; set; }
        public string Name { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public double? AnnualSalary { get; set; }
    }
}
