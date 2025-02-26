using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Dto
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
    }
}