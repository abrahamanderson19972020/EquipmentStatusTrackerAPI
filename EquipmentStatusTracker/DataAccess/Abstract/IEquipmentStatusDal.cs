using Entities.Concrete;
using Entities.DTOs.EquipmentShippingDetailDTOs;
using Entities.DTOs.EquipmentStatusDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEquipmentStatusDal:IEntityRepositoryDal<EquipmentStatus>
    {
        Task<List<ResultEquipmentStatusDto>> GetAllEquipmentStatusesAsync();
        Task<ResultEquipmentStatusDto> GetEquipmentStatusByIdAsync(int id);
    }
}
