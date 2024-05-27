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
    public class CommunicationDetailManager : ICommunicationDetailService
    {
        private readonly ICommunicationDetailDal _communicationDetailDal;
        private readonly ILogger<CommunicationDetailManager> _logger;
        public CommunicationDetailManager(ICommunicationDetailDal communicationDetailDal, 
                                          ILogger<CommunicationDetailManager> logger)
        {
            _communicationDetailDal = communicationDetailDal;
            _logger = logger;
        }
        public async Task<IResult> BusinessAddAsync(CommunicationDetail entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ErrorResult(ErrorMessages<CommunicationDetail>.NoValidItem);
                }

                var result = await _communicationDetailDal.AddAsync(entity);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<CommunicationDetail>.ItemAdded);
                }

                return new ErrorResult(ErrorMessages<CommunicationDetail>.NoAddedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding  communication detail.");
                return new ErrorResult(ErrorMessages<CommunicationDetail>.UnexpectedError);
            }
        }

        public async Task<IResult> BusinessDeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return new ErrorResult(ErrorMessages<CommunicationDetail>.NoValidItem);
                }

                var result = await _communicationDetailDal.DeleteAsync(id);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<CommunicationDetail>.ItemDeleted);
                }

                return new ErrorResult(ErrorMessages<CommunicationDetail>.NoItemFound);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting  communication detail.");
                return new ErrorResult(ErrorMessages<CommunicationDetail>.UnexpectedError);
            }
        }

        public async Task<IResult> BusinessUpdateAsync(CommunicationDetail entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ErrorResult(ErrorMessages<CommunicationDetail>.NoValidItem);
                }
                var commuunicationDetail = await _communicationDetailDal.GetByIdAsync(entity.Id);
                if (commuunicationDetail == null)
                {
                    return new ErrorResult(ErrorMessages<CommunicationDetail>.NoItemFound);
                }
                var result = await _communicationDetailDal.UpdateAsync(entity);

                if (result)
                {
                    return new SuccessResult(SuccessMessages<CommunicationDetail>.ItemUpdated);
                }

                return new ErrorResult(ErrorMessages<CommunicationDetail>.NoUpdatedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating communication detail.");
                return new ErrorResult(ErrorMessages<CommunicationDetail>.UnexpectedError);
            }
        }

        public async Task<IDataResult<List<CommunicationDetail>>> BusinessGetAllAsync()
        {
            try
            {
                var items = await _communicationDetailDal.GetAllAsync();

                if (items == null)
                {
                    return new ErrorDataResult<List<CommunicationDetail>>(items, ErrorMessages<CommunicationDetail>.NoItemFound);
                }

                return new SuccessDataResult<List<CommunicationDetail>>(items, SuccessMessages<CommunicationDetail>.ItemAllListed);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all communication details.");
                return new ErrorDataResult<List<CommunicationDetail>>(null, ErrorMessages<CommunicationDetail>.UnexpectedError);
            }
        }

        public async Task<IDataResult<CommunicationDetail>> BusinessGetByIdAsync(int id)
        {
            try
            {
                var item = await _communicationDetailDal.GetByIdAsync(id);

                if (item == null)
                {
                    return new ErrorDataResult<CommunicationDetail>(item, ErrorMessages<CommunicationDetail>.NoItemFound);
                }

                return new SuccessDataResult<CommunicationDetail>(item, SuccessMessages<CommunicationDetail>.ItemById);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving an communication detail by ID: {Id}.", id);
                return new ErrorDataResult<CommunicationDetail>(null, ErrorMessages<CommunicationDetail>.UnexpectedError);
            }
        }

        public async Task<IDataResult<List<CommunicationDetail>>> BusinessGetAllWithAdressesAsync()
        {
            try
            {
                var items = await _communicationDetailDal.GetAllWithAdressesAsync();

                if (items == null)
                {
                    return new ErrorDataResult<List<CommunicationDetail>>(items, ErrorMessages<CommunicationDetail>.NoItemFound);
                }

                return new SuccessDataResult<List<CommunicationDetail>>(items, SuccessMessages<CommunicationDetail>.ItemAllListed);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all communication details with addresses.");
                return new ErrorDataResult<List<CommunicationDetail>>(null, ErrorMessages<CommunicationDetail>.UnexpectedError);
            }
        }

        public async Task<IDataResult<CommunicationDetail>> BusinessGetCommunicationDetailWithAddressByIdAsync(int id)
        {
            try
            {
                var item = await _communicationDetailDal.GetCommunicationDetailWithAddressByIdAsync(id);

                if (item == null)
                {
                    return new ErrorDataResult<CommunicationDetail>(item, ErrorMessages<CommunicationDetail>.NoItemFound);
                }

                return new SuccessDataResult<CommunicationDetail>(item, SuccessMessages<CommunicationDetail>.ItemById);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving communication detail with address by ID: {Id}.", id);
                return new ErrorDataResult<CommunicationDetail>(null, ErrorMessages<CommunicationDetail>.UnexpectedError);
            }
        }
    }
}
