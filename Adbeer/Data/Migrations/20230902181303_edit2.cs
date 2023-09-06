using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adbeer.Data.Migrations
{
    /// <inheritdoc />
    public partial class edit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdministratorId",
                table: "Administrators");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "7ac4fac9-80cc-435f-a34b-c60a6a49538f", new DateTime(2023, 9, 2, 21, 13, 3, 314, DateTimeKind.Local).AddTicks(9157), "AQAAAAIAAYagAAAAECLYo8gzw+9DaxngxaNQ2dt41Z1viH3aPSXnxCogBqPmCKFTzxTwgyG+xtyQ+n5Zew==", "caabe557-19c6-4fa6-b3eb-214c47ee2dda", new DateTime(2023, 9, 2, 21, 13, 3, 314, DateTimeKind.Local).AddTicks(9212) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdministratorId",
                table: "Administrators",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "e7b456d3-9d12-449d-8460-d13ed3437324", new DateTime(2023, 9, 2, 21, 9, 50, 674, DateTimeKind.Local).AddTicks(7500), "AQAAAAIAAYagAAAAEMulpj2MoMsoLTFFL2TUtaGcFrf7CE7xaApzAu4tLRmTsUQHab/2bBgY+PzxfCSyiA==", "103a5e3b-8ad8-4e14-a06b-d08e921c2c85", new DateTime(2023, 9, 2, 21, 9, 50, 674, DateTimeKind.Local).AddTicks(7562) });
        }
    }
}
