using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adbeer.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "Created_At", "Gender", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "f53621fd-a1dd-4ea2-9077-18777cb7b9f2", new DateTime(2023, 8, 22, 12, 30, 25, 111, DateTimeKind.Local).AddTicks(9101), null, "AQAAAAIAAYagAAAAEEzA8af+gvu9OzZPwYWp5zkdJ8X8EcdQM4VDzoKu70JWgegrFTmuUNke/b4Gntmx6g==", "960889e5-d23f-4f97-bd2e-19dc784bcb7e", new DateTime(2023, 8, 22, 12, 30, 25, 111, DateTimeKind.Local).AddTicks(9156) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Grade",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Section",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "Age", "ConcurrencyStamp", "Created_At", "Gender", "Grade", "PasswordHash", "Section", "SecurityStamp", "Updated_at" },
                values: new object[] { 0, "e222ae11-e93d-407a-8a3f-0855a19eaf45", new DateTime(2023, 8, 16, 9, 29, 29, 743, DateTimeKind.Local).AddTicks(61), 0, 0.0, "AQAAAAIAAYagAAAAEFuV7K+ztY3906Yz7KHpIzxwfvUie9LZNeukpqNLqzm7VqtoXPypsC1v8486WGheDg==", 0, "2ecd4194-ec7c-4994-b071-05a722c0f838", new DateTime(2023, 8, 16, 9, 29, 29, 743, DateTimeKind.Local).AddTicks(116) });
        }
    }
}
