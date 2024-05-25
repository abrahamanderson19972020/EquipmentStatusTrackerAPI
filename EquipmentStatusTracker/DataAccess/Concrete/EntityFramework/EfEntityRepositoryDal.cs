
using DataAccess.Abstract;
using DataAccess.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryDal<T> : IEntityRepositoryDal<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ILogger<EfEntityRepositoryDal<T>> _logger;
        public EfEntityRepositoryDal(ApplicationDBContext dbContext, ILogger<EfEntityRepositoryDal<T>> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _dbContext.AddAsync(entity);
                var changes = await _dbContext.SaveChangesAsync();
                return changes > 0;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred while adding entity.");
            }
            return false;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _dbContext.Remove(entity);
                var changes = await _dbContext.SaveChangesAsync();
                return changes > 0;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred while deleting entity.");
            }
            return false;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbContext.Update(entity);
                var changes = await _dbContext.SaveChangesAsync();
                return changes > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the entity.");
                return false;
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all entities.");
                return new List<T>();
            }
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the entity with ID {Id}.", id);
                return null;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }

    }
}
