using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adbeer.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DriverId",
                table: "Drivers",
                newName: "ApplicaitonUserId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "b3aab7f1-3349-4e49-96e0-a4dae98f8acc", new DateTime(2023, 9, 2, 23, 28, 1, 976, DateTimeKind.Local).AddTicks(8890), "AQAAAAIAAYagAAAAEC20c6QIxsW1XwBbqPC7pwG/5ZkV4etnjWfK7SfblrtSh6X5DrpxsEbIvy2p0zrReg==", "1589e29a-cf00-4837-a4e8-01c862b9b08d", new DateTime(2023, 9, 2, 23, 28, 1, 976, DateTimeKind.Local).AddTicks(8952) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApplicaitonUserId",
                table: "Drivers",
                newName: "DriverId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "7ac4fac9-80cc-435f-a34b-c60a6a49538f", new DateTime(2023, 9, 2, 21, 13, 3, 314, DateTimeKind.Local).AddTicks(9157), "AQAAAAIAAYagAAAAECLYo8gzw+9DaxngxaNQ2dt41Z1viH3aPSXnxCogBqPmCKFTzxTwgyG+xtyQ+n5Zew==", "caabe557-19c6-4fa6-b3eb-214c47ee2dda", new DateTime(2023, 9, 2, 21, 13, 3, 314, DateTimeKind.Local).AddTicks(9212) });
        }
    }
}
