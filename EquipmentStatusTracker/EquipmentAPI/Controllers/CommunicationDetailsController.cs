using Asp.Versioning;
using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.CommunicationDetailDTOs;
using Entities.DTOs.CustomerDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentAPI.Controllers
{
    /// <summary>
    /// Controller for managing communication details.
    /// </summary>
    [Route("api/communicationdetails")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CommunicationDetailsController : ControllerBase
    {
        private readonly ICommunicationDetailService _communicationDetailService;
        private readonly ILogger<CommunicationDetailsController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationDetailsController"/> class.
        /// </summary>
        /// <param name="communicationDetailService">The communication detail service.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public CommunicationDetailsController(ICommunicationDetailService communicationDetailService, ILogger<CommunicationDetailsController> logger, IMapper mapper)
        {
            _communicationDetailService = communicationDetailService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all communication details.
        /// </summary>
        /// <returns>A list of communication details and their associated addresses.</returns>
        /// <response code="200">Returns the list of communication details.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DataResult<List<CommunicationDetail>>>> GetAllCommunicationDetailsAsync()
        {
            try
            {
                var result = await _communicationDetailService.BusinessGetAllWithAdressesAsync();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all CommunicationDetails.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Retrieves a communication detail by its ID.
        /// </summary>
        /// <param name="id">The ID of the communication detail to retrieve.</param>
        /// <returns>The communication detail and its associated address.</returns>
        /// <response code="200">Returns the communication detail.</response>
        /// <response code="400">If the communication detail ID is invalid.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DataResult<CommunicationDetail>>> GetCommunicationDetailByIdAsync(int id)
        {
            try
            {
                var result = await _communicationDetailService.BusinessGetCommunicationDetailWithAddressByIdAsync(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting Communication Detail by Id {id}");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Creates a new communication detail.
        /// </summary>
        /// <param name="createCommunicationDetailDto">The communication detail data to create.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the communication detail was created successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("addcommunicationdetail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> CreateCommunicationDetailAsync(CreateCommunicationDetailDto createCommunicationDetailDto)
        {
            try
            {
                var communicationDetailToAdd = _mapper.Map<CommunicationDetail>(createCommunicationDetailDto);
                var result = await _communicationDetailService.BusinessAddAsync(communicationDetailToAdd);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Communication Detail.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Updates an existing communication detail.
        /// </summary>
        /// <param name="updateCommunicationDetailDto">The updated communication detail data.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the communication detail was updated successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> UpdateCommunicationDetailAsync(UpdateCommunicationDetailDto udateCommunicationDetail)
        {

            try
            {
                var communicationDetailToUpdate = _mapper.Map<CommunicationDetail>(udateCommunicationDetail);
                var result = await _communicationDetailService.BusinessUpdateAsync(communicationDetailToUpdate);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the Communication Detail.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }


        /// <summary>
        /// Deletes a communication detail by its ID.
        /// </summary>
        /// <param name="id">The ID of the communication detail to delete.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the communication detail was deleted successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> DeleteCommunicationDetailAsync(int id)
        {
            try
            {
                var result = await _communicationDetailService.BusinessDeleteAsync(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the Communication Detail.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
