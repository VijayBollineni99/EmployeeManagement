using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using PrjEmployeeManagement.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PrjEmployeeManagement.Unittests.ViewModels
{
    [TestClass]
    public class EmployeeViewModelTests
    {
        EmployeeService employeeService;

        [TestInitialize]
        public void TestInit()
        {
            employeeService = new EmployeeService();
        }

        [TestMethod]
        [TestCategory("GetAllEmployees")]
        public async Task GetAllEmployees_OKAsync()
        {
            // Arrange.
           

            // Act.
            var emp = await employeeService.GetEmployee(FakeCurrentEmployee());


            // Assert.
            Assert.IsNotNull(emp);
        }
        private Employee FakeCurrentEmployee()
        {
            return new Employee() { Id = 1, Name = "Test", Email = "Test@gamil.com", Gender = "male", Status = "Active" };
        }
    }
}
