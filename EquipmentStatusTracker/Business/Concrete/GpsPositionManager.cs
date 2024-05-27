using AutoMapper;
using Business.Abstract;
using Business.Constants.Messages;
using Business.ResponseModels.Abstract;
using Business.ResponseModels.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.GpsPositionDTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GpsPositionManager : IGpsPositionService
    {
        private readonly IGpsPositionDal _gpsPositionDal;
        private readonly ILogger<GpsPositionManager> _logger;
        private readonly IMapper _mapper;
        public GpsPositionManager(IGpsPositionDal gpsPositionDal, ILogger<GpsPositionManager> logger, IMapper mapper)
        {
            _gpsPositionDal = gpsPositionDal;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IResult> BusinessAddAsync(GpsPosition entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ErrorResult(ErrorMessages<GpsPosition>.NoValidItem);
                }

                var result = await _gpsPositionDal.AddAsync(entity);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<GpsPosition>.ItemAdded);
                }

                return new ErrorResult(ErrorMessages<GpsPosition>.NoAddedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding GpsPosition.");
                return new ErrorResult(ErrorMessages<GpsPosition>.UnexpectedError);
            }
        }

        public async Task<IResult> BusinessDeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return new ErrorResult(ErrorMessages<GpsPosition>.NoValidItem);
                }

                var result = await _gpsPositionDal.DeleteAsync(id);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<GpsPosition>.ItemDeleted);
                }

                return new ErrorResult(ErrorMessages<GpsPosition>.NoItemFound);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting GpsPosition.");
                return new ErrorResult(ErrorMessages<GpsPosition>.UnexpectedError);
            }
        }

        public async Task<IResult> BusinessUpdateAsync(GpsPosition entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ErrorResult(ErrorMessages<GpsPosition>.NoValidItem);
                }
                var gpsPosition = _gpsPositionDal.GetByIdAsync(entity.Id);
                if (gpsPosition == null)
                {
                    return new ErrorResult(ErrorMessages<GpsPosition>.NoItemFound);
                }
                var result = await _gpsPositionDal.UpdateAsync(entity);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<GpsPosition>.ItemUpdated);
                }

                return new ErrorResult(ErrorMessages<GpsPosition>.NoUpdatedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating an GpsPosition.");
                return new ErrorResult(ErrorMessages<GpsPosition>.UnexpectedError);
            }
        }

        public async Task<IDataResult<List<GpsPosition>>> BusinessGetAllAsync()
        {
            try
            {
                var items = await _gpsPositionDal.GetAllAsync();

                if (items == null)
                {
                    return new ErrorDataResult<List<GpsPosition>>(items, ErrorMessages<GpsPosition>.NoItemFound);
                }

                return new SuccessDataResult<List<GpsPosition>>(items, SuccessMessages<GpsPosition>.ItemAllListed);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all GpsPositions.");
                return new ErrorDataResult<List<GpsPosition>>(null, ErrorMessages<GpsPosition>.UnexpectedError);
            }
        }

        public async Task<IDataResult<GpsPosition>> BusinessGetByIdAsync(int id)
        {
            try
            {
                var item = await _gpsPositionDal.GetByIdAsync(id);

                if (item == null)
                {
                    return new ErrorDataResult<GpsPosition>(item, ErrorMessages<GpsPosition>.NoItemFound);
                }

                return new SuccessDataResult<GpsPosition>(item, SuccessMessages<GpsPosition>.ItemById);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving GpsPosition by ID: {Id}.", id);
                return new ErrorDataResult<GpsPosition>(null, ErrorMessages<GpsPosition>.UnexpectedError);
            }
        }

        public async Task<IDataResult<List<ResultGpsPositionDto>>> BusinessGetAllGpsPositionAsync()
        {
            try
            {
                var items = await _gpsPositionDal.GetAllAsync();
                var result = _mapper.Map<List<ResultGpsPositionDto>>(items);    

                if (result == null)
                {
                    return new ErrorDataResult<List<ResultGpsPositionDto>>(result, ErrorMessages<ResultGpsPositionDto>.NoItemFound);
                }

                return new SuccessDataResult<List<ResultGpsPositionDto>>(result, SuccessMessages<ResultGpsPositionDto>.ItemAllListed);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all GpsPositions.");
                return new ErrorDataResult<List<ResultGpsPositionDto>>(null, ErrorMessages<ResultGpsPositionDto>.UnexpectedError);
            }
        }

        public async Task<IDataResult<ResultGpsPositionDto>> BusinessGetGpsPositionByIdAsync(int id)
        {
            try
            {
                var item = await _gpsPositionDal.GetByIdAsync(id);
                var result = _mapper.Map<ResultGpsPositionDto>(item);
                if (result == null)
                {
                    return new ErrorDataResult<ResultGpsPositionDto>(result, ErrorMessages<ResultGpsPositionDto>.NoItemFound);
                }

                return new SuccessDataResult<ResultGpsPositionDto>(result, SuccessMessages<GpsPosition>.ItemById);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving GpsPosition by ID: {Id}.", id);
                return new ErrorDataResult<ResultGpsPositionDto>(null, ErrorMessages<ResultGpsPositionDto>.UnexpectedError);
            }
        }
    }
}
