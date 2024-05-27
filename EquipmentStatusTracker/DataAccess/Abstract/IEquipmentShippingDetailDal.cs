using Entities.Concrete;
using Entities.DTOs.EquipmentShippingDetailDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEquipmentShippingDetailDal : IEntityRepositoryDal<EquipmentShippingDetail>
    {
        Task<List<ResultEquipmentShippingDetailDto>> GetAllEquipmentShippingDetailsAsync();
        Task<ResultEquipmentShippingDetailDto> GetEquipmentShippingDetailByIdAsync(int id);
    }
}
