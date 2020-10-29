using MasGlobal.Employees.Enums;
using MasGlobal.Employees.Mapper;
using MasGlobal.Employees.Models;
using MasGlobal.Employees.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MasGlobal.Employees.Test.Services
{
    [ExcludeFromCodeCoverage]
    public class MasGlobalEmployeeServiceTest
    {
        private IMasGlobalEmployeeService _masGlobalEmployeeService;
        private Mock<IMasGlobalEmployeeApiService> _masGlobalEmployeeApiServiceMock;
        private Mock<IEmployeeMapperFactory> _employeeMapperFactoryMock;

        [SetUp]
        public void SetUp()
        {
            _employeeMapperFactoryMock = new Mock<IEmployeeMapperFactory>();
            _masGlobalEmployeeApiServiceMock = new Mock<IMasGlobalEmployeeApiService>();
            _masGlobalEmployeeService = new MasGlobalEmployeeService(_masGlobalEmployeeApiServiceMock.Object, _employeeMapperFactoryMock.Object);
        }

        [Test]
        public void GivenAnId_WhenGetEmployeeById_ThenGetsEmployeeData()
        {
            //Given
            int id = 1;
            Employee employee = new Employee
            {
                ContractTypeName = ContractType.HourlySalaryEmployee.ToString(),
                HourlySalary = 1000,
                Id = 1,
                Name = "Test Name",
                RoleDescription = "Test Rol",
                RoleId = 1,
                RoleName = "Tester"
            };
            DTO.HourlySalaryEmployee employeeDTO = new DTO.HourlySalaryEmployee
            {
                ContractTypeName = ContractType.HourlySalaryEmployee,
                HourlySalary = 1000,
                Id = 1,
                Name = "Test Name",
                RoleDescription = "Test Rol",
                RoleId = 1,
                RoleName = "Tester"
            };
            _masGlobalEmployeeApiServiceMock.Setup(x => x.GetEmployeeById(id)).Returns(Task.FromResult(employee));
            _employeeMapperFactoryMock.Setup(x => x.GetEmployee(employee)).Returns(employeeDTO);

            //When
            var result = _masGlobalEmployeeService.GetEmployeeById(id);

            //Then
            Assert.IsNotNull(result);
            Assert.AreSame(result.Result, employeeDTO);
            _masGlobalEmployeeApiServiceMock.Setup(x => x.GetEmployeeById(id)).Verifiable();
            _employeeMapperFactoryMock.Setup(x => x.GetEmployee(employee)).Verifiable();
        }

        [Test]
        public void GivenAnId_WhenGetEmployeeById_ThenThrowsException()
        {
            //Given
            int id = 1;
            _masGlobalEmployeeApiServiceMock.Setup(x => x.GetEmployeeById(id)).Throws(new Exception("Test Exception"));

            //When 
            var result = _masGlobalEmployeeService.GetEmployeeById(id);

            //Then
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsFaulted);
        }

        [Test]
        public void GivenAnId_WhenGetGetEmployees_ThenGetsEmployeeData()
        {
            //Given
            int id = 1;
            Employee employee = new Employee
            {
                ContractTypeName = ContractType.MonthlySalaryEmployee.ToString(),
                MonthlySalary = 3000,
                Id = 1,
                Name = "Test Name",
                RoleDescription = "Test Rol",
                RoleId = 1,
                RoleName = "Tester"
            };
            DTO.MonthlySalaryEmployee employeeDTO = new DTO.MonthlySalaryEmployee
            {
                ContractTypeName = ContractType.MonthlySalaryEmployee,
                MonthlySalary = 3000,
                Id = 1,
                Name = "Test Name",
                RoleDescription = "Test Rol",
                RoleId = 1,
                RoleName = "Tester"
            };

            IEnumerable<Employee> employees = new List<Employee> { employee };
            List<DTO.Employee> employeeDTOs = new List<DTO.Employee> { employeeDTO };
            _masGlobalEmployeeApiServiceMock.Setup(x => x.GetEmployees()).Returns(Task.FromResult(employees));
            _employeeMapperFactoryMock.Setup(x => x.GetEmployee(It.IsAny<Employee>())).Returns(employeeDTO);

            //When
            var result = _masGlobalEmployeeService.GetEmployees();

            //Then
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Result.Count());
            Assert.AreSame(result.Result.ToArray()[0], employeeDTO);
            _masGlobalEmployeeApiServiceMock.Setup(x => x.GetEmployeeById(id)).Verifiable();
            _employeeMapperFactoryMock.Setup(x => x.GetEmployee(employee)).Verifiable();
        }

        [Test]
        public void GivenAnId_WhenGetEmployees_ThenThrowsException()
        {
            //Given
            int id = 1;
            _masGlobalEmployeeApiServiceMock.Setup(x => x.GetEmployees()).Throws(new Exception("Test Exception"));

            //When 
            var result = _masGlobalEmployeeService.GetEmployees();

            //Then
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsFaulted);
        }
    }
}
