using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.CommunicationDetailDTOs;
using Entities.DTOs.CustomerDTOs;

namespace EquipmentAPI.AutoMappingProfiles
{
    public class CustomerMapping:Profile
    {
        public CustomerMapping()
        {
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, ResultCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
        }
    }
}
