using Alansar.Core.Entities.Identity;
using Alansar.Core.Entities;
using Alansar.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace Alansar.Data
{
    public static class SeedData
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;

                // Seed Identity data (Roles, Users)
                var identityDbContext = services.GetRequiredService<IdentityDbContext>();
                await SeedIdentityData(identityDbContext);

                // Seed App data (Students, Rooms, Grades, etc.)
                var appDbContext = services.GetRequiredService<AppDbContext>();
                await SeedAppData(appDbContext);
            }
        }

        private static async Task SeedIdentityData(IdentityDbContext context)
        {

            // Seed Tenants
            if (!context.Tenants.Any())
            {
                context.Tenants.AddRange(
                    new Tenant { Id = 1, SchoolName = "Boyo", Email = "boyo@gmail.com" },
                    new Tenant { Id = 2, SchoolName = "Goyo", Email = "goyo@gmail.com" },
                    new Tenant { Id = 3, SchoolName = "Qoyo", Email = "qoyo@gmail.com" }
                );
                await context.SaveChangesAsync();
            }

            // Seed roles
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole<int> { Id = 2, Name = "Student", NormalizedName = "STUDENT" },
                    new IdentityRole<int> { Id = 3, Name = "TenantAdmin", NormalizedName = "TENANTADMIN" },
                    new IdentityRole<int> { Id = 4, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" }
                );
                await context.SaveChangesAsync();
            }

            // Seed users
            if (!context.Users.Any())
            {
                var passwordHasher = new PasswordHasher<User>();
                var users = new List<User>
                    {
                        new User { Id = 1, RoleType = RoleType.Admin, FirstName = "Admin1", UserName = "admin1@example.com", NormalizedUserName = "ADMIN1@EXAMPLE.COM", Email = "admin1@example.com", NormalizedEmail = "ADMIN1@EXAMPLE.COM", EmailConfirmed = true, SecurityStamp = GenerateSecurityStamp(), PasswordHash = passwordHasher.HashPassword(null, "Admin1Pass"), TenantKey = "1" },
                        new User { Id = 2, RoleType = RoleType.Admin, FirstName = "Admin2", UserName = "admin2@example.com", NormalizedUserName = "ADMIN2@EXAMPLE.COM", Email = "admin2@example.com", NormalizedEmail = "ADMIN2@EXAMPLE.COM", EmailConfirmed = true, SecurityStamp = GenerateSecurityStamp(),PasswordHash = passwordHasher.HashPassword(null, "Admin2Pass"), TenantKey = "1" },
                        new User { Id = 3, RoleType = RoleType.Student, FirstName = "Student1", UserName = "student1@example.com", NormalizedUserName = "STUDENT1@EXAMPLE.COM", Email = "student1@example.com", NormalizedEmail = "STUDENT1@EXAMPLE.COM", EmailConfirmed = true, SecurityStamp = GenerateSecurityStamp(),PasswordHash = passwordHasher.HashPassword(null, "Student1Pass"), TenantKey = "1" },
                        new User { Id = 4, RoleType = RoleType.Student, FirstName = "Student2", UserName = "student2@example.com", NormalizedUserName = "STUDENT2@EXAMPLE.COM", Email = "student2@example.com", NormalizedEmail = "STUDENT2@EXAMPLE.COM", EmailConfirmed = true, SecurityStamp = GenerateSecurityStamp(), PasswordHash = passwordHasher.HashPassword(null, "Student2Pass"), TenantKey = "1" },
                        new User { Id = 5, RoleType = RoleType.Student, FirstName = "Student3", UserName = "student3@example.com", NormalizedUserName = "STUDENT3@EXAMPLE.COM", Email = "student3@example.com", NormalizedEmail = "STUDENT3@EXAMPLE.COM", EmailConfirmed = true, SecurityStamp = GenerateSecurityStamp(), PasswordHash = passwordHasher.HashPassword(null, "Student3Pass"), TenantKey = "1" },
                        new User { Id = 6, RoleType = RoleType.SuperAdmin, FirstName = "Boss", UserName = "boss@example.com", NormalizedUserName = "BOSS@EXAMPLE.COM", Email = "boss@example.com", NormalizedEmail = "BOSS@EXAMPLE.COM", EmailConfirmed = true, SecurityStamp = GenerateSecurityStamp(),PasswordHash = passwordHasher.HashPassword(null, "Boss1Pass"), TenantKey = "" },
                    };
                context.Users.AddRange(users);
                await context.SaveChangesAsync();
            }

            // Seed user roles
            if (!context.UserRoles.Any())
            {
                context.UserRoles.AddRange(
                    new IdentityUserRole<int> { UserId = 1, RoleId = 1 },
                    new IdentityUserRole<int> { UserId = 2, RoleId = 1 },
                    new IdentityUserRole<int> { UserId = 3, RoleId = 2 },
                    new IdentityUserRole<int> { UserId = 4, RoleId = 2 },
                    new IdentityUserRole<int> { UserId = 5, RoleId = 2 }
                );
                await context.SaveChangesAsync();
            }
        }

        private static string GenerateSecurityStamp()
        {
            byte[] randomBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }

        private static async Task SeedAppData(AppDbContext context)
        {

            if (!context.Grades.Any())
            {
                context.Grades.AddRange(
                    new Grade { Id = 1, Name = "JSS1", TenantKey = "1" },
                    new Grade { Id = 2, Name = "JSS2", TenantKey = "1" },
                    new Grade { Id = 3, Name = "JSS3", TenantKey = "1" }
                );
                await context.SaveChangesAsync();
            }

            // Seed Rooms
            if (!context.Rooms.Any())
            {
                context.Rooms.AddRange(
                    new Room { Id = 1, RoomNumber = "101", Capacity = 24, Type = "Single", IsAvailable = true, Price = 2000, TenantKey = "1" },
                    new Room { Id = 2, RoomNumber = "102", Capacity = 20, Type = "Double", IsAvailable = true, Price = 3000, TenantKey = "1" },
                    new Room { Id = 3, RoomNumber = "103", Capacity = 54, Type = "Single", IsAvailable = false, Price = 6000, TenantKey = "1" },
                    new Room { Id = 4, RoomNumber = "104", Capacity = 5, Type = "Double", IsAvailable = true, Price = 9000, TenantKey = "1" },
                    new Room { Id = 5, RoomNumber = "105", Capacity = 32, Type = "Single", IsAvailable = false, Price = 4000, TenantKey = "1" }
                );
                await context.SaveChangesAsync();
            }

            // Seed Dining Spaces
            if (!context.DiningSpaces.Any())
            {
                context.DiningSpaces.AddRange(
                    new DiningSpace { Id = 1, Name = "Dining Hall 1", Capacity = 100, TenantKey = "1" },
                    new DiningSpace { Id = 2, Name = "Dining Hall 2", Capacity = 150, TenantKey = "1" }
                );
                await context.SaveChangesAsync();
            }

            // Seed Sessions
            if (!context.Sessions.Any())
            {
                context.Sessions.AddRange(
                    new Session { Id = 1, Year = "2022/2023", StartDate = DateTime.SpecifyKind(new DateTime(2022, 9, 16), DateTimeKind.Utc), EndDate = DateTime.SpecifyKind(new DateTime(2023, 9, 12), DateTimeKind.Utc), TenantKey = "1" },
                    new Session { Id = 2, Year = "2021/2022", StartDate = DateTime.SpecifyKind(new DateTime(2021, 9, 12), DateTimeKind.Utc), EndDate = DateTime.SpecifyKind(new DateTime(2022, 9, 12), DateTimeKind.Utc), TenantKey = "1" }
                );
                await context.SaveChangesAsync();
            }

            //// Seed users
            //if (!context.User.Any())
            //{
            //    var passwordHasher = new PasswordHasher<User>();
            //    var users = new List<User>
            //        {
            //            new User { Id = 1, RoleType = RoleType.Admin, FirstName = "Admin1", UserName = "admin1@example.com", NormalizedUserName = "ADMIN1@EXAMPLE.COM", Email = "admin1@example.com", NormalizedEmail = "ADMIN1@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = passwordHasher.HashPassword(null, "Admin1Pass"), TenantKey = "1" },
            //            new User { Id = 2, RoleType = RoleType.Admin, FirstName = "Admin2", UserName = "admin2@example.com", NormalizedUserName = "ADMIN2@EXAMPLE.COM", Email = "admin2@example.com", NormalizedEmail = "ADMIN2@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = passwordHasher.HashPassword(null, "Admin2Pass"), TenantKey = "1" },
            //            new User { Id = 3, RoleType = RoleType.Student, FirstName = "Student1", UserName = "student1@example.com", NormalizedUserName = "STUDENT1@EXAMPLE.COM", Email = "student1@example.com", NormalizedEmail = "STUDENT1@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = passwordHasher.HashPassword(null, "Student1Pass"), TenantKey = "1" },
            //            new User { Id = 4, RoleType = RoleType.Student, FirstName = "Student2", UserName = "student2@example.com", NormalizedUserName = "STUDENT2@EXAMPLE.COM", Email = "student2@example.com", NormalizedEmail = "STUDENT2@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = passwordHasher.HashPassword(null, "Student2Pass"), TenantKey = "1" },
            //            new User { Id = 5, RoleType = RoleType.Student, FirstName = "Student3", UserName = "student3@example.com", NormalizedUserName = "STUDENT3@EXAMPLE.COM", Email = "student3@example.com", NormalizedEmail = "STUDENT3@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = passwordHasher.HashPassword(null, "Student3Pass"), TenantKey = "1" },
            //            new User { Id = 6, RoleType = RoleType.SuperAdmin, FirstName = "Boss", UserName = "boss@example.com", NormalizedUserName = "BOSS@EXAMPLE.COM", Email = "boss@example.com", NormalizedEmail = "BOSS@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = passwordHasher.HashPassword(null, "Boss1Pass"), TenantKey = "" },
            //        };
            //    context.User.AddRange(users);
            //    await context.SaveChangesAsync();
            //}


            //// Seed Students
            //if (!context.Students.Any())
            //{
            //    context.Students.AddRange(
            //        new Student { Id = 1, FirstName = "Student 1", LastName = "Student 1", Email = "student1@example.com", UserId = 3, GradeId = 2, DateOfBirth = DateTime.SpecifyKind(new DateTime(2000, 12, 3), DateTimeKind.Utc), TenantKey = "1" },
            //        new Student { Id = 2, FirstName = "Student 2", LastName = "Student 2", Email = "student2@example.com", UserId = 4, GradeId = 3, DateOfBirth = DateTime.SpecifyKind(new DateTime(2001, 6, 7), DateTimeKind.Utc), TenantKey = "1" },
            //        new Student { Id = 3, FirstName = "Student 3", LastName = "Student 3", Email = "student3@example.com", UserId = 5, GradeId = 3, DateOfBirth = DateTime.SpecifyKind(new DateTime(2004, 4, 2), DateTimeKind.Utc), TenantKey = "1" }
            //    );
            //    await context.SaveChangesAsync();
            //}

        }
    }

}
