using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.GpsPositionDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentAPI.Controllers
{
    [Route("api/gpspositions")]
    [ApiController]
    public class GpsPositionsController : ControllerBase
    {
        private readonly IGpsPositionService _gpsPositionService;
        private readonly ILogger<GpsPositionsController> _logger;
        private readonly IMapper _mapper;
        public GpsPositionsController(IGpsPositionService gpsPositionService, ILogger<GpsPositionsController> logger, IMapper mapper)
        {
            _gpsPositionService = gpsPositionService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<DataResult<List<ResultGpsPositionDto>>>> GetAllGpsPositionsAsync()
        {
            try
            {
                var result = await _gpsPositionService.BusinessGetAllGpsPositionAsync();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all Gps Positions.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DataResult<ResultGpsPositionDto>>> GetGpsPositionByIdAsync(int id)
        {
            try
            {
                var result = await _gpsPositionService.BusinessGetGpsPositionByIdAsync(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting Gps Position by Id {id}");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpPost("addgpsposition")]
        public async Task<ActionResult<Result>> CreateGpsPosition(CreateGpsPositionDto createGpsPositionDto)
        {
            try
            {
                var gpsPositionToAdd = _mapper.Map<GpsPosition>(createGpsPositionDto);
                var result = await _gpsPositionService.BusinessAddAsync(gpsPositionToAdd);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Gps Position.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<Result>> UpdateGpsPosition(GpsPosition gpsPosition)
        {

            try
            {
                var result = await _gpsPositionService.BusinessUpdateAsync(gpsPosition);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the GpsPosition.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Result>> DeleteGpsPositionAsync(GpsPosition gpsPosition)
        {
            try
            {
                var result = await _gpsPositionService.BusinessDeleteAsync(gpsPosition);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the GpsPosition.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
