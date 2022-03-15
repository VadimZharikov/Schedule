using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApplication1.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.Migrate();
            if (!Users.Any())
            {
                Users.Add(new User { UserName = "Admin", Password = "Admin", Permission = "Admin" });
            }
            SaveChanges();
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
