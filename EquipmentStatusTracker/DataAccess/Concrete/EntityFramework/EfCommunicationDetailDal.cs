using DataAccess.Abstract;
using DataAccess.DatabaseContexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCommunicationDetailDal:EfEntityRepositoryDal<CommunicationDetail>, ICommunicationDetailDal
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<EfEntityRepositoryDal<CommunicationDetail>> _logger;
        public EfCommunicationDetailDal(ApplicationDBContext context, ILogger<EfEntityRepositoryDal<CommunicationDetail>> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<CommunicationDetail>> GetAllWithAdressesAsync()
        {

            try
            {
                return await _context.CommunicationDetails.Include(c => c.CustomerAddress).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all entities with customer addresses.");
                return new List<CommunicationDetail>();
            }
        }

        public async  Task<CommunicationDetail> GetCommunicationDetailWithAddressByIdAsync(int id)
        {
            try
            {
                return await _context.CommunicationDetails
                                     .Include(c => c.CustomerAddress)
                                     .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the entity with ID {Id}.", id);
                return null;
            }
        }
    }
}
