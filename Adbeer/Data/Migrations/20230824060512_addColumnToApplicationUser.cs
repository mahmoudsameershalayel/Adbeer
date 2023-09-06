using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adbeer.Data.Migrations
{
    /// <inheritdoc />
    public partial class addColumnToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at", "UserType" },
                values: new object[] { "2aaf17ed-5a62-44bb-b02d-40a15c038635", new DateTime(2023, 8, 24, 9, 5, 12, 60, DateTimeKind.Local).AddTicks(7978), "AQAAAAIAAYagAAAAEHPosmWte8IuButBtFq0j5c7fT4tOljDtqEQl4ak0zU4Cz2D3bCO2KrGDhrYChwZeQ==", "8ca1df70-4fff-40d2-980e-afca483bb05c", new DateTime(2023, 8, 24, 9, 5, 12, 60, DateTimeKind.Local).AddTicks(8043), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "9dc547c7-51b4-43cf-8b03-e60c9fdade3b", new DateTime(2023, 8, 24, 2, 21, 13, 607, DateTimeKind.Local).AddTicks(3947), "AQAAAAIAAYagAAAAEDmRPqUVKWHErn82HrovjOBvxanRUR/h8pZShD2ndvZvEijOueu90Y/z5Xb0WUFfjg==", "2627c222-f22c-4430-b798-d9d68dc87f10", new DateTime(2023, 8, 24, 2, 21, 13, 607, DateTimeKind.Local).AddTicks(3990) });
        }
    }
}
