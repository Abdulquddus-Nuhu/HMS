using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alansar.Migrations
{
    /// <inheritdoc />
    public partial class editPlan2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Plans",
                type: "text",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "6fe2d5ca-dcba-42bd-bb6a-9e7d692e0b5d", new DateTime(2024, 11, 1, 20, 48, 59, 167, DateTimeKind.Utc).AddTicks(2696), "AQAAAAIAAYagAAAAEPh3zBKA6ESnHkBc7RzAcalOTYEp4niL6Lz8+y/IbLIebmoIDpFJIzCpdR1eS4lXFA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "2ca4be27-b47e-463a-a551-00bc9dc4395e", new DateTime(2024, 11, 1, 20, 48, 59, 347, DateTimeKind.Utc).AddTicks(6255), "AQAAAAIAAYagAAAAECLjtpsvy8RVgs4o/m3t7G2l+kFozqNT5rLCftkreWdnvmrWRzGRSa0Wz/Ow+1+3VA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "8d358f21-6e77-464c-b95b-73385ff73d05", new DateTime(2024, 11, 1, 20, 48, 59, 530, DateTimeKind.Utc).AddTicks(33), "AQAAAAIAAYagAAAAEDQBRhblHDL7vXdOli2k99Af5CKoDIdTc9gj3OvplIyT+KS7qGzP+dSOftA0jJt0VA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "0482180c-06d4-4050-9d63-a2e5125aae79", new DateTime(2024, 11, 1, 20, 48, 59, 675, DateTimeKind.Utc).AddTicks(2129), "AQAAAAIAAYagAAAAEM8DAvdhU//AM5DXlXbJCn4i4ihSK9afOEakwIFVJWYHK9M61KLmMqdlGM2mbsWeZQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash" },
                values: new object[] { "198750a4-a6a9-412f-93fe-f25b5e691ba7", new DateTime(2024, 11, 1, 20, 48, 59, 891, DateTimeKind.Utc).AddTicks(9453), "AQAAAAIAAYagAAAAEGJQmyIe6gJb1WPIEwEVI3GgpDCK9UQdaLk0+BDTIyR4Jh4oIsNeYBizp3air7oxVQ==" });

            migrationBuilder.UpdateData(
                table: "DiningSpaces",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 1, 20, 48, 59, 167, DateTimeKind.Utc).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "DiningSpaces",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 1, 20, 48, 59, 167, DateTimeKind.Utc).AddTicks(2406));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 1, 20, 48, 59, 167, DateTimeKind.Utc).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 1, 20, 48, 59, 167, DateTimeKind.Utc).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 1, 20, 48, 59, 167, DateTimeKind.Utc).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 1, 20, 48, 59, 167, DateTimeKind.Utc).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 1, 20, 48, 59, 167, DateTimeKind.Utc).AddTicks(2159));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 1, 20, 48, 59, 167, DateTimeKind.Utc).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 1, 20, 48, 59, 167, DateTimeKind.Utc).AddTicks(2168));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 11, 1, 20, 48, 59, 167, DateTimeKind.Utc).AddTicks(2173));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 1, 20, 48, 59, 167, DateTimeKind.Utc).AddTicks(2471));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 1, 20, 48, 59, 167, DateTimeKind.Utc).AddTicks(2488));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 1, 20, 49, 0, 7, DateTimeKind.Utc).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 1, 20, 49, 0, 7, DateTimeKind.Utc).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 1, 20, 49, 0, 7, DateTimeKind.Utc).AddTicks(2185));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Plans",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

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
    }
}
