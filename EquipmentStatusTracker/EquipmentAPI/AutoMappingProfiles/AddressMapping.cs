using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.AddressDTOs;

namespace EquipmentAPI.AutoMappingProfiles
{
    public class AddressMapping:Profile
    {
        public AddressMapping()
        {
            CreateMap<Address, CreateAddressDto>().ReverseMap();
            CreateMap<Address, ResultAddressDto>().ReverseMap();
            CreateMap<Address, UpdateAddressDto>().ReverseMap();
        }
    }
}
