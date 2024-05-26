using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.EquipmentDTOs;
using Entities.DTOs.EquipmentShippingDetailDTOs;

namespace EquipmentAPI.AutoMappingProfiles
{
    public class EquipmentShippingDetailMapping:Profile
    {
        public EquipmentShippingDetailMapping()
        {
            CreateMap<EquipmentShippingDetail, CreateEquipmentShippingDetailDto>().ReverseMap();
            CreateMap<EquipmentShippingDetail, ResultEquipmentShippingDetailDto>().ReverseMap();
            CreateMap<EquipmentShippingDetail, UpdateEquipmentShippingDetailDto>().ReverseMap();
        }
    }
}
