using Alansar.Core.Entities;
using Alansar.Core.Entities.Identity;
using Alansar.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Alansar.Data
{

    public class IdentityDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.AddInterceptors(new SyncEntityInterceptor());
        //    base.OnConfiguring(optionsBuilder);
        //}

        // No global TenantId filter here
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");

            // Configure composite primary key for IdentityUserRole<int>
            builder.Entity<IdentityUserRole<int>>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            // User and Tenant schema managed by IdentityDbContext
            //builder.Entity<User>().ToTable("User");
            //builder.Entity<Tenant>().ToTable("Tenant");

            // Configure other Identity-related entities if needed
        }
    }

    public class IdentityDbContextFactory : IDesignTimeDbContextFactory<IdentityDbContext>
    {
        public IdentityDbContext CreateDbContext(string[] args)
        {
            //Get the environment name(Development, Staging, Production)
             string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            // Build the configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true) // Load environment-specific settings
                .Build();

            // Get the connection string
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

            // Configure DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();
            optionsBuilder.UseNpgsql(connectionString);


            return new IdentityDbContext(optionsBuilder.Options);
        }
    }

}
