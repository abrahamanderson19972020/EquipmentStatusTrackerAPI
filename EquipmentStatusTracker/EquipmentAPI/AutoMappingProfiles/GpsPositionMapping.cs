using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.EquipmentStatusDTOs;
using Entities.DTOs.GpsPositionDTOs;

namespace EquipmentAPI.AutoMappingProfiles
{
    public class GpsPositionMapping:Profile
    {
        public GpsPositionMapping()
        {
            CreateMap<GpsPosition, CreateGpsPositionDto>().ReverseMap();
            CreateMap<GpsPosition, ResultGpsPositionDto>().ReverseMap();
            CreateMap<GpsPosition, UpdateGpsPositionDto>().ReverseMap();
        }
    }
}
