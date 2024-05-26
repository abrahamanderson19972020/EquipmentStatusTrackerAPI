using Business.Abstract;
using Business.Concrete;
using Business.ResponseModels.Concrete;
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
        public AddressesController(IAddressService addressService, ILogger<AddressesController> logger)
        {
            _addressService = addressService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<DataResult<List<ResultAddressDto>>>> GetAllAdresses()
        {

        }
    }
}
