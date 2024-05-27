using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.EquipmentShippingDetailDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentAPI.Controllers
{
    [Route("api/equipmentshippingdetails")]
    [ApiController]
    public class EquipmentShippingDetailsController : ControllerBase
    {
        private readonly IEquipmentShippingDetailService _equipmentShippingDetailService;
        private readonly ILogger<EquipmentShippingDetailsController> _logger;
        private readonly IMapper _mapper;
        public EquipmentShippingDetailsController(IEquipmentShippingDetailService equipmentShippingDetailService,
                                                    ILogger<EquipmentShippingDetailsController> logger, IMapper mapper
                                                 )
        {
            _equipmentShippingDetailService = equipmentShippingDetailService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
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

        [HttpGet("{id}")]
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

        [HttpPost("addequipmentshippingdetail")]
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

        [HttpPut("update")]
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

        [HttpDelete("delete")]
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
