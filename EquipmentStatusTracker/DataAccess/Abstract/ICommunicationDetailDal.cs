﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICommunicationDetailDal:IEntityRepositoryDal<CommunicationDetail>
    {
        Task<List<CommunicationDetail>> GetAllWithAdressesAsync();
        Task<CommunicationDetail> GetCommunicationDetailWithAddressByIdAsync(int id);
    }
}
