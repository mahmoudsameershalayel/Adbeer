using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adbeer.Data.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Administrators",
                newName: "AdministratorId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "e7b456d3-9d12-449d-8460-d13ed3437324", new DateTime(2023, 9, 2, 21, 9, 50, 674, DateTimeKind.Local).AddTicks(7500), "AQAAAAIAAYagAAAAEMulpj2MoMsoLTFFL2TUtaGcFrf7CE7xaApzAu4tLRmTsUQHab/2bBgY+PzxfCSyiA==", "103a5e3b-8ad8-4e14-a06b-d08e921c2c85", new DateTime(2023, 9, 2, 21, 9, 50, 674, DateTimeKind.Local).AddTicks(7562) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdministratorId",
                table: "Administrators",
                newName: "UserId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "1973b83d-7579-4c5d-9e8f-d3fdd38aa920", new DateTime(2023, 9, 2, 16, 28, 23, 348, DateTimeKind.Local).AddTicks(6802), "AQAAAAIAAYagAAAAEKLxA3Fxy1NaAEergwwuQGUVi49GJlbzvUMehqPP2s+loapyWPGNz10zJh+2H1lUNQ==", "7a7ff28c-af3a-4cbd-b445-e3463520bd9b", new DateTime(2023, 9, 2, 16, 28, 23, 348, DateTimeKind.Local).AddTicks(6842) });
        }
    }
}
