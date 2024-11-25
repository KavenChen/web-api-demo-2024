using Xunit;
using WebApiDemo.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Entity.DAOs;
using NSubstitute;
using WebApiDemo.Data.Interfaces;

namespace WebApiDemo.Service.Services.Test
{
    public class EmployeeServiceTest
    {
        [Fact()]
        public async void GetEmployeeAsync_WhenEmployeeExistsShouldSuccess_Test()
        {
            // Arrange
            var mockEmployeeRepository = Substitute.For<IEmployeeRepository>();
            var employeeService = new EmployeeService(mockEmployeeRepository);
            var employeeId = 1234;
            mockEmployeeRepository.GetEmployeeAsync(Arg.Any<long>()).ReturnsForAnyArgs(Task.FromResult(new Employee()));

            // Act
            var result = await employeeService.GetEmployeeAsync(employeeId);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.True(result.IsSuccess);
            Xunit.Assert.NotNull(result.Data);
            Xunit.Assert.Equal(string.Empty, result.Error);
            await mockEmployeeRepository.Received(1).GetEmployeeAsync(Arg.Is<long>(x => x == employeeId));
        }

        [Fact()]
        public async void GetEmployeeAsync_WhenEmployeeNotExistsShouldFail_Test()
        {
            // Arrange
            var mockEmployeeRepository = Substitute.For<IEmployeeRepository>();
            var employeeService = new EmployeeService(mockEmployeeRepository);
            var employeeId = 1234;
            mockEmployeeRepository.GetEmployeeAsync(Arg.Any<long>()).ReturnsForAnyArgs(Task.FromResult(default(Employee)));

            // Act
            var result = await employeeService.GetEmployeeAsync(employeeId);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.False(result.IsSuccess);
            Xunit.Assert.Null(result.Data);
            Xunit.Assert.Equal("GetEmployeeAsync Failed: employee not found.", result.Error);
            await mockEmployeeRepository.Received(1).GetEmployeeAsync(Arg.Is<long>(x => x == employeeId));
        }

        [Fact()]
        public async void CreateEmployeeAsync_CreateEmployeeNameShouldBeCorrect_Test()
        {
            // Arrange
            var mockEmployeeRepository = Substitute.For<IEmployeeRepository>();
            var employeeService = new EmployeeService(mockEmployeeRepository);
            var userName = "TestEmployee";

            // Act
            var result = await employeeService.CreateEmployeeAsync(userName);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.True(result.IsSuccess);
            Xunit.Assert.Equal(string.Empty, result.Error);
            await mockEmployeeRepository.Received(1).CreateEmployeeAsync(Arg.Is<Employee>(x => x.Name == userName));
        }

        [Fact()]
        public async void UpdateEmployeeAsync_WhenEmployeeExistsShouldBeSuccess_Test()
        {
            // Arrange
            var mockEmployeeRepository = Substitute.For<IEmployeeRepository>();
            var employeeService = new EmployeeService(mockEmployeeRepository);
            var employeeId = 1234;
            var userName = "TestEmployee";
            mockEmployeeRepository.UpdateEmployeeAsync(Arg.Any<long>(), Arg.Any<string>()).ReturnsForAnyArgs(Task.FromResult(1));

            // Act
            var result = await employeeService.UpdateEmployeeAsync(employeeId, userName);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.True(result.IsSuccess);
            Xunit.Assert.Equal(string.Empty, result.Error);
            await mockEmployeeRepository.Received(1).UpdateEmployeeAsync(Arg.Is<long>(x => x == employeeId), Arg.Is<string>(x => x == userName));
        }

        [Fact()]
        public async void UpdateEmployeeAsync_WhenEmployeeNotExistsShouldBeFail_Test()
        {
            // Arrange
            var mockEmployeeRepository = Substitute.For<IEmployeeRepository>();
            var employeeService = new EmployeeService(mockEmployeeRepository);
            var employeeId = 1234;
            var userName = "TestEmployee";
            mockEmployeeRepository.UpdateEmployeeAsync(Arg.Any<long>(), Arg.Any<string>()).ReturnsForAnyArgs(Task.FromResult(0));

            // Act
            var result = await employeeService.UpdateEmployeeAsync(employeeId, userName);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.False(result.IsSuccess);
            Xunit.Assert.Equal("UpdateEmployeeAsync Failed: update count is 0.", result.Error);
            await mockEmployeeRepository.Received(1).UpdateEmployeeAsync(Arg.Is<long>(x => x == employeeId), Arg.Is<string>(x => x == userName));
        }

        [Fact()]
        public async void DeleteEmployeeAsync_WhenEmployeeExistsShouldBeSuccess_Test()
        {
            // Arrange
            var mockEmployeeRepository = Substitute.For<IEmployeeRepository>();
            var employeeService = new EmployeeService(mockEmployeeRepository);
            var employeeId = 1234;
            mockEmployeeRepository.DeleteEmployeeAsync(Arg.Any<long>()).ReturnsForAnyArgs(Task.FromResult(1));

            // Act
            var result = await employeeService.DeleteEmployeeAsync(employeeId);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.True(result.IsSuccess);
            Xunit.Assert.Equal(string.Empty, result.Error);
            await mockEmployeeRepository.Received(1).DeleteEmployeeAsync(Arg.Is<long>(x => x == employeeId));
        }

        [Fact()]
        public async void DeleteEmployeeAsync_WhenEmployeeNotExistsShouldBeFail_Test()
        {
            // Arrange
            var mockEmployeeRepository = Substitute.For<IEmployeeRepository>();
            var employeeService = new EmployeeService(mockEmployeeRepository);
            var employeeId = 1234;
            mockEmployeeRepository.DeleteEmployeeAsync(Arg.Any<long>()).ReturnsForAnyArgs(Task.FromResult(0));

            // Act
            var result = await employeeService.DeleteEmployeeAsync(employeeId);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.False(result.IsSuccess);
            Xunit.Assert.Equal("DeleteEmployeeAsync Failed: delete count is 0.", result.Error);
            await mockEmployeeRepository.Received(1).DeleteEmployeeAsync(Arg.Is<long>(x => x == employeeId));
        }
    }
}