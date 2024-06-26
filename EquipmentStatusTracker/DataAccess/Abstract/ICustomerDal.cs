﻿using Entities.Concrete;
using Entities.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICustomerDal:IEntityRepositoryDal<Customer>
    {
        Task<List<CustomerDetailDto>> GetAllWithCommunicationAsync();
        Task<CustomerDetailDto> GetCustomerWithCustomerByIdAsync(int id);
    }
}
