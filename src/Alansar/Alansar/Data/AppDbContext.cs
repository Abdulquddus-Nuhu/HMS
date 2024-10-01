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
public class AppDbContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ITenantService _tenantService;


    public AppDbContext(DbContextOptions<AppDbContext> option, ITenantService tenantService, IHttpContextAccessor httpContextAccessor) : base(option)
    {
        _httpContextAccessor = httpContextAccessor;
        _tenantService = tenantService;
    }

    public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) 
    {
    }



    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Student> Students => Set<Student>();
    /// <summary>
    /// duplicate table of aspnetusers
    /// </summary>
    public DbSet<User> User => Set<User>();

    /// <summary>
    /// duplicate taBLE FOR Tenant
    /// </summary>
    public DbSet<Tenant> Tenant => Set<Tenant>();

    public DbSet<DiningSpace> DiningSpaces => Set<DiningSpace>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<DiningSchedule> DiningSchedules => Set<DiningSchedule>();
    public DbSet<DiningAssignment> DiningAssignments => Set<DiningAssignment>();
    public DbSet<Session> Sessions => Set<Session>();
    public DbSet<Grade> Grades => Set<Grade>();
    public DbSet<TenantSubscription> TenantSubscriptions => Set<TenantSubscription>();


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new TenantSaveChangesInterceptor(_httpContextAccessor, _tenantService));
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("App");

        //builder.Entity<Student>()
        //    .HasOne(s => s.User)
        //    .WithOne()
        //    .HasForeignKey<Student>(s => s.UserId);

        builder.Entity<Student>()
            .HasOne<User>() // Reference User by its ID, without mapping the entire entity
            .WithMany()
            .HasForeignKey(s => s.UserId);



        //for migration
        if (_httpContextAccessor?.HttpContext == null)
        {
            // Design-time logic (e.g., when running migrations)
            // Do not apply tenant-based or role-based filtering during design-time operations
            return;
        }

        // Retrieve TenantKey from the context or service
        string tenantKey = string.Empty;
        string role3 = string.Empty;

        if (_httpContextAccessor.HttpContext != null)
        {
            //tenantKey = _tenantService.GetCurrentUserTenantId();
            //role3 = _tenantService.GetCurrentUserRole();

            tenantKey = GetTenantIdFromHeaders();
            role3 = GetRoleFromHeaders();
        }

        // Apply the tenant filter to entities
        //if (role3 != "Admin" && role3 != "SuperAdmin" || _httpContextAccessor.HttpContext.User is not null)
        //if (role3 != "SuperAdmin")
        //{
        //    //builder.ApplyTenantQueryFilter(tenantKey);
        //    builder.ApplyTenantQueryFilter(tenantKey);
        //}

        //builder.ApplyTenantQueryFilter(tenantKey);



        // Extract TenantId and Role from headers
        var tenantId = GetTenantIdFromHeaders();
        var role = GetRoleFromHeaders();
 
        string tenantId2 = string.Empty;
        string role2 = string.Empty;

        if (_httpContextAccessor.HttpContext is not null)
        {
            tenantId2 = _tenantService.GetCurrentUserTenantId();
            role2 = _tenantService.GetCurrentUserRole();
        }

    }

    private string GetTenantIdFromHeaders()
    {
        if (_httpContextAccessor.HttpContext is not null)
        {
            return _httpContextAccessor.HttpContext.Request.Headers["TenantId"].ToString();
        }
        else
        { 
            return string.Empty;
        }
    }

    private string GetRoleFromHeaders()
    {
        if (_httpContextAccessor.HttpContext is not null)
        {
            return _httpContextAccessor.HttpContext.Request.Headers["Role"].ToString();
        }
        else
        {
            return string.Empty;
        }
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