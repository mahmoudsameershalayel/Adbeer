using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adbeer.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6472ca7d-4acb-4550-9b9f-2d03321ad5e6", "6472ca7d-4acb-4550-9b9f-2d03321ad5e6", "Driver", "DRIVER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "e025229a-d666-434e-8037-4ddbeda23207", new DateTime(2023, 8, 22, 13, 39, 52, 959, DateTimeKind.Local).AddTicks(9068), "AQAAAAIAAYagAAAAEHqWDOFO64lMCrivm36LxDScbxj6mtMSS3VKBNOx6Rjgv1+A+DCOvdHTPMbm/Ej5Rw==", "a428906b-4e7c-481b-8c0e-b4ee661fc987", new DateTime(2023, 8, 22, 13, 39, 52, 959, DateTimeKind.Local).AddTicks(9113) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6472ca7d-4acb-4550-9b9f-2d03321ad5e6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "f53621fd-a1dd-4ea2-9077-18777cb7b9f2", new DateTime(2023, 8, 22, 12, 30, 25, 111, DateTimeKind.Local).AddTicks(9101), "AQAAAAIAAYagAAAAEEzA8af+gvu9OzZPwYWp5zkdJ8X8EcdQM4VDzoKu70JWgegrFTmuUNke/b4Gntmx6g==", "960889e5-d23f-4f97-bd2e-19dc784bcb7e", new DateTime(2023, 8, 22, 12, 30, 25, 111, DateTimeKind.Local).AddTicks(9156) });
        }
    }
}
