using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.AddressDTOs;
using Entities.DTOs.CommunicationDetailDTOs;

namespace EquipmentAPI.AutoMappingProfiles
{
    public class CommunicationDetailMapping:Profile
    {
        public CommunicationDetailMapping()
        {
            CreateMap<CommunicationDetail, CreateCommunicationDetailDto>().ReverseMap();
            CreateMap<CommunicationDetail, ResultCommunicationDetailDto>().ReverseMap();
            CreateMap<CommunicationDetail, UpdateCommunicationDetailDto>().ReverseMap();
        }
    }
}
