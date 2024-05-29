using Asp.Versioning;
using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.EquipmentStatusDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentAPI.Controllers
{
    /// <summary>
    /// Controller for managing equipment statuses.
    /// </summary>
    [Route("api/equipmentstatuses")]
    [ApiController]
    [ApiVersion("1.0")]
    public class EquipmentStatusesController : ControllerBase
    {
        private readonly IEquipmentStatusService _equipmentStatusService;
        private readonly ILogger<EquipmentStatusesController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentStatusesController"/> class.
        /// </summary>
        /// <param name="equipmentStatusService">The equipment status service.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public EquipmentStatusesController(IEquipmentStatusService equipmentStatusService, 
                                           ILogger<EquipmentStatusesController> logger, IMapper mapper
                                           )
        {
            _equipmentStatusService = equipmentStatusService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all equipment statuses.
        /// </summary>
        /// <returns>A list of equipment statuses.</returns>
        /// <response code="200">Returns the list of equipment statuses.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DataResult<List<ResultEquipmentStatusDto>>>> GetAllEquipmentStatusesAsync()
        {
            try
            {
                var result = await _equipmentStatusService.GetAllEquipmentStatusesAsync();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all EquipmentStatuses.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Retrieves equipment status by its ID.
        /// </summary>
        /// <param name="id">The ID of the equipment status to retrieve.</param>
        /// <returns>The equipment status.</returns>
        /// <response code="200">Returns the equipment status.</response>
        /// <response code="400">If the equipment status ID is invalid.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DataResult<ResultEquipmentStatusDto>>> GetEquipmentStatusByIdAsync(int id)
        {
            try
            {
                var result = await _equipmentStatusService.GetEquipmentStatusByIdAsync(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting EquipmentStatus by Id {id}");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Creates a new equipment status.
        /// </summary>
        /// <param name="createEquipmentStatusDto">The equipment status data to create.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the equipment status was created successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("addequipmentstatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> CreateEquipmentStatusAsync(CreateEquipmentStatusDto createEquipmentStatusDto)
        {
            try
            {
                var equipmentStatusToAdd = _mapper.Map<EquipmentStatus>(createEquipmentStatusDto);
                var result = await _equipmentStatusService.BusinessAddAsync(equipmentStatusToAdd);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Equipment Status.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Updates an existing equipment status.
        /// </summary>
        /// <param name="updateEquipmentStatusDto">The updated equipment status data.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the equipment status was updated successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> UpdateEquipmentStatusAsync(UpdateEquipmentStatusDto updateEquipmentStatusDto)
        {

            try
            { 
                var equipmentToUpdate = _mapper.Map<EquipmentStatus>(updateEquipmentStatusDto);
                var result = await _equipmentStatusService.BusinessUpdateAsync(equipmentToUpdate);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the Equipment Status.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Deletes an equipment status by its ID.
        /// </summary>
        /// <param name="id">The ID of the equipment status to delete.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the equipment status was deleted successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> DeleteEquipmentStatusAsync(int id)
        {
            try
            {
                var result = await _equipmentStatusService.BusinessDeleteAsync(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the Equipment Status.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
