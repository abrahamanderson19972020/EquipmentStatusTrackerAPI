using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.CustomerDTOs;
using Entities.DTOs.EquipmentStatusDTOs;
using EquipmentAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class EquipmentStatusesControllerTests
    {
        private readonly Mock<ICustomerService> _mockCustomerService;
        private readonly Mock<ILogger<CustomersController>> _mockLogger;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CustomersController _controller;
        public EquipmentStatusesControllerTests()
        {
            _mockCustomerService = new Mock<ICustomerService>();
            _mockLogger = new Mock<ILogger<CustomersController>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new CustomersController(_mockCustomerService.Object, _mockLogger.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task CreateCustomerAsync_ReturnsOkResult_WhenCustomerIsCreated()
        {
            // Arrange
            var createDto = new CreateCustomerDto { CustomerName = "John Doe" };
            var customer = new Customer { Id = 1, CustomerName = "John Doe" };
            var result = new SuccessResult("Customer created successfully");
            _mockMapper.Setup(m => m.Map<Customer>(createDto)).Returns(customer);
            _mockCustomerService.Setup(service => service.BusinessAddAsync(customer)).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.CreateCustomerAsync(createDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<SuccessResult>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.True(returnValue.Success);
            Assert.Equal("Customer created successfully", returnValue.Message);
        }

        [Fact]
        public async Task CreateCustomerAsync_ReturnsBadRequest_OnFailure()
        {
            // Arrange
            var createDto = new CreateCustomerDto { CustomerName = "John Doe" };
            var customer = new Customer { Id = 1, CustomerName = "John Doe" };
            var result = new ErrorResult("Error creating customer");
            _mockMapper.Setup(m => m.Map<Customer>(createDto)).Returns(customer);
            _mockCustomerService.Setup(service => service.BusinessAddAsync(customer)).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.CreateCustomerAsync(createDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error creating customer", badRequestResult.Value);
        }


        [Fact]
        public async Task UpdateCustomerAsync_ReturnsOkResult_WhenCustomerIsUpdated()
        {
            // Arrange
            var updateDto = new UpdateCustomerDto { Id = 1, CustomerName = "John Doe" };
            var result = new SuccessResult("Customer updated successfully");
            _mockCustomerService.Setup(service => service.BusinessUpdateWithDtoAsync(updateDto)).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.UpdateCustomerAsync(updateDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<SuccessResult>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.True(returnValue.Success);
            Assert.Equal("Customer updated successfully", returnValue.Message);
        }

        [Fact]
        public async Task UpdateCustomerAsync_ReturnsBadRequest_OnFailure()
        {
            // Arrange
            var updateDto = new UpdateCustomerDto { Id = 1, CustomerName = "John Doe" };
            var result = new ErrorResult("Error updating customer");
            _mockCustomerService.Setup(service => service.BusinessUpdateWithDtoAsync(updateDto)).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.UpdateCustomerAsync(updateDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error updating customer", badRequestResult.Value);
        }

        [Fact]
        public async Task DeleteCustomerAsync_ReturnsOkResult_WhenCustomerIsDeleted()
        {
            // Arrange
            var result = new SuccessResult("Customer deleted successfully");
            _mockCustomerService.Setup(service => service.BusinessDeleteAsync(It.IsAny<int>())).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.DeleteCustomerAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<SuccessResult>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.True(returnValue.Success);
            Assert.Equal("Customer deleted successfully", returnValue.Message);
        }

        [Fact]
        public async Task DeleteCustomerAsync_ReturnsBadRequest_OnFailure()
        {
            // Arrange
            var result = new ErrorResult("Error deleting customer");
            _mockCustomerService.Setup(service => service.BusinessDeleteAsync(It.IsAny<int>())).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.DeleteCustomerAsync(1);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error deleting customer", badRequestResult.Value);
        }
    }
}
