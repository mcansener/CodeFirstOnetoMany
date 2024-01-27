using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CodeFirstOnetoMany.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            // Additional configurations if needed

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Read the connection string from appsettings.json
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Configure your database connection here
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
