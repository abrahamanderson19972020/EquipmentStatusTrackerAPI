using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.CommunicationDetailDTOs;
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
    public class CommunicationDetailsControllerTests
    {
        private readonly Mock<ICommunicationDetailService> _mockCommunicationDetailService;
        private readonly Mock<ILogger<CommunicationDetailsController>> _mockLogger;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CommunicationDetailsController _controller;
        public CommunicationDetailsControllerTests()
        {
            _mockCommunicationDetailService = new Mock<ICommunicationDetailService>();
            _mockLogger = new Mock<ILogger<CommunicationDetailsController>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new CommunicationDetailsController(_mockCommunicationDetailService.Object, _mockLogger.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllCommunicationDetailsAsync_ReturnsOkResult_WithListOfCommunicationDetails()
        {
            // Arrange
            var communicationDetails = new List<CommunicationDetail> { new CommunicationDetail { Id = 1, Email = "test@example.com", PhoneNumber = "1234567890" } };
            var dataResult = new SuccessDataResult<List<CommunicationDetail>>(communicationDetails);
            _mockCommunicationDetailService.Setup(service => service.BusinessGetAllWithAdressesAsync()).ReturnsAsync(dataResult);

            // Act
            var result = await _controller.GetAllCommunicationDetailsAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<SuccessDataResult<List<CommunicationDetail>>>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(communicationDetails, returnValue.Data);
        }

        [Fact]
        public async Task GetCommunicationDetailByIdAsync_ReturnsOkResult_WithCommunicationDetail()
        {
            // Arrange
            var communicationDetail = new CommunicationDetail { Id = 1, Email = "test@example.com", PhoneNumber = "1234567890" };
            var dataResult = new SuccessDataResult<CommunicationDetail>(communicationDetail);
            _mockCommunicationDetailService.Setup(service => service.BusinessGetCommunicationDetailWithAddressByIdAsync(It.IsAny<int>())).ReturnsAsync(dataResult);

            // Act
            var result = await _controller.GetCommunicationDetailByIdAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<SuccessDataResult<CommunicationDetail>>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(communicationDetail, returnValue.Data);
        }

        [Fact]
        public async Task CreateCommunicationDetailAsync_ReturnsOkResult_WhenCommunicationDetailIsCreated()
        {
            // Arrange
            var createDto = new CreateCommunicationDetailDto { Email = "test@example.com", PhoneNumber = "1234567890", AddressId = 1 };
            var communicationDetail = new CommunicationDetail { Id = 1, Email = "test@example.com", PhoneNumber = "1234567890", AddressId = 1 };
            var result = new SuccessResult("Communication detail created successfully");
            _mockMapper.Setup(m => m.Map<CommunicationDetail>(createDto)).Returns(communicationDetail);
            _mockCommunicationDetailService.Setup(service => service.BusinessAddAsync(It.IsAny<CommunicationDetail>())).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.CreateCommunicationDetailAsync(createDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<SuccessResult>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.True(returnValue.Success);
            Assert.Equal("Communication detail created successfully", returnValue.Message);
        }

        [Fact]
        public async Task UpdateCommunicationDetailAsync_ReturnsOkResult_WhenCommunicationDetailIsUpdated()
        {
            // Arrange
            var updateDto = new UpdateCommunicationDetailDto { Id = 1, Email = "test@example.com", PhoneNumber = "1234567890", AddressId = 1 };
            var communicationDetail = new CommunicationDetail { Id = 1, Email = "test@example.com", PhoneNumber = "1234567890", AddressId = 1 };
            var result = new SuccessResult("Communication detail updated successfully");
            _mockMapper.Setup(m => m.Map<CommunicationDetail>(updateDto)).Returns(communicationDetail);
            _mockCommunicationDetailService.Setup(service => service.BusinessUpdateAsync(It.IsAny<CommunicationDetail>())).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.UpdateCommunicationDetailAsync(updateDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<SuccessResult>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.True(returnValue.Success);
            Assert.Equal("Communication detail updated successfully", returnValue.Message);
        }

        [Fact]
        public async Task DeleteCommunicationDetailAsync_ReturnsOkResult_WhenCommunicationDetailIsDeleted()
        {
            // Arrange
            var result = new SuccessResult("Communication detail deleted successfully");
            _mockCommunicationDetailService.Setup(service => service.BusinessDeleteAsync(It.IsAny<int>())).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.DeleteCommunicationDetailAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<SuccessResult>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.True(returnValue.Success);
            Assert.Equal("Communication detail deleted successfully", returnValue.Message);
        }

        [Fact]
        public async Task GetAllCommunicationDetailsAsync_ReturnsBadRequest_OnFailure()
        {
            // Arrange
            var dataResult = new ErrorDataResult<List<CommunicationDetail>>(null, "Error retrieving communication details");
            _mockCommunicationDetailService.Setup(service => service.BusinessGetAllWithAdressesAsync()).ReturnsAsync(dataResult);

            // Act
            var result = await _controller.GetAllCommunicationDetailsAsync();

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error retrieving communication details", badRequestResult.Value);
        }

        [Fact]
        public async Task GetCommunicationDetailByIdAsync_ReturnsBadRequest_OnFailure()
        {
            // Arrange
            var dataResult = new ErrorDataResult<CommunicationDetail>(null, "Error retrieving communication detail");
            _mockCommunicationDetailService.Setup(service => service.BusinessGetCommunicationDetailWithAddressByIdAsync(It.IsAny<int>())).ReturnsAsync(dataResult);

            // Act
            var result = await _controller.GetCommunicationDetailByIdAsync(1);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error retrieving communication detail", badRequestResult.Value);
        }

        [Fact]
        public async Task CreateCommunicationDetailAsync_ReturnsBadRequest_OnFailure()
        {
            // Arrange
            var createDto = new CreateCommunicationDetailDto { Email = "test@example.com", PhoneNumber = "1234567890", AddressId = 1 };
            var communicationDetail = new CommunicationDetail { Id = 1, Email = "test@example.com", PhoneNumber = "1234567890", AddressId = 1 };
            var result = new ErrorResult("Error creating communication detail");
            _mockMapper.Setup(m => m.Map<CommunicationDetail>(createDto)).Returns(communicationDetail);
            _mockCommunicationDetailService.Setup(service => service.BusinessAddAsync(It.IsAny<CommunicationDetail>())).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.CreateCommunicationDetailAsync(createDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error creating communication detail", badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateCommunicationDetailAsync_ReturnsBadRequest_OnFailure()
        {
            // Arrange
            var updateDto = new UpdateCommunicationDetailDto { Id = 1, Email = "test@example.com", PhoneNumber = "1234567890", AddressId = 1 };
            var communicationDetail = new CommunicationDetail { Id = 1, Email = "test@example.com", PhoneNumber = "1234567890", AddressId = 1 };
            var result = new ErrorResult("Error updating communication detail");
            _mockMapper.Setup(m => m.Map<CommunicationDetail>(updateDto)).Returns(communicationDetail);
            _mockCommunicationDetailService.Setup(service => service.BusinessUpdateAsync(It.IsAny<CommunicationDetail>())).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.UpdateCommunicationDetailAsync(updateDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error updating communication detail", badRequestResult.Value);
        }

        [Fact]
        public async Task DeleteCommunicationDetailAsync_ReturnsBadRequest_OnFailure()
        {
            // Arrange
            var result = new ErrorResult("Error deleting communication detail");
            _mockCommunicationDetailService.Setup(service => service.BusinessDeleteAsync(It.IsAny<int>())).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.DeleteCommunicationDetailAsync(1);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error deleting communication detail", badRequestResult.Value);
        }
    }
}
