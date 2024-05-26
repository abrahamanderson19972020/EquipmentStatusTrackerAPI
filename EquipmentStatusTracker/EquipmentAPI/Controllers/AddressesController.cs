using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Constants.Messages;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.AddressDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentAPI.Controllers
{
    [Route("api/addresses")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly ILogger<AddressesController> _logger;
        private readonly IMapper _mapper;
        public AddressesController(IAddressService addressService, ILogger<AddressesController> logger, IMapper mapper)
        {
            _addressService = addressService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
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

        [HttpGet("{addressId}")]
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

        [HttpPost("addaddress")]
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

        [HttpDelete("delete")]
        public async Task<ActionResult<Result>> DeleteAddressAsync(Address address)
        {
            try
            {
                var result = await _addressService.BusinessDeleteAsync(address);
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
