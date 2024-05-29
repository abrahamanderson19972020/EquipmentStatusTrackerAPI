using Asp.Versioning;
using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Constants.Messages;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.AddressDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace EquipmentAPI.Controllers
{
    /// <summary>
    /// Controller for managing addresses.
    /// </summary>
    [Route("api/addresses")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly ILogger<AddressesController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressesController"/> class.
        /// </summary>
        /// <param name="addressService">The address service.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public AddressesController(IAddressService addressService, ILogger<AddressesController> logger, IMapper mapper)
        {
            _addressService = addressService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all addresses.
        /// </summary>
        /// <returns>A list of addresses and their details.</returns>
        /// <response code="200">Returns the list of addresses.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DataResult<List<Address>>>> GetAllAdressesAsync()
        {
            try
            {
                var result = await _addressService.BusinessGetAllAsync();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all addresses.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Retrieves an address by its ID.
        /// </summary>
        /// <param name="addressId">The ID of the address to retrieve.</param>
        /// <returns>The address details.</returns>
        /// <response code="200">Returns the address details.</response>
        /// <response code="400">If the address ID is invalid.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DataResult<Address>>> GetAdressByIdAsync(int addressId)
        {
            try
            {
                var result = await _addressService.BusinessGetByIdAsync(addressId);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting address by Id {addressId}");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Creates a new address.
        /// </summary>
        /// <param name="createAddressDto">The address details to create.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the address was created successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("addaddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> CreateAddress(CreateAddressDto createAddressDto)
        {
            try
            {
                var addressToAdd = _mapper.Map<Address>(createAddressDto);
                var result = await _addressService.BusinessAddAsync(addressToAdd);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the address.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Updates an existing address.
        /// </summary>
        /// <param name="address">The updated address details.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the address was updated successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPut("update")]
        public async Task<ActionResult<Result>> UpdateAddress(Address address)
        {

            try
            {
                var result = await _addressService.BusinessUpdateAsync(address);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the address.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
        /// <summary>
        /// Deletes an address by its ID.
        /// </summary>
        /// <param name="id">The ID of the address to delete.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the address was deleted successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpDelete("delete")]
        public async Task<ActionResult<Result>> DeleteAddressAsync(int  id)
        {
            try
            {
                var result = await _addressService.BusinessDeleteAsync(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the address.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
