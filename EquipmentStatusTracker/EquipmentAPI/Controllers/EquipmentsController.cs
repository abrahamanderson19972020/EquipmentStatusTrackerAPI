using Asp.Versioning;
using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.EquipmentDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentAPI.Controllers
{
    /// <summary>
    /// Controller for managing equipments.
    /// </summary>
    [Route("api/equipments")]
    [ApiController]
    [ApiVersion("1.0")]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly ILogger<EquipmentsController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentsController"/> class.
        /// </summary>
        /// <param name="equipmentService">The equipment service.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public EquipmentsController(IEquipmentService equipmentService, ILogger<EquipmentsController> logger, IMapper mapper)
        {
            _equipmentService = equipmentService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all equipments.
        /// </summary>
        /// <returns>A list of equipment.</returns>
        /// <response code="200">Returns the list of equipment.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DataResult<List<Equipment>>>> GetAllAdressesAsync()
        {
            try
            {
                var result = await _equipmentService.BusinessGetAllAsync();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all Equipments.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Retrieves equipment by its ID.
        /// </summary>
        /// <param name="id">The ID of the equipment to retrieve.</param>
        /// <returns>The equipment details.</returns>
        /// <response code="200">Returns the equipment details.</response>
        /// <response code="400">If the equipment ID is invalid.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DataResult<Equipment>>> GetEquipmentByIdAsync(int id)
        {
            try
            {
                var result = await _equipmentService.BusinessGetByIdAsync(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting Equipment by Id {id}");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Creates a new equipment.
        /// </summary>
        /// <param name="createEquipmentDto">The equipment data to create.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the equipment was created successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("addequipment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> CreateEquipment(CreateEquipmentDto createEquipmentDto)
        {
            try
            {
                var equipmentToAdd = _mapper.Map<Equipment>(createEquipmentDto);
                var result = await _equipmentService.BusinessAddAsync(equipmentToAdd);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Equipment.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Updates an existing equipment.
        /// </summary>
        /// <param name="equipment">The updated equipment data.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the equipment was updated successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> UpdateEquipment(Equipment equipment)
        {

            try
            {
                var result = await _equipmentService.BusinessUpdateAsync(equipment);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the Equipment.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Deletes an equipment by its ID.
        /// </summary>
        /// <param name="id">The ID of the equipment to delete.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the equipment was deleted successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> DeleteEquipmentAsync(int id)
        {
            try
            {
                var result = await _equipmentService.BusinessDeleteAsync(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the Equipment.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
