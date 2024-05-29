using Asp.Versioning;
using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.CustomerDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentAPI.Controllers
{
    /// <summary>
    /// Controller for managing customers.
    /// </summary>
    [Route("api/customers")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomersController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersController"/> class.
        /// </summary>
        /// <param name="customerService">The customer service.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public CustomersController(ICustomerService customerService, ILogger<CustomersController> logger, IMapper mapper)
        {
            _customerService = customerService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all customers along with their communication details.
        /// </summary>
        /// <returns>A list of customers and their communication details.</returns>
        /// <response code="200">Returns the list of customers.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DataResult<List<Customer>>>> GetAllCustomersAsync()
        {
            try
            {
                var result = await _customerService.BusinessGetAllWithCommunicationAsync();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all Customers.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Retrieves a customer by its ID along with their communication details.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>The customer details.</returns>
        /// <response code="200">Returns the customer details.</response>
        /// <response code="400">If the customer ID is invalid.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DataResult<Customer>>> GetCustomerByIdAsync(int id)
        {
            try
            {
                var result = await _customerService.BusinessGetCustomerWithCustomerByIdAsync(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting Customer by Id {id}");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="createCustomerDto">The customer data to create.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the customer was created successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("addcustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            try
            {
                var customerToAdd = _mapper.Map<Customer>(createCustomerDto);
                var result = await _customerService.BusinessAddAsync(customerToAdd);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Customer.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="updateCustomerDto">The updated customer data.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the customer was updated successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
        {

            try
            {
                var result = await _customerService.BusinessUpdateWithDtoAsync(updateCustomerDto);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the Customer.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Deletes a customer by its ID.
        /// </summary>
        /// <param name="id">The ID of the customer to delete.</param>
        /// <returns>A result indicating success or failure.</returns>
        /// <response code="200">If the customer was deleted successfully.</response>
        /// <response code="400">If there is an error in the request.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result>> DeleteCustomerAsync(int id)
        {
            try
            {
                var result = await _customerService.BusinessDeleteAsync(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the Customer.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
