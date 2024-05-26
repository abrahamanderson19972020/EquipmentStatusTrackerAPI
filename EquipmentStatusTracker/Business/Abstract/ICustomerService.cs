using Business.ResponseModels.Abstract;
using Entities.Concrete;
using Entities.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService:IGenericService<Customer>
    {
        Task<IDataResult<List<CustomerDetailDto>>> BusinessGetAllWithCommunicationAsync();
        Task<IDataResult<CustomerDetailDto>> BusinessGetCustomerWithCustomerByIdAsync(int id);
    }
}
