using Business.Abstract;
using Business.Constants.Messages;
using Business.ResponseModels.Abstract;
using Business.ResponseModels.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EquipmentStatusManager : IEquipmentStatusService
    {
        private readonly IEquipmentStatusDal _equipmentStatusManagerDal;
        private readonly ILogger<EquipmentStatusManager> _logger;
        public EquipmentStatusManager(IEquipmentStatusDal equipmentStatusManagerDal,ILogger<EquipmentStatusManager> logger)
        {
            _equipmentStatusManagerDal = equipmentStatusManagerDal;
            _logger = logger;
        }
        public async Task<IResult> BusinessAddAsync(EquipmentStatus entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ErrorResult(ErrorMessages<EquipmentStatus>.NoValidItem);
                }

                var result = await _equipmentStatusManagerDal.AddAsync(entity);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<EquipmentStatus>.ItemAdded);
                }

                return new ErrorResult(ErrorMessages<EquipmentStatus>.NoAddedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding EquipmentStatus.");
                return new ErrorResult(ErrorMessages<EquipmentStatus>.UnexpectedError);
            }
        }

        public async Task<IResult> BusinessDeleteAsync(EquipmentStatus entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ErrorResult(ErrorMessages<EquipmentStatus>.NoValidItem);
                }

                var result = await _equipmentStatusManagerDal.DeleteAsync(entity);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<EquipmentStatus>.ItemDeleted);
                }

                return new ErrorResult(ErrorMessages<EquipmentStatus>.NoDeletedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting EquipmentStatus.");
                return new ErrorResult(ErrorMessages<EquipmentStatus>.UnexpectedError);
            }
        }


        public async Task<IResult> BusinessUpdateAsync(EquipmentStatus entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ErrorResult(ErrorMessages<EquipmentStatus>.NoValidItem);
                }

                var result = await _equipmentStatusManagerDal.UpdateAsync(entity);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<EquipmentStatus>.ItemUpdated);
                }

                return new ErrorResult(ErrorMessages<EquipmentStatus>.NoUpdatedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating EquipmentStatus.");
                return new ErrorResult(ErrorMessages<EquipmentStatus>.UnexpectedError);
            }
        }

        public async Task<IDataResult<List<EquipmentStatus>>> BusinessGetAllAsync()
        {
            try
            {
                var items = await _equipmentStatusManagerDal.GetAllAsync();

                if (items == null)
                {
                    return new ErrorDataResult<List<EquipmentStatus>>(items, ErrorMessages<EquipmentStatus>.NoItemFound);
                }

                return new SuccessDataResult<List<EquipmentStatus>>(items, SuccessMessages<EquipmentStatus>.ItemAllListed);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all EquipmentStatuses.");
                return new ErrorDataResult<List<EquipmentStatus>>(null, ErrorMessages<EquipmentStatus>.UnexpectedError);
            }
        }

        public async Task<IDataResult<EquipmentStatus>> BusinessGetByIdAsync(int id)
        {
            try
            {
                var item = await _equipmentStatusManagerDal.GetByIdAsync(id);

                if (item == null)
                {
                    return new ErrorDataResult<EquipmentStatus>(item, ErrorMessages<EquipmentStatus>.NoItemFound);
                }

                return new SuccessDataResult<EquipmentStatus>(item, SuccessMessages<EquipmentStatus>.ItemById);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving EquipmentStatus by ID: {Id}.", id);
                return new ErrorDataResult<EquipmentStatus>(null, ErrorMessages<EquipmentStatus>.UnexpectedError);
            }
        }
    }
}
