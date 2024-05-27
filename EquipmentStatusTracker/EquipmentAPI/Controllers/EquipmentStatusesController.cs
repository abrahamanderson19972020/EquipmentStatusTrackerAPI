using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.EquipmentStatusDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentAPI.Controllers
{
    [Route("api/equipmentstatuses")]
    [ApiController]
    public class EquipmentStatusesController : ControllerBase
    {
        private readonly IEquipmentStatusService _equipmentStatusService;
        private readonly ILogger<EquipmentStatusesController> _logger;
        private readonly IMapper _mapper;
        public EquipmentStatusesController(IEquipmentStatusService equipmentStatusService, 
                                           ILogger<EquipmentStatusesController> logger, IMapper mapper
                                           )
        {
            _equipmentStatusService = equipmentStatusService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
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

        [HttpGet("{id}")]
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

        [HttpPost("addequipmentstatus")]
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

        [HttpPut("update")]
        public async Task<ActionResult<Result>> UpdateEquipmentStatusAsync(EquipmentStatus equipmentStatus)
        {

            try
            {
                var result = await _equipmentStatusService.BusinessUpdateAsync(equipmentStatus);
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

        [HttpDelete("delete")]
        public async Task<ActionResult<Result>> DeleteEquipmentStatusAsync(EquipmentStatus equipmentStatus)
        {
            try
            {
                var result = await _equipmentStatusService.BusinessDeleteAsync(equipmentStatus);
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
