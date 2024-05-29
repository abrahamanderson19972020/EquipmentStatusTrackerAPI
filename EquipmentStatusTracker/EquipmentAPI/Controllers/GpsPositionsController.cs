using Asp.Versioning;
using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.GpsPositionDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentAPI.Controllers
{
    /// <summary>
    /// Controller for managing GPS positions.
    /// </summary>
    [Route("api/gpspositions")]
    [ApiController]
    [ApiVersion("1.0")]
    public class GpsPositionsController : ControllerBase
    {
        private readonly IGpsPositionService _gpsPositionService;
        private readonly ILogger<GpsPositionsController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GpsPositionsController"/> class.
        /// </summary>
        /// <param name="gpsPositionService">The GPS position service.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public GpsPositionsController(IGpsPositionService gpsPositionService, ILogger<GpsPositionsController> logger, IMapper mapper)
        {
            _gpsPositionService = gpsPositionService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all GPS positions.
        /// </summary>
        /// <returns>A list of GPS positions.</returns>
        /// <response code="200">Returns the list of GPS positions.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Retrieves a GPS position by its ID.
        /// </summary>
        /// <param name="id">The ID of the GPS position to retrieve.</param>
        /// <returns>The GPS position.</returns>
        /// <response code="200">Returns the GPS position.</response>
        /// <response code="400">If the GPS position ID is invalid.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Creates a new GPS position.
        /// </summary>
        /// <param name="createGpsPositionDto">The GPS position data to create.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the GPS position was created successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("addgpsposition")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Updates an existing GPS position.
        /// </summary>
        /// <param name="updateGpsPositionDto">The updated GPS position data.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the GPS position was updated successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> UpdateGpsPosition(UpdateGpsPositionDto updateGpsPositionDto)
        {

            try
            {
                var gpsPositionToUpdate = _mapper.Map<GpsPosition>(updateGpsPositionDto);
                var result = await _gpsPositionService.BusinessUpdateAsync(gpsPositionToUpdate);
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

        /// <summary>
        /// Deletes a GPS position by its ID.
        /// </summary>
        /// <param name="id">The ID of the GPS position to delete.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the GPS position was deleted successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> DeleteGpsPositionAsync(int id)
        {
            try
            {
                var result = await _gpsPositionService.BusinessDeleteAsync(id);
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
