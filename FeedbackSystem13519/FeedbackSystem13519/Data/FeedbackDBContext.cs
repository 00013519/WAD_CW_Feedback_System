using FeedbackSystem13519.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace FeedbackSystem13519.Data
{
    public class FeedbackDBContext : DbContext
    {
        public FeedbackDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
