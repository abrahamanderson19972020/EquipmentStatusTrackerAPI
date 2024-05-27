using Business.ResponseModels.Abstract;
using Entities.Concrete;
using Entities.DTOs.EquipmentShippingDetailDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEquipmentShippingDetailService:IGenericService<EquipmentShippingDetail>
    {
        Task<IDataResult<List<ResultEquipmentShippingDetailDto>>> BusinessGetAllEquipmentShippingDetailsAsync();
        Task<IDataResult<ResultEquipmentShippingDetailDto>> BusinessGetEquipmentShippingDetailByIdAsync(int id);
    }
}
