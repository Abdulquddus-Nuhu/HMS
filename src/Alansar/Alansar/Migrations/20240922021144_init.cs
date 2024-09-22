using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Alansar.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    RoleType = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TenantKey = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiningSpaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TenantKey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiningSpaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TenantKey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomNumber = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    SessionYear = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TenantKey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Year = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TenantKey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    SchoolName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    GradeId = table.Column<int>(type: "integer", nullable: true),
                    RoomId = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TenantKey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TenantSubscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>(type: "integer", nullable: false),
                    PlanType = table.Column<int>(type: "integer", nullable: false),
                    BillingCycle = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HasPaid = table.Column<bool>(type: "boolean", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    FeeAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TenantKey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantSubscriptions_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SessionYear = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TenantKey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiningAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    DiningSpaceId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TenantKey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiningAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiningAssignments_DiningSpaces_DiningSpaceId",
                        column: x => x.DiningSpaceId,
                        principalTable: "DiningSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiningAssignments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiningSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiningSpaceId = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TenantKey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiningSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiningSchedules_DiningSpaces_DiningSpaceId",
                        column: x => x.DiningSpaceId,
                        principalTable: "DiningSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiningSchedules_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Student", "STUDENT" },
                    { 3, null, "TenantAdmin", "TENANTADMIN" },
                    { 4, null, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "CreatedBy", "Deleted", "DeletedBy", "Email", "EmailConfirmed", "FirstName", "IsActive", "IsDeleted", "LastModifiedBy", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "Modified", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleType", "SecurityStamp", "TenantKey", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "36f23991-a631-4f14-92ff-6ed971dbf270", new DateTime(2024, 9, 22, 2, 11, 41, 746, DateTimeKind.Utc).AddTicks(1808), "", null, "", "admin1@example.com", true, "Admin1", false, false, null, "", false, null, "", null, "ADMIN1@EXAMPLE.COM", "ADMIN1@EXAMPLE.COM", "AQAAAAIAAYagAAAAEN9PxgXpl+OrpnPyoE9k9e3ZDsP7/b/DzhxGKlVeinhta8pjuE0ZHLJS5+nB5FhZgQ==", null, false, 0, "", "1", false, "admin1@example.com" },
                    { 2, 0, "7801d48f-2237-450f-8372-df93d97e2910", new DateTime(2024, 9, 22, 2, 11, 41, 928, DateTimeKind.Utc).AddTicks(1687), "", null, "", "admin2@example.com", true, "Admin2", false, false, null, "", false, null, "", null, "ADMIN2@EXAMPLE.COM", "ADMIN2@EXAMPLE.COM", "AQAAAAIAAYagAAAAEGw/QFyCW/O9WKSn1CDn6GKYXHG0EN1aKz/EgmaYKFTaP0Ww0U/5TGqNlea8CADvFQ==", null, false, 0, "", "1", false, "admin2@example.com" },
                    { 3, 0, "588fafae-4b2c-4e65-839f-6bdaceb489ad", new DateTime(2024, 9, 22, 2, 11, 42, 101, DateTimeKind.Utc).AddTicks(4135), "", null, "", "student1@example.com", true, "Student1", false, false, null, "", false, null, "", null, "STUDENT1@EXAMPLE.COM", "STUDENT1@EXAMPLE.COM", "AQAAAAIAAYagAAAAEBXgVZBk2JUFfcowAEAPeutIhFO/CSriv/8m83K97qcWgJuovycV4tzZDcWebPSR5w==", null, false, 1, "", "1", false, "student1@example.com" },
                    { 4, 0, "c11789c3-46bb-44e1-a9ce-03f171b63be5", new DateTime(2024, 9, 22, 2, 11, 42, 290, DateTimeKind.Utc).AddTicks(1965), "", null, "", "student2@example.com", true, "Student2", false, false, null, "", false, null, "", null, "STUDENT2@EXAMPLE.COM", "STUDENT2@EXAMPLE.COM", "AQAAAAIAAYagAAAAEKg+oK5USrtAmIC5WsLWuq13B5hJ5rNnIk43CZ3Pu0Xc769F2YVX6WYwVDeS1C6uJg==", null, false, 1, "", "1", false, "student2@example.com" },
                    { 5, 0, "68a2aab6-d6d2-4a08-aa6b-c49287b73d81", new DateTime(2024, 9, 22, 2, 11, 42, 452, DateTimeKind.Utc).AddTicks(8250), "", null, "", "student3@example.com", true, "Student3", false, false, null, "", false, null, "", null, "STUDENT3@EXAMPLE.COM", "STUDENT3@EXAMPLE.COM", "AQAAAAIAAYagAAAAEKMNfEmsccVAmBCv5NhP0KfgMCX2Cg7PSVTmqLKcjbo44GxL2PWcn908n4qDO5NeZw==", null, false, 1, "", "1", false, "student3@example.com" },
                    { 6, 0, "936be39d-e3dc-44a4-bdf4-26d8c6a800c0", new DateTime(2024, 9, 22, 2, 11, 41, 592, DateTimeKind.Utc).AddTicks(3317), "", null, "", "boss@example.com", true, "Boss", false, false, null, "", false, null, "", null, "BOSS@EXAMPLE.COM", "BOSS@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPS0FKFp0SMHUTT44GlNy2tfKmrgwIEYr4yD2s6wjscO/2AHTdjMdj9SHLHiPLUZ9w==", null, false, 3, "", "", false, "boss@example.com" }
                });

            migrationBuilder.InsertData(
                table: "DiningSpaces",
                columns: new[] { "Id", "Capacity", "Created", "CreatedBy", "Deleted", "DeletedBy", "IsActive", "IsDeleted", "LastModifiedBy", "Modified", "Name", "TenantKey" },
                values: new object[,]
                {
                    { 1, 100, new DateTime(2024, 9, 22, 2, 11, 41, 592, DateTimeKind.Utc).AddTicks(2932), "", null, "", false, false, null, null, "Dining Hall 1", "1" },
                    { 2, 150, new DateTime(2024, 9, 22, 2, 11, 41, 592, DateTimeKind.Utc).AddTicks(2937), "", null, "", false, false, null, null, "Dining Hall 2", "1" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "DeletedBy", "IsActive", "IsDeleted", "LastModifiedBy", "Modified", "Name", "TenantKey" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 22, 2, 11, 41, 592, DateTimeKind.Utc).AddTicks(2479), "", null, "", false, false, null, null, "JSS1", "1" },
                    { 2, new DateTime(2024, 9, 22, 2, 11, 41, 592, DateTimeKind.Utc).AddTicks(2488), "", null, "", false, false, null, null, "JSS2", "1" },
                    { 3, new DateTime(2024, 9, 22, 2, 11, 41, 592, DateTimeKind.Utc).AddTicks(2491), "", null, "", false, false, null, null, "JSS3", "1" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Created", "CreatedBy", "Deleted", "DeletedBy", "IsActive", "IsAvailable", "IsDeleted", "LastModifiedBy", "Modified", "Price", "RoomNumber", "SessionYear", "TenantKey", "Type" },
                values: new object[,]
                {
                    { 1, 24, new DateTime(2024, 9, 22, 2, 11, 41, 592, DateTimeKind.Utc).AddTicks(2835), "", null, "", false, true, false, null, null, 2000m, "101", null, "1", "Single" },
                    { 2, 20, new DateTime(2024, 9, 22, 2, 11, 41, 592, DateTimeKind.Utc).AddTicks(2849), "", null, "", false, true, false, null, null, 3000m, "102", null, "1", "Double" },
                    { 3, 54, new DateTime(2024, 9, 22, 2, 11, 41, 592, DateTimeKind.Utc).AddTicks(2853), "", null, "", false, false, false, null, null, 6000m, "103", null, "1", "Single" },
                    { 4, 5, new DateTime(2024, 9, 22, 2, 11, 41, 592, DateTimeKind.Utc).AddTicks(2856), "", null, "", false, true, false, null, null, 9000m, "104", null, "1", "Double" },
                    { 5, 32, new DateTime(2024, 9, 22, 2, 11, 41, 592, DateTimeKind.Utc).AddTicks(2860), "", null, "", false, false, false, null, null, 4000m, "105", null, "1", "Single" }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "DeletedBy", "EndDate", "IsActive", "IsDeleted", "LastModifiedBy", "Modified", "StartDate", "TenantKey", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 22, 2, 11, 41, 592, DateTimeKind.Utc).AddTicks(3079), "", null, "", new DateTime(2023, 9, 12, 21, 46, 17, 608, DateTimeKind.Utc), false, false, null, null, new DateTime(2022, 9, 16, 21, 46, 17, 608, DateTimeKind.Utc), "1", "2022/2023" },
                    { 2, new DateTime(2024, 9, 22, 2, 11, 41, 592, DateTimeKind.Utc).AddTicks(3091), "", null, "", new DateTime(2022, 9, 12, 21, 46, 17, 608, DateTimeKind.Utc), false, false, null, null, new DateTime(2021, 9, 12, 21, 46, 17, 608, DateTimeKind.Utc), "1", "2021/2022" }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "DeletedBy", "Email", "IsActive", "IsDeleted", "LastModifiedBy", "Modified", "SchoolName" },
                values: new object[] { 1, new DateTime(2024, 9, 22, 2, 11, 41, 592, DateTimeKind.Utc).AddTicks(3010), "", null, "", "admin@admin.com", false, false, null, null, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Created", "CreatedBy", "DateOfBirth", "Deleted", "DeletedBy", "Email", "FirstName", "GradeId", "IsActive", "IsDeleted", "LastModifiedBy", "LastName", "MiddleName", "Modified", "Password", "RoomId", "TenantKey", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 22, 2, 11, 42, 614, DateTimeKind.Utc).AddTicks(6412), "", new DateTime(2000, 12, 3, 0, 0, 0, 0, DateTimeKind.Utc), null, "", "student1@example.com", "Student 1", 2, false, false, null, "Student 1", "", null, null, null, "1", 3 },
                    { 2, new DateTime(2024, 9, 22, 2, 11, 42, 614, DateTimeKind.Utc).AddTicks(6433), "", new DateTime(2001, 6, 7, 0, 0, 0, 0, DateTimeKind.Utc), null, "", "student2@example.com", "Student 2", 3, false, false, null, "Student 2", "", null, null, null, "1", 4 },
                    { 3, new DateTime(2024, 9, 22, 2, 11, 42, 614, DateTimeKind.Utc).AddTicks(6438), "", new DateTime(2004, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc), null, "", "student3@example.com", "Student 3", 3, false, false, null, "Student 3", "", null, null, null, "1", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_StudentId",
                table: "Bookings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DiningAssignments_DiningSpaceId",
                table: "DiningAssignments",
                column: "DiningSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_DiningAssignments_StudentId",
                table: "DiningAssignments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DiningSchedules_DiningSpaceId",
                table: "DiningSchedules",
                column: "DiningSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_DiningSchedules_StudentId",
                table: "DiningSchedules",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradeId",
                table: "Students",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RoomId",
                table: "Students",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TenantSubscriptions_TenantId",
                table: "TenantSubscriptions",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "DiningAssignments");

            migrationBuilder.DropTable(
                name: "DiningSchedules");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "TenantSubscriptions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DiningSpaces");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
