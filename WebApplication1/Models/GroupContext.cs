using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class GroupContext : DbContext
    {
        public GroupContext()
        {
        }
        public GroupContext(DbContextOptions<GroupContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Group> Groups { get; set; }

    }
}
