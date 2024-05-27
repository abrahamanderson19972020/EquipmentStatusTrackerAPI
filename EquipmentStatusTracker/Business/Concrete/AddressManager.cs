using Business.Abstract;
using Business.Constants.Messages;
using Business.ResponseModels.Abstract;
using Business.ResponseModels.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;
        private readonly ILogger<AddressManager> _logger;

        public AddressManager(IAddressDal addressDal, ILogger<AddressManager> logger)
        {
            _addressDal = addressDal;
            _logger = logger;
        }

        public async Task<IResult> BusinessAddAsync(Address entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ErrorResult(ErrorMessages<Address>.NoValidItem);
                }

                var result = await _addressDal.AddAsync(entity);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<Address>.ItemAdded);
                }

                return new ErrorResult(ErrorMessages<Address>.NoAddedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding Address.");
                return new ErrorResult(ErrorMessages<Address>.UnexpectedError);
            }
        }

        public async Task<IResult> BusinessDeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return new ErrorResult(ErrorMessages<Address>.NoValidItem);
                }

                var result = await _addressDal.DeleteAsync(id);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<Address>.ItemDeleted);
                }

                return new ErrorResult(ErrorMessages<Address>.NoItemFound);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting Address.");
                return new ErrorResult(ErrorMessages<Address>.UnexpectedError);
            }
        }

        public async Task<IResult> BusinessUpdateAsync(Address entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ErrorResult(ErrorMessages<Address>.NoValidItem);
                }
                var address = _addressDal.GetByIdAsync(entity.Id);  
                if (address.Result == null)
                {
                    return new ErrorResult(ErrorMessages<Address>.NoItemFound);
                }
                var result = await _addressDal.UpdateAsync(entity);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<Address>.ItemUpdated);
                }

                return new ErrorResult(ErrorMessages<Address>.NoUpdatedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating Address.");
                return new ErrorResult(ErrorMessages<Address>.UnexpectedError);
            }
        }

        public async Task<IDataResult<List<Address>>> BusinessGetAllAsync()
        {
            try
            {
                var items = await _addressDal.GetAllAsync();

                if (items == null)
                {
                    return new ErrorDataResult<List<Address>>(items, ErrorMessages<Address>.NoItemFound);
                }

                return new SuccessDataResult<List<Address>>(items, SuccessMessages<Address>.ItemAllListed);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all Addresses.");
                return new ErrorDataResult<List<Address>>(null,ErrorMessages<Address>.UnexpectedError);
            }
        }

        public async Task<IDataResult<Address>> BusinessGetByIdAsync(int id)
        {
            try
            {
                var item = await _addressDal.GetByIdAsync(id);

                if (item == null)
                {
                    return new ErrorDataResult<Address>(item, ErrorMessages<Address>.NoItemFound);
                }

                return new SuccessDataResult<Address>(item, SuccessMessages<Address>.ItemById);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving Address by ID: {Id}.", id);
                return new ErrorDataResult<Address>(null, ErrorMessages<Address>.UnexpectedError);
            }
        }
    }
}
