using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.EquipmentDTOs;
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
    public class EquipmentsControllerTests
    {
        private readonly Mock<IEquipmentService> _mockEquipmentService;
        private readonly Mock<ILogger<EquipmentsController>> _mockLogger;
        private readonly Mock<IMapper> _mockMapper;
        private readonly EquipmentsController _controller;
        public EquipmentsControllerTests()
        {
            _mockEquipmentService = new Mock<IEquipmentService>();
            _mockLogger = new Mock<ILogger<EquipmentsController>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new EquipmentsController(_mockEquipmentService.Object, _mockLogger.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllEquipmentsAsync_ReturnsOkResult_WithListOfEquipments()
        {
            // Arrange
            var equipments = new List<Equipment> { new Equipment { Id = 1, Name = "Excavator" } };
            var dataResult = new SuccessDataResult<List<Equipment>>(equipments);
            _mockEquipmentService.Setup(service => service.BusinessGetAllAsync()).ReturnsAsync(dataResult);

            // Act
            var result = await _controller.GetAllAdressesAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<SuccessDataResult<List<Equipment>>>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(equipments, returnValue.Data);
        }

        [Fact]
        public async Task GetAllEquipmentsAsync_ReturnsBadRequest_OnFailure()
        {
            // Arrange
            var dataResult = new ErrorDataResult<List<Equipment>>(null, "Error retrieving equipments");
            _mockEquipmentService.Setup(service => service.BusinessGetAllAsync()).ReturnsAsync(dataResult);

            // Act
            var result = await _controller.GetAllAdressesAsync();

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error retrieving equipments", badRequestResult.Value);
        }

        [Fact]
        public async Task GetEquipmentByIdAsync_ReturnsOkResult_WithEquipment()
        {
            // Arrange
            var equipment = new Equipment { Id = 1, Name = "Excavator" };
            var dataResult = new SuccessDataResult<Equipment>(equipment);
            _mockEquipmentService.Setup(service => service.BusinessGetByIdAsync(It.IsAny<int>())).ReturnsAsync(dataResult);

            // Act
            var result = await _controller.GetEquipmentByIdAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<SuccessDataResult<Equipment>>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(equipment, returnValue.Data);
        }

        [Fact]
        public async Task GetEquipmentByIdAsync_ReturnsBadRequest_OnFailure()
        {
            // Arrange
            var dataResult = new ErrorDataResult<Equipment>(null, "Error retrieving equipment");
            _mockEquipmentService.Setup(service => service.BusinessGetByIdAsync(It.IsAny<int>())).ReturnsAsync(dataResult);

            // Act
            var result = await _controller.GetEquipmentByIdAsync(1);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error retrieving equipment", badRequestResult.Value);
        }

        [Fact]
        public async Task CreateEquipmentAsync_ReturnsOkResult_WhenEquipmentIsCreated()
        {
            // Arrange
            var createDto = new CreateEquipmentDto { Name = "Excavator" };
            var equipment = new Equipment { Id = 1, Name = "Excavator" };
            var result = new SuccessResult("Equipment created successfully");
            _mockMapper.Setup(m => m.Map<Equipment>(createDto)).Returns(equipment);
            _mockEquipmentService.Setup(service => service.BusinessAddAsync(It.IsAny<Equipment>())).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.CreateEquipment(createDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<SuccessResult>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.True(returnValue.Success);
            Assert.Equal("Equipment created successfully", returnValue.Message);
        }

        [Fact]
        public async Task CreateEquipmentAsync_ReturnsBadRequest_OnFailure()
        {
            // Arrange
            var createDto = new CreateEquipmentDto { Name = "Excavator" };
            var equipment = new Equipment { Id = 1, Name = "Excavator" };
            var result = new ErrorResult("Error creating equipment");
            _mockMapper.Setup(m => m.Map<Equipment>(createDto)).Returns(equipment);
            _mockEquipmentService.Setup(service => service.BusinessAddAsync(It.IsAny<Equipment>())).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.CreateEquipment(createDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error creating equipment", badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateEquipmentAsync_ReturnsOkResult_WhenEquipmentIsUpdated()
        {
            // Arrange
            var equipment = new Equipment { Id = 1, Name = "Excavator" };
            var result = new SuccessResult("Equipment updated successfully");
            _mockEquipmentService.Setup(service => service.BusinessUpdateAsync(It.IsAny<Equipment>())).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.UpdateEquipment(equipment);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<SuccessResult>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.True(returnValue.Success);
            Assert.Equal("Equipment updated successfully", returnValue.Message);
        }

        [Fact]
        public async Task UpdateEquipmentAsync_ReturnsBadRequest_OnFailure()
        {
            // Arrange
            var equipment = new Equipment { Id = 1, Name = "Excavator" };
            var result = new ErrorResult("Error updating equipment");
            _mockEquipmentService.Setup(service => service.BusinessUpdateAsync(It.IsAny<Equipment>())).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.UpdateEquipment(equipment);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error updating equipment", badRequestResult.Value);
        }

        [Fact]
        public async Task DeleteEquipmentAsync_ReturnsOkResult_WhenEquipmentIsDeleted()
        {
            // Arrange
            var result = new SuccessResult("Equipment deleted successfully");
            _mockEquipmentService.Setup(service => service.BusinessDeleteAsync(It.IsAny<int>())).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.DeleteEquipmentAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<SuccessResult>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.True(returnValue.Success);
            Assert.Equal("Equipment deleted successfully", returnValue.Message);
        }

        [Fact]
        public async Task DeleteEquipmentAsync_ReturnsBadRequest_OnFailure()
        {
            // Arrange
            var result = new ErrorResult("Error deleting equipment");
            _mockEquipmentService.Setup(service => service.BusinessDeleteAsync(It.IsAny<int>())).ReturnsAsync(result);

            // Act
            var actionResult = await _controller.DeleteEquipmentAsync(1);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error deleting equipment", badRequestResult.Value);
        }
    }
}
