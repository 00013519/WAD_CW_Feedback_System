using FeedbackSystem13519.Data;
using FeedbackSystem13519.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem13519.Repositories
{
    public class FeedbackRepository : IRepository<FeedbackItems>
    {
        private readonly FeedbackDBContext _dbContext;

        public FeedbackRepository(FeedbackDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        // Add or create new entity
        public async Task AddAsync(FeedbackItems entity)
        {
            await _dbContext.FeedbackItems.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        // Delete an entity
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.FeedbackItems.FindAsync(id);
            if (entity != null)
            {
                _dbContext.FeedbackItems.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        // Retrieve all entity from the database
        public async Task<IEnumerable<FeedbackItems>> GetAllAsync() => await _dbContext.FeedbackItems.ToArrayAsync();

        // Retrieve an entity from database using only an id
        public async Task<FeedbackItems> GetByIDAsync(int id) => await _dbContext.FeedbackItems.FindAsync(id);

        // Update the entity
        public async Task UpdateAsync(FeedbackItems entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
