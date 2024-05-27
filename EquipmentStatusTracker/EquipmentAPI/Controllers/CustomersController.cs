using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.CustomerDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentAPI.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomersController> _logger;
        private readonly IMapper _mapper;
        public CustomersController(ICustomerService customerService, ILogger<CustomersController> logger, IMapper mapper)
        {
            _customerService = customerService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
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

        [HttpGet("{id}")]
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

        [HttpPost("addcustomer")]
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

        [HttpPut("update")]
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

        [HttpDelete("delete")]
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
