using MasGlobal.Employees.Enums;
using System;

namespace MasGlobal.Employees.Services
{
    public interface ISalaryServiceFactory
    {
        ISalaryService GetSalaryService(ContractType contractType);
    }
    public class SalaryServiceFactory : ISalaryServiceFactory
    {
        private readonly IServiceProvider serviceProvider;

        public SalaryServiceFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ISalaryService GetSalaryService(ContractType contractType)
        {
            if (contractType == ContractType.HourlySalaryEmployee)
                return (ISalaryService)serviceProvider.GetService(typeof(HourlySalaryService));

            return (ISalaryService)serviceProvider.GetService(typeof(MonthtlySalaryService));
        }
    }
}
