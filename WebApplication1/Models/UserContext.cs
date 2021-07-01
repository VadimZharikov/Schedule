using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApplication1.Models
{
    public class UserContext : DbContext
    {
        public UserContext()
        {

        }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.Migrate();
            if (!Users.Any())
            {
                Users.Add(new User { UserName = "Admin", Password = "Admin", Permission = "Admin"});
            }
            SaveChanges();
        }
        public DbSet<User> Users { get; set; }

    }
}
