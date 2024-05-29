using Asp.Versioning;
using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.EquipmentShippingDetailDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentAPI.Controllers
{
    /// <summary>
    /// Controller for managing equipment shipping details.
    /// </summary>
    [Route("api/equipmentshippingdetails")]
    [ApiController]
    [ApiVersion("1.0")]
    public class EquipmentShippingDetailsController : ControllerBase
    {
        private readonly IEquipmentShippingDetailService _equipmentShippingDetailService;
        private readonly ILogger<EquipmentShippingDetailsController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentShippingDetailsController"/> class.
        /// </summary>
        /// <param name="equipmentShippingDetailService">The equipment shipping detail service.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public EquipmentShippingDetailsController(IEquipmentShippingDetailService equipmentShippingDetailService,
                                                    ILogger<EquipmentShippingDetailsController> logger, IMapper mapper
                                                 )
        {
            _equipmentShippingDetailService = equipmentShippingDetailService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all equipment shipping details.
        /// </summary>
        /// <returns>A list of equipment shipping details.</returns>
        /// <response code="200">Returns the list of equipment shipping details.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DataResult<List<ResultEquipmentShippingDetailDto>>>> GetAllEquipmentShippingDetailsAsync()
        {
            try
            {
                var result = await _equipmentShippingDetailService.BusinessGetAllEquipmentShippingDetailsAsync();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all Equipment Shipping Details.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Retrieves equipment shipping detail by its ID.
        /// </summary>
        /// <param name="id">The ID of the equipment shipping detail to retrieve.</param>
        /// <returns>The equipment shipping detail.</returns>
        /// <response code="200">Returns the equipment shipping detail.</response>
        /// <response code="400">If the equipment shipping detail ID is invalid.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DataResult<ResultEquipmentShippingDetailDto>>> GetEquipmentShippingDetailByIdAsync(int id)
        {
            try
            {
                var result = await _equipmentShippingDetailService.BusinessGetEquipmentShippingDetailByIdAsync(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting Equipment Shipping Detail by Id {id}");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Creates a new equipment shipping detail.
        /// </summary>
        /// <param name="createEquipmentShippingDetailDto">The equipment shipping detail data to create.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the equipment shipping detail was created successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("addequipmentshippingdetail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> CreateEquipmentShippingDetail(CreateEquipmentShippingDetailDto createEquipmentShippingDetailDto)
        {
            try
            {
                var equipmentShippingDetailToAdd = _mapper.Map<EquipmentShippingDetail>(createEquipmentShippingDetailDto);
                var result = await _equipmentShippingDetailService.BusinessAddAsync(equipmentShippingDetailToAdd);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Equipment Shipping Detail.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Updates an existing equipment shipping detail.
        /// </summary>
        /// <param name="equipmentShippingDetail">The updated equipment shipping detail data.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the equipment shipping detail was updated successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> UpdateEquipmentShippingDetail(EquipmentShippingDetail equipmentShippingDetail)
        {

            try
            {
                var result = await _equipmentShippingDetailService.BusinessUpdateAsync(equipmentShippingDetail);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the Equipment Shipping Detail.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Deletes an equipment shipping detail by its ID.
        /// </summary>
        /// <param name="id">The ID of the equipment shipping detail to delete.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the equipment shipping detail was deleted successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> DeleteEquipmentShippingDetailAsync(int id)
        {
            try
            {
                var result = await _equipmentShippingDetailService.BusinessDeleteAsync(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the Equipment Shipping Detail.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
