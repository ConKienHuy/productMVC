using Microsoft.EntityFrameworkCore;
using productMVC.Models;

namespace productMVC.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { 

        }  
        
        public DbSet<Product> Products { get; set; }
    }
}
