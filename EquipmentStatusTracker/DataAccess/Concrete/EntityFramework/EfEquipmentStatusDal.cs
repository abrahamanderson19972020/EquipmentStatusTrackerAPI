using DataAccess.Abstract;
using DataAccess.DatabaseContexts;
using Entities.Concrete;
using Entities.DTOs.EquipmentShippingDetailDTOs;
using Entities.DTOs.EquipmentStatusDTOs;
using Entities.DTOs.GpsPositionDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEquipmentStatusDal : EfEntityRepositoryDal<EquipmentStatus>, IEquipmentStatusDal
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<EfEntityRepositoryDal<EquipmentStatus>> _logger;
        public EfEquipmentStatusDal(ApplicationDBContext context, ILogger<EfEntityRepositoryDal<EquipmentStatus>> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<ResultEquipmentStatusDto>> GetAllEquipmentStatusesAsync()
        {
            try
            {
                var result = await (from equipmentStatus in _context.EquipmentStatuses
                                    join equipmentShippingDetail in _context.EquipmentShippingDetails
                                    on equipmentStatus.EquipmentShippingDetailId equals equipmentShippingDetail.Id
                                    join equipment in _context.Equipments
                                    on equipmentShippingDetail.EquipmentId equals equipment.Id
                                    join sendingAddress in _context.Addresses
                                    on equipmentShippingDetail.SendingAddressId equals sendingAddress.Id
                                    join destinationAddress in _context.Addresses
                                    on equipmentShippingDetail.DestinationAddressId equals destinationAddress.Id
                                    join customer in _context.Customers
                                    on equipmentStatus.CustomerId equals customer.Id
                                    select new ResultEquipmentStatusDto
                                    {
                                        Id = equipmentStatus.Id,
                                        EquipmentShippingDetailId = equipmentShippingDetail.Id,
                                        EquipmentShippingDetail = new ResultEquipmentShippingDetailDto
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
                                        },
                                        CustomerId = customer.Id,
                                        Customer = new Customer
                                        {
                                            Id = customer.Id,
                                            CustomerName = customer.CustomerName 
                                        },
                                        GpsPositions = equipmentStatus.GpsPositions.Select(gps => new ResultGpsPositionDto
                                        {
                                            Id = gps.Id,
                                            Latitude = gps.Latitude,
                                            Longitude = gps.Longitude,
                                            Timestamp = gps.Timestamp
                                        }).ToList()
                                    }).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the equipment statuses.");
                return new List<ResultEquipmentStatusDto>();
            }
        }

        public async  Task<ResultEquipmentStatusDto> GetEquipmentStatusByIdAsync(int id)
        {
            try
            {
                var result = await (from equipmentStatus in _context.EquipmentStatuses
                                    join equipmentShippingDetail in _context.EquipmentShippingDetails
                                    on equipmentStatus.EquipmentShippingDetailId equals equipmentShippingDetail.Id
                                    join equipment in _context.Equipments
                                    on equipmentShippingDetail.EquipmentId equals equipment.Id
                                    join sendingAddress in _context.Addresses
                                    on equipmentShippingDetail.SendingAddressId equals sendingAddress.Id
                                    join destinationAddress in _context.Addresses
                                    on equipmentShippingDetail.DestinationAddressId equals destinationAddress.Id
                                    join customer in _context.Customers
                                    on equipmentStatus.CustomerId equals customer.Id
                                    where equipmentStatus.Id == id
                                    select new ResultEquipmentStatusDto
                                    {
                                        Id = equipmentStatus.Id,
                                        EquipmentShippingDetailId = equipmentShippingDetail.Id,
                                        EquipmentShippingDetail = new ResultEquipmentShippingDetailDto
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
                                        },
                                        CustomerId = customer.Id,
                                        Customer = new Customer
                                        {
                                            Id = customer.Id,
                                            CustomerName = customer.CustomerName
                                        },
                                        GpsPositions = equipmentStatus.GpsPositions.Select(gps => new ResultGpsPositionDto
                                        {
                                            Id = gps.Id,
                                            Latitude = gps.Latitude,
                                            Longitude = gps.Longitude,
                                            Timestamp = gps.Timestamp
                                        }).ToList()
                                    }).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the equipment status by ID.");
                return null;
            }
        }
    }
}
