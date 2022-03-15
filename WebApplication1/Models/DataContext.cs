using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Record>().Property<bool>("isActive");
            builder.Entity<Record>().HasQueryFilter(m => EF.Property<bool>(m, "isActive") == true);
            builder.Entity<Subject>().Property<bool>("isActive");
            builder.Entity<Subject>().HasQueryFilter(m => EF.Property<bool>(m, "isActive") == true);
            builder.Entity<Group>().Property<bool>("isActive");
            builder.Entity<Group>().HasQueryFilter(m => EF.Property<bool>(m, "isActive") == true);
            builder.Entity<User>().Property<bool>("isActive");
            builder.Entity<User>().HasQueryFilter(m => EF.Property<bool>(m, "isActive") == true);
        }
        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["isActive"] = true;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["isActive"] = false;
                        break;
                }
            }
        }

        public DbSet<Record> Records { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
