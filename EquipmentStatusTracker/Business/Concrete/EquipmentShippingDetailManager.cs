using Business.Abstract;
using Business.Constants.Messages;
using Business.ResponseModels.Abstract;
using Business.ResponseModels.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.EquipmentShippingDetailDTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EquipmentShippingDetailManager : IEquipmentShippingDetailService
    {
        private readonly IEquipmentShippingDetailDal _equipmentShippingDetailDal;
        private readonly ILogger<EquipmentShippingDetailManager> _logger;
        public EquipmentShippingDetailManager(IEquipmentShippingDetailDal equipmentShippingDetail, 
                                              ILogger<EquipmentShippingDetailManager> logger)
        {
            _equipmentShippingDetailDal = equipmentShippingDetail;
            _logger = logger;
        }
        public async Task<IResult> BusinessAddAsync(EquipmentShippingDetail entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ErrorResult(ErrorMessages<EquipmentShippingDetail>.NoValidItem);
                }

                var result = await _equipmentShippingDetailDal.AddAsync(entity);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<EquipmentShippingDetail>.ItemAdded);
                }

                return new ErrorResult(ErrorMessages<EquipmentShippingDetail>.NoItemFound);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding EquipmentShippingDetail.");
                return new ErrorResult(ErrorMessages<EquipmentShippingDetail>.UnexpectedError);
            }
        }

        public async Task<IResult> BusinessDeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return new ErrorResult(ErrorMessages<EquipmentShippingDetail>.NoValidItem);
                }

                var result = await _equipmentShippingDetailDal.DeleteAsync(id);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<EquipmentShippingDetail>.ItemDeleted);
                }

                return new ErrorResult(ErrorMessages<EquipmentShippingDetail>.NoItemFound);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting EquipmentShippingDetail.");
                return new ErrorResult(ErrorMessages<EquipmentShippingDetail>.UnexpectedError);
            }
        }

        public async Task<IResult> BusinessUpdateAsync(EquipmentShippingDetail entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ErrorResult(ErrorMessages<EquipmentShippingDetail>.NoValidItem);
                }
                var equipmentShippingDetail = _equipmentShippingDetailDal.GetByIdAsync(entity.Id);
                if (equipmentShippingDetail == null)
                {
                    return new ErrorResult(ErrorMessages<EquipmentShippingDetail>.NoItemFound);
                }
                var result = await _equipmentShippingDetailDal.UpdateAsync(entity);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<EquipmentShippingDetail>.ItemUpdated);
                }

                return new ErrorResult(ErrorMessages<EquipmentShippingDetail>.NoUpdatedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating an EquipmentShippingDetail.");
                return new ErrorResult(ErrorMessages<EquipmentShippingDetail>.UnexpectedError);
            }
        }

        public async Task<IDataResult<List<EquipmentShippingDetail>>> BusinessGetAllAsync()
        {
            try
            {
                var items = await _equipmentShippingDetailDal.GetAllAsync();

                if (items == null)
                {
                    return new ErrorDataResult<List<EquipmentShippingDetail>>(items, ErrorMessages<EquipmentShippingDetail>.NoItemFound);
                }

                return new SuccessDataResult<List<EquipmentShippingDetail>>(items, SuccessMessages<EquipmentShippingDetail>.ItemAllListed);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all EquipmentShippingDetails.");
                return new ErrorDataResult<List<EquipmentShippingDetail>>(null, ErrorMessages<EquipmentShippingDetail>.UnexpectedError);
            }
        }

        public async Task<IDataResult<EquipmentShippingDetail>> BusinessGetByIdAsync(int id)
        {
            try
            {
                var item = await _equipmentShippingDetailDal.GetByIdAsync(id);

                if (item == null)
                {
                    return new ErrorDataResult<EquipmentShippingDetail>(item, ErrorMessages<EquipmentShippingDetail>.NoItemFound);
                }

                return new SuccessDataResult<EquipmentShippingDetail>(item, SuccessMessages<EquipmentShippingDetail>.ItemById);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving EquipmentShippingDetail by ID: {Id}.", id);
                return new ErrorDataResult<EquipmentShippingDetail>(null, ErrorMessages<EquipmentShippingDetail>.UnexpectedError);
            }
        }

        public async Task<IDataResult<List<ResultEquipmentShippingDetailDto>>> BusinessGetAllEquipmentShippingDetailsAsync()
        {
            try
            {
                var items = await _equipmentShippingDetailDal.GetAllEquipmentShippingDetailsAsync();

                if (items == null)
                {
                    return new ErrorDataResult<List<ResultEquipmentShippingDetailDto>>(items, ErrorMessages<ResultEquipmentShippingDetailDto>.NoItemFound);
                }

                return new SuccessDataResult<List<ResultEquipmentShippingDetailDto>>(items, SuccessMessages<ResultEquipmentShippingDetailDto>.ItemAllListed);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all Equipment Shipping Details.");
                return new ErrorDataResult<List<ResultEquipmentShippingDetailDto>>(null, ErrorMessages<ResultEquipmentShippingDetailDto>.UnexpectedError);
            }
        }

        public async Task<IDataResult<ResultEquipmentShippingDetailDto>> BusinessGetEquipmentShippingDetailByIdAsync(int id)
        {

            try
            {
                var item = await _equipmentShippingDetailDal.GetEquipmentShippingDetailByIdAsync(id);

                if (item == null)
                {
                    return new ErrorDataResult<ResultEquipmentShippingDetailDto>(item, ErrorMessages<ResultEquipmentShippingDetailDto>.NoItemFound);
                }

                return new SuccessDataResult<ResultEquipmentShippingDetailDto>(item, SuccessMessages<ResultEquipmentShippingDetailDto>.ItemById);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving EquipmentShippingDetail by ID: {Id}.", id);
                return new ErrorDataResult<ResultEquipmentShippingDetailDto>(null, ErrorMessages<ResultEquipmentShippingDetailDto>.UnexpectedError);
            }
        }
    }
}
