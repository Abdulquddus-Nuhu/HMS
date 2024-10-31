using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alansar.Migrations
{
    /// <inheritdoc />
    public partial class editPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Plans",
                newName: "Status");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "2f9756ba-da92-4359-a953-c0929966f421", new DateTime(2024, 10, 31, 13, 41, 15, 149, DateTimeKind.Utc).AddTicks(2808), "AQAAAAIAAYagAAAAENtBKxdCDV8vTNxRyvImHoE4ClinxysCLFRv+Yh3IVqodxDAGas9OgB1FMMY+qpC3g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "32a9f266-d1c8-400b-90f7-0b6553b3bea8", new DateTime(2024, 10, 31, 13, 41, 15, 296, DateTimeKind.Utc).AddTicks(3325), "AQAAAAIAAYagAAAAELDxTLB9QUkoMfq4ggwSYO/ktFsZFUI35UDrKety9Q33tIhloUk4Li7h8mMbIpvWTg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "405a069f-a6ae-44f9-b851-cce8c6e33253", new DateTime(2024, 10, 31, 13, 41, 15, 413, DateTimeKind.Utc).AddTicks(4842), "AQAAAAIAAYagAAAAEFuhbNn1i6Q665OqfH5e4byOva4xEPJrDD+RSOXqFquxdfkDGTAB69n9vvBSGROw3Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "2605c46b-8bec-4763-9498-d92ba9442f58", new DateTime(2024, 10, 31, 13, 41, 15, 559, DateTimeKind.Utc).AddTicks(1116), "AQAAAAIAAYagAAAAED2BtodIwjH2Hc6zZGNSlAKh8LRBSrOnWQmDAF5HtXuNwpuucLvApMYx6HmuWhOw+g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "33925f7d-c095-46d2-a0bd-8aabc6b1a1c7", new DateTime(2024, 10, 31, 13, 41, 15, 677, DateTimeKind.Utc).AddTicks(9440), "AQAAAAIAAYagAAAAEJBFxIdNYUlaTQWBaCBD8pRKrcprAiJjMfdYsnSuQ65oM8mqaounpN0Dq9xV7zUNUw==" });

            migrationBuilder.UpdateData(
                table: "DiningSpaces",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 31, 13, 41, 15, 149, DateTimeKind.Utc).AddTicks(2408));

            migrationBuilder.UpdateData(
                table: "DiningSpaces",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 31, 13, 41, 15, 149, DateTimeKind.Utc).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 31, 13, 41, 15, 149, DateTimeKind.Utc).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 31, 13, 41, 15, 149, DateTimeKind.Utc).AddTicks(1895));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 31, 13, 41, 15, 149, DateTimeKind.Utc).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 31, 13, 41, 15, 149, DateTimeKind.Utc).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 31, 13, 41, 15, 149, DateTimeKind.Utc).AddTicks(2322));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 31, 13, 41, 15, 149, DateTimeKind.Utc).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 10, 31, 13, 41, 15, 149, DateTimeKind.Utc).AddTicks(2331));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 10, 31, 13, 41, 15, 149, DateTimeKind.Utc).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 31, 13, 41, 15, 149, DateTimeKind.Utc).AddTicks(2475));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 31, 13, 41, 15, 149, DateTimeKind.Utc).AddTicks(2495));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 31, 13, 41, 15, 802, DateTimeKind.Utc).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 31, 13, 41, 15, 802, DateTimeKind.Utc).AddTicks(3378));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 31, 13, 41, 15, 802, DateTimeKind.Utc).AddTicks(3401));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Plans",
                newName: "status");

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
    }
}
