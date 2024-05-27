using Business.ResponseModels.Abstract;
using Business.ResponseModels.Concrete;
using Entities.Concrete;
using Entities.DTOs.EquipmentStatusDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEquipmentStatusService:IGenericService<EquipmentStatus>
    {
        Task<IDataResult<List<ResultEquipmentStatusDto>>> GetAllEquipmentStatusesAsync();
        Task<IDataResult<ResultEquipmentStatusDto>> GetEquipmentStatusByIdAsync(int id);
    }
}
