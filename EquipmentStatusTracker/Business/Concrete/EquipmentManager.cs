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
    public class EquipmentManager : IEquipmentService
    {
        private readonly IEquipmentDal _equipmentDal;
        private readonly ILogger<EquipmentManager> _logger;
        public EquipmentManager(IEquipmentDal equipmentDal, ILogger<EquipmentManager> logger)
        {
            _equipmentDal = equipmentDal;
            _logger = logger;
        }
        public async Task<IResult> BusinessAddAsync(Equipment entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ErrorResult(ErrorMessages<Equipment>.NoValidItem);
                }

                var result = await _equipmentDal.AddAsync(entity);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<Equipment>.ItemAdded);
                }

                return new ErrorResult(ErrorMessages<Equipment>.NoAddedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding Equipment.");
                return new ErrorResult(ErrorMessages<Equipment>.UnexpectedError);
            }
        }

        public async Task<IResult> BusinessDeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return new ErrorResult(ErrorMessages<Equipment>.NoValidItem);
                }

                var result = await _equipmentDal.DeleteAsync(id);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<Equipment>.ItemDeleted);
                }

                return new ErrorResult(ErrorMessages<Equipment>.NoItemFound);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting Equipment.");
                return new ErrorResult(ErrorMessages<Equipment>.UnexpectedError);
            }
        }
        public async Task<IResult> BusinessUpdateAsync(Equipment entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ErrorResult(ErrorMessages<Equipment>.NoValidItem);
                }
                var equipment = await _equipmentDal.GetByIdAsync(entity.Id);
                if (equipment == null)
                {
                    return new ErrorResult(ErrorMessages<Equipment>.NoItemFound);
                }
                var result = await _equipmentDal.UpdateAsync(entity);
                if (result)
                {
                    return new SuccessResult(SuccessMessages<Equipment>.ItemUpdated);
                }

                return new ErrorResult(ErrorMessages<Equipment>.NoUpdatedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating Equipment.");
                return new ErrorResult(ErrorMessages<Equipment>.UnexpectedError);
            }
        }

        public async Task<IDataResult<List<Equipment>>> BusinessGetAllAsync()
        {
            try
            {
                var items = await _equipmentDal.GetAllAsync();

                if (items == null)
                {
                    return new ErrorDataResult<List<Equipment>>(items, ErrorMessages<Equipment>.NoItemFound);
                }

                return new SuccessDataResult<List<Equipment>>(items, SuccessMessages<Equipment>.ItemAllListed);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all Equipments.");
                return new ErrorDataResult<List<Equipment>>(null, ErrorMessages<Equipment>.UnexpectedError);
            }
        }

        public async Task<IDataResult<Equipment>> BusinessGetByIdAsync(int id)
        {
            try
            {
                var item = await _equipmentDal.GetByIdAsync(id);

                if (item == null)
                {
                    return new ErrorDataResult<Equipment>(item, ErrorMessages<Equipment>.NoItemFound);
                }

                return new SuccessDataResult<Equipment>(item, SuccessMessages<Equipment>.ItemById);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving Equipment by ID: {Id}.", id);
                return new ErrorDataResult<Equipment>(null, ErrorMessages<Equipment>.UnexpectedError);
            }
        }

    }
}
