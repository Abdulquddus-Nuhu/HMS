using Alansar.Core.Entities;
using Alansar.Core.Entities.Identity;
using Alansar.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Alansar.Data
{
    //public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User>(options)
    //{
    //}

    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }

        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<DiningSpace> DiningSpaces => Set<DiningSpace>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<DiningSchedule> DiningSchedules => Set<DiningSchedule>();
        public DbSet<DiningAssignment> DiningAssignments => Set<DiningAssignment>();
        public DbSet<Session> Sessions => Set<Session>();
        public DbSet<Grade> Grades => Set<Grade>();
        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<TenantSubscription> TenantSubscriptions => Set<TenantSubscription>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Student>(s => s.UserId);


            // Seed default data
            builder.Entity<Grade>().HasData(
                new Grade { Id = 1, Name = "JSS1" },
                new Grade { Id = 2, Name = "JSS2" },
                new Grade { Id = 3, Name = "JSS3" }
            );

            builder.Entity<Room>().HasData(
                new Room { Id = 1, RoomNumber = "101", Capacity = 24, Type = "Single", IsAvailable = true, Price = 2000 },
                new Room { Id = 2, RoomNumber = "102", Capacity = 20, Type = "Double", IsAvailable = true, Price = 3000 },
                new Room { Id = 3, RoomNumber = "103", Capacity = 54, Type = "Single", IsAvailable = false, Price = 6000 },
                new Room { Id = 4, RoomNumber = "104", Capacity = 05, Type = "Double", IsAvailable = true, Price = 9000 },
                new Room { Id = 5, RoomNumber = "105", Capacity = 32, Type = "Single", IsAvailable = false, Price = 4000 }
                // Add up to 10 rooms
            );

            builder.Entity<DiningSpace>().HasData(
                new DiningSpace { Id = 1, Name = "Dining Hall 1", Capacity = 100 },
                new DiningSpace { Id = 2, Name = "Dining Hall 2", Capacity = 150 }
            );

            //builder.Entity<Session>().HasData(
            //    new Session { Id = 1, Year = "2022/2023", StartDate = new DateTime(2022, 9, 12, 0, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2023,9,12, 0, 0, 0, DateTimeKind.Utc) },
            //    new Session { Id = 2, Year = "2021/2022", StartDate = new DateTime(2021,9,12, 0, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2022, 9, 12, 0, 0, 0, DateTimeKind.Utc) }
            //);

            builder.Entity<Session>().HasData(
                new Session
                {
                    Id = 1,
                    Year = "2022/2023",
                    StartDate = new DateTime(2022, 9, 16, 21, 46, 17, 608, DateTimeKind.Utc),
                    EndDate = new DateTime(2023, 9, 12, 21, 46, 17, 608, DateTimeKind.Utc)
                },
                new Session
                {
                    Id = 2,
                    Year = "2021/2022",
                    StartDate = new DateTime(2021, 9, 12, 21, 46, 17, 608, DateTimeKind.Utc),
                    EndDate = new DateTime(2022, 9, 12, 21, 46, 17, 608, DateTimeKind.Utc)
                }
            );



            // Seed roles
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 4, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
                new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int> { Id = 2, Name = "Student", NormalizedName = "STUDENT" },
                new IdentityRole<int> { Id = 3, Name = "TenantAdmin", NormalizedName = "TENANTADMIN" }
            );

            // Seed default admin users
            builder.Entity<User>().HasData(
                new User { Id = 6, RoleType = RoleType.SuperAdmin, FirstName = "Boss", UserName = "boss@example.com", NormalizedUserName = "BOSS@EXAMPLE.COM", Email = "boss@example.com", NormalizedEmail = "BOSS@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = new PasswordHasher<User>().HashPassword(null, "Boss1Pass"), SecurityStamp = string.Empty },
                new User { Id = 1, RoleType = RoleType.Admin, FirstName = "Admin1", UserName = "admin1@example.com", NormalizedUserName = "ADMIN1@EXAMPLE.COM", Email = "admin1@example.com", NormalizedEmail = "ADMIN1@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = new PasswordHasher<User>().HashPassword(null, "Admin1Pass"), SecurityStamp = string.Empty },
                new User { Id = 2, RoleType = RoleType.Admin, FirstName = "Admin2", UserName = "admin2@example.com", NormalizedUserName = "ADMIN2@EXAMPLE.COM", Email = "admin2@example.com", NormalizedEmail = "ADMIN2@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = new PasswordHasher<User>().HashPassword(null, "Admin2Pass"), SecurityStamp = string.Empty },
                new User { Id = 3, RoleType = RoleType.Student, FirstName = "Student1", UserName = "student1@example.com", NormalizedUserName = "STUDENT1@EXAMPLE.COM", Email = "student1@example.com", NormalizedEmail = "STUDENT1@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = new PasswordHasher<User>().HashPassword(null, "Student1Pass"), SecurityStamp = string.Empty },
                new User { Id = 4, RoleType = RoleType.Student, FirstName = "Student2", UserName = "student2@example.com", NormalizedUserName = "STUDENT2@EXAMPLE.COM", Email = "student2@example.com", NormalizedEmail = "STUDENT2@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = new PasswordHasher<User>().HashPassword(null, "Student2Pass"), SecurityStamp = string.Empty },
                new User { Id = 5, RoleType = RoleType.Student, FirstName = "Student3", UserName = "student3@example.com", NormalizedUserName = "STUDENT3@EXAMPLE.COM", Email = "student3@example.com", NormalizedEmail = "STUDENT3@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = new PasswordHasher<User>().HashPassword(null, "Student3Pass"), SecurityStamp = string.Empty }
            );

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 },
                new IdentityUserRole<int> { UserId = 2, RoleId = 1 },
                new IdentityUserRole<int> { UserId = 3, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 4, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 5, RoleId = 2 }
            );

            builder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Student 1", LastName = "Student 1", Email = "student1@example.com", UserId = 3, GradeId = 2, DateOfBirth = new DateTime(2000, 12, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                new Student { Id = 2, FirstName = "Student 2", LastName = "Student 2", Email = "student2@example.com", UserId = 4, GradeId = 3, DateOfBirth = new DateTime(2001, 6, 7, 0, 0, 0, 0, DateTimeKind.Utc) },
                new Student { Id = 3, FirstName = "Student 3", LastName = "Student 3", Email = "student3@example.com", UserId = 5, GradeId = 3, DateOfBirth = new DateTime(2004, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc) }
            // Add up to 10 students
            );
        }
    }
}
