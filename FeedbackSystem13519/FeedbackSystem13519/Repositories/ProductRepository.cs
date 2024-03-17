using FeedbackSystem13519.Data;
using FeedbackSystem13519.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem13519.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly FeedbackDBContext _dbContext;

        public ProductRepository(FeedbackDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        // Add or create new entity
        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        // Delete an entity
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Products.FindAsync(id);
            if (entity != null)
            {
                _dbContext.Products.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        // Retrieve all entity from the database
        public async Task<IEnumerable<Product>> GetAllAsync() => await _dbContext.Products.ToArrayAsync();

        // Retrieve an entity from database using only an id
        public async Task<Product> GetByIDAsync(int id) => await _dbContext.Products.FirstOrDefaultAsync(b => b.Id == id);

        // Update the entity
        public async Task UpdateAsync(Product entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
