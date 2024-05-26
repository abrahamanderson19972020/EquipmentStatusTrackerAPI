using DataAccess.Abstract;
using DataAccess.DatabaseContexts;
using Entities.Concrete;
using Entities.DTOs.CustomerDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryDal<Customer>, ICustomerDal
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<EfEntityRepositoryDal<Customer>> _logger;
        public EfCustomerDal(ApplicationDBContext context, ILogger<EfEntityRepositoryDal<Customer>> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<CustomerDetailDto>> GetAllWithCommunicationAsync()
        {
            try
            {
                var result = from customer in _context.Customers
                             join communicationDetail in _context.CommunicationDetails
                             on customer.CommunicationDetailId equals communicationDetail.Id
                             join address in _context.Addresses
                             on communicationDetail.AddressId equals address.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.Id,
                                 CustomerName = customer.CustomerName,
                                 Email = communicationDetail.Email,
                                 PhoneNumber = communicationDetail.PhoneNumber,
                                 Street = address.Street,
                                 StreetNumber = address.StreetNumber,
                                 PostalCode = address.PostalCode,
                                 City = address.City,
                                 State = address.State,
                                 Country = address.Country
                             };

                return await result.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all entities with communication details.");
                return new List<CustomerDetailDto>();
            }
        }

        public async Task<CustomerDetailDto> GetCustomerWithCustomerByIdAsync(int id)
        {
            try
            {
                var result = from customer in _context.Customers
                             join communicationDetail in _context.CommunicationDetails
                             on customer.CommunicationDetailId equals communicationDetail.Id
                             join address in _context.Addresses
                             on communicationDetail.AddressId equals address.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.Id,
                                 CustomerName = customer.CustomerName,
                                 Email = communicationDetail.Email,
                                 PhoneNumber = communicationDetail.PhoneNumber,
                                 Street = address.Street,
                                 StreetNumber = address.StreetNumber,
                                 PostalCode = address.PostalCode,
                                 City = address.City,
                                 State = address.State,
                                 Country = address.Country
                             };
                return await result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the entity with ID {Id}.", id);
                return null;
            }
        }
    }
}
