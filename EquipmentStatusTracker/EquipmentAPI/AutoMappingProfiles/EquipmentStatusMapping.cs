using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.EquipmentShippingDetailDTOs;
using Entities.DTOs.EquipmentStatusDTOs;

namespace EquipmentAPI.AutoMappingProfiles
{
    public class EquipmentStatusMapping:Profile
    {
        public EquipmentStatusMapping()
        {
            CreateMap<EquipmentStatus, CreateEquipmentStatusDto>().ReverseMap();
            CreateMap<EquipmentStatus, ResultEquipmentStatusDto>().ReverseMap();
            CreateMap<EquipmentStatus, UpdateEquipmentStatusDto>().ReverseMap();
        }
    }
}
