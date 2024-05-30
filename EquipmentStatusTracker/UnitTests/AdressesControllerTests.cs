using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.AddressDTOs;
using EquipmentAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class AdressesControllerTests
    {
        private readonly Mock<IAddressService> _mockAddressService;
        private readonly Mock<ILogger<AddressesController>> _mockLogger;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AddressesController _controller;
        public AdressesControllerTests()
        {
            _mockAddressService = new Mock<IAddressService>();
            _mockLogger = new Mock<ILogger<AddressesController>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new AddressesController(_mockAddressService.Object, _mockLogger.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllAdressesAsync_ReturnsOkResult_WithListOfAddresses()
        {
            // Arrange
            var addresses = new List<Address> { new Address { Id = 1, City = "TestCity", Street = "TestStreet" } };
            var dataResult = new SuccessDataResult<List<Address>>(addresses);
            _mockAddressService.Setup(service => service.BusinessGetAllAsync()).ReturnsAsync(dataResult);

            // Act
            var result = await _controller.GetAllAdressesAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<SuccessDataResult<List<Address>>>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(addresses, returnValue.Data);
        }

        [Fact]
        public async Task GetAdressByIdAsync_ReturnsOkResult_WithAddress()
        {
            // Arrange
            var address = new Address { Id = 1, City = "TestCity", Street = "TestStreet" };
            var dataResult = new SuccessDataResult<Address>(address);
            _mockAddressService.Setup(service => service.BusinessGetByIdAsync(1)).ReturnsAsync(dataResult);

            // Act
            var result = await _controller.GetAdressByIdAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<SuccessDataResult<Address>>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(address, returnValue.Data);
        }

        [Fact]
        public async Task CreateAddress_ReturnsOkResult_WhenCreationIsSuccessful()
        {
            // Arrange
            var createAddressDto = new CreateAddressDto { City = "TestCity", Street = "TestStreet" };
            var address = new Address { Id = 1, City = "TestCity", Street = "TestStreet" };
            _mockMapper.Setup(m => m.Map<Address>(createAddressDto)).Returns(address);
            var result = new SuccessResult();
            _mockAddressService.Setup(service => service.BusinessAddAsync(address)).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.CreateAddress(createAddressDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public async Task UpdateAddress_ReturnsOkResult_WhenUpdateIsSuccessful()
        {
            // Arrange
            var address = new Address { Id = 1, City = "UpdatedCity", Street = "UpdatedStreet" };
            var result = new SuccessResult();
            _mockAddressService.Setup(service => service.BusinessUpdateAsync(address)).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.UpdateAddress(address);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public async Task DeleteAddressAsync_ReturnsOkResult_WhenDeletionIsSuccessful()
        {
            // Arrange
            var result = new SuccessResult();
            _mockAddressService.Setup(service => service.BusinessDeleteAsync(1)).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.DeleteAddressAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public async Task CreateAddress_ReturnsBadRequest_WhenCreationFails()
        {
            // Arrange
            var createAddressDto = new CreateAddressDto { City = "TestCity", Street = "TestStreet" };
            var address = new Address { Id = 1, City = "TestCity", Street = "TestStreet" };
            _mockMapper.Setup(m => m.Map<Address>(createAddressDto)).Returns(address);
            var result = new ErrorResult("Error message");
            _mockAddressService.Setup(service => service.BusinessAddAsync(address)).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.CreateAddress(createAddressDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error message", badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateAddress_ReturnsBadRequest_WhenUpdateFails()
        {
            // Arrange
            var address = new Address { Id = 1, City = "UpdatedCity", Street = "UpdatedStreet" };
            var result = new ErrorResult("Error message");
            _mockAddressService.Setup(service => service.BusinessUpdateAsync(address)).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.UpdateAddress(address);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error message", badRequestResult.Value);
        }

        [Fact]
        public async Task DeleteAddressAsync_ReturnsBadRequest_WhenDeletionFails()
        {
            // Arrange
            var result = new ErrorResult("Error message");
            _mockAddressService.Setup(service => service.BusinessDeleteAsync(1)).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.DeleteAddressAsync(1);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error message", badRequestResult.Value);
        }

    }
}
