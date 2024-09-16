﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Alansar.Enums;
using Alansar.Entities;
using Alansar.Entities.Identity;
using Microsoft.AspNetCore.Http;

namespace Alansar.Data
{
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
        public DbSet<Class> Classes => Set<Class>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Student>(s => s.UserId);

            // Seed default data
            builder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Student 1", LastName = "Student 1", Email = "student1@example.com", UserId = 3 },
                new Student { Id = 2, FirstName = "Student 2", LastName = "Student 2", Email = "student2@example.com", UserId = 4 }
                // Add up to 10 students
            );

            builder.Entity<Room>().HasData(
                new Room { Id = 1, RoomNumber = "101", Type = "Single", IsAvailable = true, Price = 2000 },
                new Room { Id = 2, RoomNumber = "102", Type = "Double", IsAvailable = true, Price = 3000 },
                new Room { Id = 3, RoomNumber = "103", Type = "Single", IsAvailable = false, Price = 6000 },
                new Room { Id = 4, RoomNumber = "104", Type = "Double", IsAvailable = true, Price = 9000 },
                new Room { Id = 5, RoomNumber = "105", Type = "Single", IsAvailable = false, Price = 4000 }
                // Add up to 10 rooms
            );

            builder.Entity<DiningSpace>().HasData(
                new DiningSpace { Id = 1, Name = "Dining Hall 1", Capacity = 100 },
                new DiningSpace { Id = 2, Name = "Dining Hall 2", Capacity = 150 }
                // Add up to 5 dining spaces
            );

            // Seed roles
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int> { Id = 2, Name = "Student", NormalizedName = "STUDENT" }
            );

            // Seed default admin users
            builder.Entity<User>().HasData(
                new User { Id = 1, RoleType = RoleType.Admin, FirstName = "Admin1", UserName = "admin1@example.com", NormalizedUserName = "ADMIN1@EXAMPLE.COM", Email = "admin1@example.com", NormalizedEmail = "ADMIN1@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = new PasswordHasher<User>().HashPassword(null, "Admin1Pass"), SecurityStamp = string.Empty },
                new User { Id = 2, RoleType = RoleType.Admin, FirstName = "Admin2", UserName = "admin2@example.com", NormalizedUserName = "ADMIN2@EXAMPLE.COM", Email = "admin2@example.com", NormalizedEmail = "ADMIN2@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = new PasswordHasher<User>().HashPassword(null, "Admin2Pass"), SecurityStamp = string.Empty },
                new User { Id = 3, RoleType = RoleType.Student, FirstName= "Student1", UserName = "student1@example.com", NormalizedUserName = "STUDENT1@EXAMPLE.COM", Email = "student1@example.com", NormalizedEmail = "STUDENT1@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = new PasswordHasher<User>().HashPassword(null, "Student1Pass"), SecurityStamp = string.Empty },
                new User { Id = 4, RoleType = RoleType.Student, FirstName = "Student2", UserName = "student2@example.com", NormalizedUserName = "STUDENT2@EXAMPLE.COM", Email = "student2@example.com", NormalizedEmail = "STUDENT2@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = new PasswordHasher<User>().HashPassword(null, "Student2Pass"), SecurityStamp = string.Empty }
            );

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 },
                new IdentityUserRole<int> { UserId = 2, RoleId = 1 },
                new IdentityUserRole<int> { UserId = 3, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 4, RoleId = 2 }
            );
        }
    }
}
