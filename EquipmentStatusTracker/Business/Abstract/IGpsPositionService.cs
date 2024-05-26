using Business.ResponseModels.Abstract;
using Entities.Concrete;
using Entities.DTOs.GpsPositionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGpsPositionService:IGenericService<GpsPosition>
    {
        Task<IDataResult<List<ResultGpsPositionDto>>> BusinessGetAllGpsPositionAsync();
        Task<IDataResult<ResultGpsPositionDto>> BusinessGetGpsPositionByIdAsync(int id);
    }
}
