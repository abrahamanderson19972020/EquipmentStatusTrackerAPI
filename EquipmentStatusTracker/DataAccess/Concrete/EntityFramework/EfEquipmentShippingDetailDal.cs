using DataAccess.Abstract;
using DataAccess.DatabaseContexts;
using Entities.Concrete;
using Entities.DTOs.EquipmentShippingDetailDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEquipmentShippingDetailDal : EfEntityRepositoryDal<EquipmentShippingDetail>, IEquipmentShippingDetailDal
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<EfEntityRepositoryDal<EquipmentShippingDetail>> _logger;
        public EfEquipmentShippingDetailDal(ApplicationDBContext context, ILogger<EfEntityRepositoryDal<EquipmentShippingDetail>> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<ResultEquipmentShippingDetailDto>> GetAllEquipmentShippingDetailsAsync()
        {
            try
            {
                var result = from equipmentShippingDetail in _context.EquipmentShippingDetails
                             join equipment in _context.Equipments
                             on equipmentShippingDetail.EquipmentId equals equipment.Id
                             join sendingAddress in _context.Addresses
                             on equipmentShippingDetail.SendingAddressId equals sendingAddress.Id
                             join destinationAddress in _context.Addresses
                             on equipmentShippingDetail.DestinationAddressId equals destinationAddress.Id
                             select new ResultEquipmentShippingDetailDto
                             {
                                 Id = equipmentShippingDetail.Id,
                                 EquipmentId = equipment.Id,
                                 EquipmentName = equipment.Name, 
                                 Quantity = equipmentShippingDetail.Quantity,
                                 SendingAddressId = sendingAddress.Id,
                                 SendingStreet = sendingAddress.Street,
                                 SendingStreetNumber = sendingAddress.StreetNumber,
                                 SendingPostalCode = sendingAddress.PostalCode,
                                 SendingCity = sendingAddress.City,
                                 SendingState = sendingAddress.State,
                                 SendingCountry = sendingAddress.Country,
                                 DestinationAddressId = destinationAddress.Id,
                                 DestinationStreet = destinationAddress.Street,
                                 DestinationStreetNumber = destinationAddress.StreetNumber,
                                 DestinationPostalCode = destinationAddress.PostalCode,
                                 DestinationCity = destinationAddress.City,
                                 DestinationState = destinationAddress.State,
                                 DestinationCountry = destinationAddress.Country,
                                 AdditionalNotes = equipmentShippingDetail.AdditionalNotes
                             };

                return await result.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all equipment shipping details.");
                return new List<ResultEquipmentShippingDetailDto>();
            }

        }

        public async Task<ResultEquipmentShippingDetailDto> GetEquipmentShippingDetailByIdAsync(int id)
        {
            try
            {
                var exists = await _context.EquipmentShippingDetails.AnyAsync(esd => esd.Id == id);

                if (!exists)
                {
                    _logger.LogWarning("No equipment shipping detail found for id {Id}", id);
                    return null;
                }

                var result = await (from equipmentShippingDetail in _context.EquipmentShippingDetails
                                    join equipment in _context.Equipments
                                    on equipmentShippingDetail.EquipmentId equals equipment.Id
                                    join sendingAddress in _context.Addresses
                                    on equipmentShippingDetail.SendingAddressId equals sendingAddress.Id
                                    join destinationAddress in _context.Addresses
                                    on equipmentShippingDetail.DestinationAddressId equals destinationAddress.Id
                                    where equipmentShippingDetail.Id == id
                                    select new ResultEquipmentShippingDetailDto
                                    {
                                        Id = equipmentShippingDetail.Id,
                                        EquipmentId = equipment.Id,
                                        EquipmentName = equipment.Name, // Assuming Equipment entity has a Name property
                                        Quantity = equipmentShippingDetail.Quantity,
                                        SendingAddressId = sendingAddress.Id,
                                        SendingStreet = sendingAddress.Street,
                                        SendingStreetNumber = sendingAddress.StreetNumber,
                                        SendingPostalCode = sendingAddress.PostalCode,
                                        SendingCity = sendingAddress.City,
                                        SendingState = sendingAddress.State,
                                        SendingCountry = sendingAddress.Country,
                                        DestinationAddressId = destinationAddress.Id,
                                        DestinationStreet = destinationAddress.Street,
                                        DestinationStreetNumber = destinationAddress.StreetNumber,
                                        DestinationPostalCode = destinationAddress.PostalCode,
                                        DestinationCity = destinationAddress.City,
                                        DestinationState = destinationAddress.State,
                                        DestinationCountry = destinationAddress.Country,
                                        AdditionalNotes = equipmentShippingDetail.AdditionalNotes
                                    }).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the equipment shipping detail for id {Id}", id);
                return null;
            }
        }
    }
}
