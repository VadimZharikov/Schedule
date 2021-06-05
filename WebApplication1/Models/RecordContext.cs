using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class RecordContext : DbContext
    {
        public RecordContext()
        {

        }
        public RecordContext(DbContextOptions<RecordContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Record> Records { get; set; }
    }
}
