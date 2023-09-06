using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adbeer.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeDriverTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Drivers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "0d3c78bb-e196-43b0-8353-3296bb50ec81", new DateTime(2023, 8, 24, 10, 3, 58, 938, DateTimeKind.Local).AddTicks(2381), "AQAAAAIAAYagAAAAEJNl3t7BFBfF6uYNAWlgeFrFhQz+/pEouWC7X/rtKuS38QxCB7j7PylAFo5s5zETVg==", "8d00e0ba-4f05-4f77-b69f-40fdf22ce6e1", new DateTime(2023, 8, 24, 10, 3, 58, 938, DateTimeKind.Local).AddTicks(2461) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DriverId",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "33d67a11-5ea4-4ca4-a55c-a9b17d535fe9", new DateTime(2023, 8, 24, 9, 58, 48, 739, DateTimeKind.Local).AddTicks(4392), "AQAAAAIAAYagAAAAELu44Oi+gJwfZQOgkGeAbftC2fjpkWqs3ZU7iwUn4MuIY8P2qPOjCtbpBHaGIKQuOw==", "2f3437ef-5518-4fb1-a391-4e56446a338f", new DateTime(2023, 8, 24, 9, 58, 48, 739, DateTimeKind.Local).AddTicks(4514) });
        }
    }
}
