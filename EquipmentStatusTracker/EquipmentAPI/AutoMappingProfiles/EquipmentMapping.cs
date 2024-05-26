using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.CustomerDTOs;
using Entities.DTOs.EquipmentDTOs;

namespace EquipmentAPI.AutoMappingProfiles
{
    public class EquipmentMapping:Profile
    {
        public EquipmentMapping()
        {
            CreateMap<Equipment, CreateEquipmentDto>().ReverseMap();
            CreateMap<Equipment, ResultEquipmentDto>().ReverseMap();
            CreateMap<Equipment, UpdateEquipmentDto>().ReverseMap();
        }
    }
}
