using FeedbackSystem13519.Data;
using FeedbackSystem13519.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem13519.Repositories
{
    public class FeedbackRepository : IRepository<Feedback>
    {
        private readonly FeedbackDBContext _dbContext;

        public FeedbackRepository(FeedbackDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        // Add or create new entity
        public async Task AddAsync(Feedback entity)
        {
            await _dbContext.Feedbacks.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        // Delete an entity
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Feedbacks.FindAsync(id);
            if (entity != null)
            {
                _dbContext.Feedbacks.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        // Retrieve all entity from the database
        public async Task<IEnumerable<Feedback>> GetAllAsync() => await _dbContext.Feedbacks.Include(f=>f.Product).ToArrayAsync();

        // Retrieve an entity from database using only an id
        public async Task<Feedback> GetByIDAsync(int id) => await _dbContext.Feedbacks.Include(f => f.Product).FirstOrDefaultAsync(b=>b.Id == id);
            
        // Update the entity
        public async Task UpdateAsync(Feedback entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
