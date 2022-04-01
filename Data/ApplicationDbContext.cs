using Microsoft.EntityFrameworkCore;
using PRWeb.Models;

namespace PRWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<User> Users{ get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options){ 
        
        
        }
    }
}
