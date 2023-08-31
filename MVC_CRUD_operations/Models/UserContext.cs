using Microsoft.EntityFrameworkCore;

namespace MVC_CRUD_operations.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            
        }
        public DbSet<Users> Users { get; set; }
    }
}
