using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.EquipmentDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentAPI.Controllers
{
    [Route("api/equipments")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly ILogger<EquipmentsController> _logger;
        private readonly IMapper _mapper;
        public EquipmentsController(IEquipmentService equipmentService, ILogger<EquipmentsController> logger, IMapper mapper)
        {
            _equipmentService = equipmentService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
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

        [HttpGet("{id}")]
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

        [HttpPost("addequipment")]
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

        [HttpPut("update")]
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

        [HttpDelete("delete")]
        public async Task<ActionResult<Result>> DeleteEquipmentAsync(Equipment equipment)
        {
            try
            {
                var result = await _equipmentService.BusinessDeleteAsync(equipment);
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
