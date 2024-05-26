using Business.Abstract;
using Business.Constants.Messages;
using Business.ResponseModels.Abstract;
using Business.ResponseModels.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.CustomerDTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly ILogger<CustomerManager> _logger;
        public CustomerManager(ICustomerDal customerDal, ILogger<CustomerManager> logger)
        {
            _customerDal = customerDal;
            _logger = logger;   
        }
        public async Task<IResult> BusinessAddAsync(Customer entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ErrorResult(ErrorMessages<Customer>.NoValidItem);
                }

                var result = await _customerDal.AddAsync(entity);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<Customer>.ItemAdded);
                }

                return new ErrorResult(ErrorMessages<Customer>.NoAddedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding customer.");
                return new ErrorResult(ErrorMessages<Customer>.UnexpectedError);
            }
        }

        public async Task<IResult> BusinessDeleteAsync(Customer entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ErrorResult(ErrorMessages<Customer>.NoValidItem);
                }

                var result = await _customerDal.DeleteAsync(entity);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<Customer>.ItemDeleted);
                }

                return new ErrorResult(ErrorMessages<Customer>.NoDeletedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting Customer.");
                return new ErrorResult(ErrorMessages<Customer>.UnexpectedError);
            }
        }

        public async Task<IResult> BusinessUpdateAsync(Customer entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ErrorResult(ErrorMessages<Customer>.NoValidItem);
                }

                var result = await _customerDal.UpdateAsync(entity);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<Customer>.ItemUpdated);
                }

                return new ErrorResult(ErrorMessages<Customer>.NoUpdatedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating an Customer.");
                return new ErrorResult(ErrorMessages<Customer>.UnexpectedError);
            }
        }

        public async Task<IDataResult<List<Customer>>> BusinessGetAllAsync()
        {
            try
            {
                var items = await _customerDal.GetAllAsync();

                if (items == null)
                {
                    return new ErrorDataResult<List<Customer>>(items, ErrorMessages<Customer>.NoItemFound);
                }

                return new SuccessDataResult<List<Customer>>(items, SuccessMessages<Customer>.ItemAllListed);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all Customers.");
                return new ErrorDataResult<List<Customer>>(null, ErrorMessages<Customer>.UnexpectedError);
            }
        }

        public async Task<IDataResult<Customer>> BusinessGetByIdAsync(int id)
        {
            try
            {
                var item = await _customerDal.GetByIdAsync(id);

                if (item == null)
                {
                    return new ErrorDataResult<Customer>(item, ErrorMessages<Customer>.NoItemFound);
                }

                return new SuccessDataResult<Customer>(item, SuccessMessages<Customer>.ItemById);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving Customer by ID: {Id}.", id);
                return new ErrorDataResult<Customer>(null, ErrorMessages<Customer>.UnexpectedError);
            }
        }

        public async Task<IDataResult<List<CustomerDetailDto>>> BusinessGetAllWithCommunicationAsync()
        {
            try
            {
                var items = await _customerDal.GetAllWithCommunicationAsync();

                if (items == null)
                {
                    return new ErrorDataResult<List<CustomerDetailDto>>(items, ErrorMessages<CustomerDetailDto>.NoItemFound);
                }

                return new SuccessDataResult<List<CustomerDetailDto>>(items, SuccessMessages<CustomerDetailDto>.ItemAllListed);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all Customers.");
                return new ErrorDataResult<List<CustomerDetailDto>>(null, ErrorMessages<CustomerDetailDto>.UnexpectedError);
            }
        }

        public async Task<IDataResult<CustomerDetailDto>> BusinessGetCustomerWithCustomerByIdAsync(int id)
        {
            try
            {
                var item = await _customerDal.GetCustomerWithCustomerByIdAsync(id);

                if (item == null)
                {
                    return new ErrorDataResult<CustomerDetailDto>(item, ErrorMessages<CustomerDetailDto>.NoItemFound);
                }

                return new SuccessDataResult<CustomerDetailDto>(item, SuccessMessages<CustomerDetailDto>.ItemById);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving Customer by ID: {Id}.", id);
                return new ErrorDataResult<CustomerDetailDto>(null, ErrorMessages<CustomerDetailDto>.UnexpectedError);
            }
        }
    }
}
