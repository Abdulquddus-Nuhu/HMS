using Alansar.Core.Entities;
using Alansar.Core.Entities.Identity;
using Alansar.Core.Enums;
using Alansar.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Xml;

namespace Alansar.Data;

//public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    private readonly IHttpContextAccessor _httpContextAccessor;


    public AppDbContext(DbContextOptions<AppDbContext> option, IHttpContextAccessor httpContextAccessor) : base(option)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) 
    {
    }



    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<DiningSpace> DiningSpaces => Set<DiningSpace>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<DiningSchedule> DiningSchedules => Set<DiningSchedule>();
    public DbSet<DiningAssignment> DiningAssignments => Set<DiningAssignment>();
    public DbSet<Session> Sessions => Set<Session>();
    public DbSet<Grade> Grades => Set<Grade>();
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantSubscription> TenantSubscriptions => Set<TenantSubscription>();


    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.AddInterceptors(new TenantSaveChangesInterceptor(_httpContextAccessor, _tenantService));
    //    base.OnConfiguring(optionsBuilder);
    //}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //builder.HasDefaultSchema("App");

        //builder.Entity<Student>()
        //    .HasOne<User>()
        //    .WithMany()
        //    .HasForeignKey(s => s.UserId);
    }

}


// for design time ef-core migrations
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        // Get the environment name (Development, Staging, Production)
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
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }

}
