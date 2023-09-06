using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adbeer.Data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrators_Schools_SchoolId",
                table: "Administrators");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Buses_BusId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_BusId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Administrators_SchoolId",
                table: "Administrators");

            migrationBuilder.DropColumn(
                name: "BusId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Administrators");

            migrationBuilder.RenameColumn(
                name: "AdministratorId",
                table: "Administrators",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "AdministratorId",
                table: "Schools",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                values: new object[] { "1973b83d-7579-4c5d-9e8f-d3fdd38aa920", new DateTime(2023, 9, 2, 16, 28, 23, 348, DateTimeKind.Local).AddTicks(6802), "AQAAAAIAAYagAAAAEKLxA3Fxy1NaAEergwwuQGUVi49GJlbzvUMehqPP2s+loapyWPGNz10zJh+2H1lUNQ==", "7a7ff28c-af3a-4cbd-b445-e3463520bd9b", new DateTime(2023, 9, 2, 16, 28, 23, 348, DateTimeKind.Local).AddTicks(6842) });

            migrationBuilder.CreateIndex(
                name: "IX_Schools_AdministratorId",
                table: "Schools",
                column: "AdministratorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buses_DriverId",
                table: "Buses",
                column: "DriverId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "test",
                table: "Buses",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "test1",
                table: "Schools",
                column: "AdministratorId",
                principalTable: "Administrators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "test",
                table: "Buses");

            migrationBuilder.DropForeignKey(
                name: "test1",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_AdministratorId",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Buses_DriverId",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Drivers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Administrators",
                newName: "AdministratorId");

            migrationBuilder.AlterColumn<string>(
                name: "AdministratorId",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BusId",
                table: "Drivers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Administrators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "0d3c78bb-e196-43b0-8353-3296bb50ec81", new DateTime(2023, 8, 24, 10, 3, 58, 938, DateTimeKind.Local).AddTicks(2381), "AQAAAAIAAYagAAAAEJNl3t7BFBfF6uYNAWlgeFrFhQz+/pEouWC7X/rtKuS38QxCB7j7PylAFo5s5zETVg==", "8d00e0ba-4f05-4f77-b69f-40fdf22ce6e1", new DateTime(2023, 8, 24, 10, 3, 58, 938, DateTimeKind.Local).AddTicks(2461) });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_BusId",
                table: "Drivers",
                column: "BusId",
                unique: true,
                filter: "[BusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_SchoolId",
                table: "Administrators",
                column: "SchoolId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Administrators_Schools_SchoolId",
                table: "Administrators",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Buses_BusId",
                table: "Drivers",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id");
        }
    }
}
