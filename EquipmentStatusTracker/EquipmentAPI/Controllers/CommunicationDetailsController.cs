using AutoMapper;
using Business.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.CommunicationDetailDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentAPI.Controllers
{
    [Route("api/communicationdetails")]
    [ApiController]
    public class CommunicationDetailsController : ControllerBase
    {
        private readonly ICommunicationDetailService _communicationDetailService;
        private readonly ILogger<CommunicationDetailsController> _logger;
        private readonly IMapper _mapper;
        public CommunicationDetailsController(ICommunicationDetailService communicationDetailService, ILogger<CommunicationDetailsController> logger, IMapper mapper)
        {
            _communicationDetailService = communicationDetailService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
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

        [HttpGet("{id}")]
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

        [HttpPost("addcommunicationdetail")]
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

        [HttpPut("update")]
        public async Task<ActionResult<Result>> UpdateCommunicationDetailAsync(CommunicationDetail communicationDetail)
        {

            try
            {
                var result = await _communicationDetailService.BusinessUpdateAsync(communicationDetail);
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

        [HttpDelete("delete")]
        public async Task<ActionResult<Result>> DeleteCommunicationDetailAsync(CommunicationDetail communicationDetail)
        {
            try
            {
                var result = await _communicationDetailService.BusinessDeleteAsync(communicationDetail);
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
