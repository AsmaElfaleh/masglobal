using AutoMapper;
using MasGlobal.Employees.Models;

namespace MasGlobal.Employees.Mapper
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<Employee, DTO.HourlySalaryEmployee>();
            CreateMap<Employee, DTO.MonthlySalaryEmployee>();
        }
    }
}
