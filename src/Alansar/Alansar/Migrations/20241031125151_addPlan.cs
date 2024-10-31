using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alansar.Migrations
{
    /// <inheritdoc />
    public partial class addPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FlutterwavePlanId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Interval = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "856746c7-d5b5-4a65-ba55-f9f462a34105", new DateTime(2024, 10, 31, 12, 51, 47, 871, DateTimeKind.Utc).AddTicks(5063), "AQAAAAIAAYagAAAAEPVKdugLsLX9YaCIoVoqD2OJpb7GsouYQ3poNoq3yjPe+BCezkT34cQ17k64r/2nmA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "00394af3-8dd0-454a-a29f-9c959a90f77d", new DateTime(2024, 10, 31, 12, 51, 48, 104, DateTimeKind.Utc).AddTicks(3185), "AQAAAAIAAYagAAAAEJ7L0Ckdl8PjkT8LfxpqHdQgMYy8ViDvo7wMMBhpHogsdQA9ZWt9p9PJpWvPigKMjA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "b8b5679e-6b38-4e80-9f2b-acedd1809766", new DateTime(2024, 10, 31, 12, 51, 48, 301, DateTimeKind.Utc).AddTicks(2890), "AQAAAAIAAYagAAAAEFzgRpZOCxY4/HbFHFFxn4/KRLKofBaLRakwlqztzOu/4XJd4Z+NoULSh64rVcAuhg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "3fa3d3b6-004c-4deb-9e91-f964a26b539f", new DateTime(2024, 10, 31, 12, 51, 48, 584, DateTimeKind.Utc).AddTicks(5572), "AQAAAAIAAYagAAAAEBA9yYKWiZu7Lxxih9LbI+/+8+Rhj1lDPbA/ESHYU08urpyKrkZQK/zSVLRlj1T4ew==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "28bd9d3f-8165-4463-a0a5-7a41039da05f", new DateTime(2024, 10, 31, 12, 51, 48, 841, DateTimeKind.Utc).AddTicks(4825), "AQAAAAIAAYagAAAAEKzMhgisnuumNWt0z0eMu6D4x+doqdMQXsaqBJ7l7YNESJmA4LzpTgOXG5lWfZIyKg==" });

            migrationBuilder.UpdateData(
                table: "DiningSpaces",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 31, 12, 51, 47, 871, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "DiningSpaces",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 31, 12, 51, 47, 871, DateTimeKind.Utc).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 31, 12, 51, 47, 871, DateTimeKind.Utc).AddTicks(4194));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 31, 12, 51, 47, 871, DateTimeKind.Utc).AddTicks(4202));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 31, 12, 51, 47, 871, DateTimeKind.Utc).AddTicks(4205));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 31, 12, 51, 47, 871, DateTimeKind.Utc).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 31, 12, 51, 47, 871, DateTimeKind.Utc).AddTicks(4597));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 31, 12, 51, 47, 871, DateTimeKind.Utc).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 10, 31, 12, 51, 47, 871, DateTimeKind.Utc).AddTicks(4608));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 10, 31, 12, 51, 47, 871, DateTimeKind.Utc).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 31, 12, 51, 47, 871, DateTimeKind.Utc).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 31, 12, 51, 47, 871, DateTimeKind.Utc).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 31, 12, 51, 49, 55, DateTimeKind.Utc).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 31, 12, 51, 49, 55, DateTimeKind.Utc).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 31, 12, 51, 49, 55, DateTimeKind.Utc).AddTicks(3704));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "9a2b8697-e989-47bc-a611-b9dd2a3ec9cc", new DateTime(2024, 10, 14, 15, 8, 35, 433, DateTimeKind.Utc).AddTicks(5540), "AQAAAAIAAYagAAAAENbtu5kxUtughTsi9EdPEB7UfEwqTXU1qLDdzlkhN5vxJJV0ce5wiLbc3c1nGVOTxA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "d84ba3ee-00b5-4ab5-9a4c-cc1ec8dcb6f5", new DateTime(2024, 10, 14, 15, 8, 35, 565, DateTimeKind.Utc).AddTicks(8658), "AQAAAAIAAYagAAAAEJCZiSGVmteinKX/kC1Qw7gtGdNb4km+gcN20qoP7lca+7Syu+HgYhhk8uArhNgzog==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "5f6976bf-e71e-40ab-9fc9-8a9c3c363d1d", new DateTime(2024, 10, 14, 15, 8, 35, 692, DateTimeKind.Utc).AddTicks(2457), "AQAAAAIAAYagAAAAEN1wv3m3vN4q0OAJ5rc9DEC1Rb5rXntu+eO1NAFaliHxOFemG6ESRkF/JJaSUAoAFA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "1829cb16-9fc4-4433-a637-a4984fba1571", new DateTime(2024, 10, 14, 15, 8, 35, 816, DateTimeKind.Utc).AddTicks(337), "AQAAAAIAAYagAAAAEByPUnGzoQ79sj0tjM7eHVyF/Jn1vmIlYXJEsl0eoM2Oi7maTkpUFVfKVQOejXGpVw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "6b4b33de-4641-4ba2-8247-da4f33d9c248", new DateTime(2024, 10, 14, 15, 8, 35, 934, DateTimeKind.Utc).AddTicks(8501), "AQAAAAIAAYagAAAAENHW2V3y3NEsyYztxOFNnv9PJJumKuMoJWSznJgC0TAtz1N4ZvKzDYLC04Tin4as0Q==" });

            migrationBuilder.UpdateData(
                table: "DiningSpaces",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 14, 15, 8, 35, 433, DateTimeKind.Utc).AddTicks(5313));

            migrationBuilder.UpdateData(
                table: "DiningSpaces",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 14, 15, 8, 35, 433, DateTimeKind.Utc).AddTicks(5316));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 14, 15, 8, 35, 433, DateTimeKind.Utc).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 14, 15, 8, 35, 433, DateTimeKind.Utc).AddTicks(5032));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 14, 15, 8, 35, 433, DateTimeKind.Utc).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 14, 15, 8, 35, 433, DateTimeKind.Utc).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 14, 15, 8, 35, 433, DateTimeKind.Utc).AddTicks(5256));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 14, 15, 8, 35, 433, DateTimeKind.Utc).AddTicks(5259));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 10, 14, 15, 8, 35, 433, DateTimeKind.Utc).AddTicks(5262));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 10, 14, 15, 8, 35, 433, DateTimeKind.Utc).AddTicks(5264));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 14, 15, 8, 35, 433, DateTimeKind.Utc).AddTicks(5362));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 14, 15, 8, 35, 433, DateTimeKind.Utc).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 14, 15, 8, 36, 54, DateTimeKind.Utc).AddTicks(8295));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 14, 15, 8, 36, 54, DateTimeKind.Utc).AddTicks(8313));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 14, 15, 8, 36, 54, DateTimeKind.Utc).AddTicks(8317));
        }
    }
}
