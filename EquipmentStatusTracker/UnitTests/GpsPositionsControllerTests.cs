using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.GpsPositionDTOs;
using EquipmentAPI.Controllers;
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
    public class GpsPositionsControllerTests
    {
        private readonly GpsPositionsController _controller;
        private readonly Mock<IGpsPositionService> _mockService = new Mock<IGpsPositionService>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<ILogger<GpsPositionsController>> _mockLogger = new Mock<ILogger<GpsPositionsController>>();
        public GpsPositionsControllerTests()
        {
            _controller = new GpsPositionsController(_mockService.Object, _mockLogger.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllGpsPositions_ReturnsOk_WhenServiceReturnsData()
        {
            // Arrange
            var gpsPositions = new List<GpsPosition>
            {
                new GpsPosition { Id = 1, Latitude = 40.7128, Longitude = -74.0060, Timestamp = DateTime.Now, EquipmentStatusId = 1 },
                new GpsPosition { Id = 2, Latitude = 34.0522, Longitude = -118.2437, Timestamp = DateTime.Now, EquipmentStatusId = 2 },
                // Add more sample data as needed
            };
            var dataResult = new SuccessDataResult<List<ResultGpsPositionDto>>(_mockMapper.Object.Map<List<ResultGpsPositionDto>>(gpsPositions));
            _mockService.Setup(x => x.BusinessGetAllGpsPositionAsync()).ReturnsAsync(dataResult);

            // Act
            var result = await _controller.GetAllGpsPositionsAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<DataResult<List<ResultGpsPositionDto>>>(okResult.Value);
            Assert.True(model.Success);
        }

        [Fact]
        public async Task GetGpsPositionById_ReturnsOk_WhenServiceReturnsData()
        {
            // Arrange
            int id = 1;
            var dataResult = new SuccessDataResult<ResultGpsPositionDto>(new ResultGpsPositionDto());
            _mockService.Setup(x => x.BusinessGetGpsPositionByIdAsync(id)).ReturnsAsync(dataResult);

            // Act
            var result = await _controller.GetGpsPositionByIdAsync(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<DataResult<ResultGpsPositionDto>>(okResult.Value);
            Assert.True(model.Success);
        }

        [Fact]
        public async Task GetGpsPositionById_ReturnsBadRequest_WhenServiceReturnsError()
        {
            // Arrange
            int id = 1;
            var errorMessage = "Invalid ID";
            var errorDataResult = new ErrorDataResult<ResultGpsPositionDto>(null, errorMessage);
            _mockService.Setup(x => x.BusinessGetGpsPositionByIdAsync(id)).ReturnsAsync(errorDataResult);

            // Act
            var result = await _controller.GetGpsPositionByIdAsync(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal(errorMessage, badRequestResult.Value);
        }

        [Fact]
        public async Task CreateGpsPosition_ReturnsBadRequest_WhenServiceReturnsError()
        {
            // Arrange
            var createDto = new CreateGpsPositionDto();
            var errorMessage = "Failed to create GPS position.";
            var errorResult = new ErrorResult(errorMessage);
            var gpsPosition = new GpsPosition();
            _mockMapper.Setup(x => x.Map<GpsPosition>(createDto)).Returns(gpsPosition);
            _mockService.Setup(x => x.BusinessAddAsync(gpsPosition)).ReturnsAsync(errorResult);

            // Act
            var result = await _controller.CreateGpsPosition(createDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal(errorMessage, badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateGpsPosition_ReturnsBadRequest_WhenServiceReturnsError()
        {
            // Arrange
            var updateDto = new UpdateGpsPositionDto();
            var errorMessage = "Failed to update GPS position.";
            var errorResult = new ErrorResult(errorMessage);
            var gpsPosition = new GpsPosition();
            _mockMapper.Setup(x => x.Map<GpsPosition>(updateDto)).Returns(gpsPosition);
            _mockService.Setup(x => x.BusinessUpdateAsync(gpsPosition)).ReturnsAsync(errorResult);

            // Act
            var result = await _controller.UpdateGpsPosition(updateDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal(errorMessage, badRequestResult.Value);
        }

        [Fact]
        public async Task DeleteGpsPositionAsync_ReturnsBadRequest_WhenServiceReturnsError()
        {
            // Arrange
            int id = 1;
            var errorMessage = "Failed to delete GPS position.";
            var errorResult = new ErrorResult(errorMessage);
            _mockService.Setup(x => x.BusinessDeleteAsync(id)).ReturnsAsync(errorResult);

            // Act
            var result = await _controller.DeleteGpsPositionAsync(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal(errorMessage, badRequestResult.Value);
        }
    }
}
