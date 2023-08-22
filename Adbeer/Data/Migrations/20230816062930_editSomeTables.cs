using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adbeer.Data.Migrations
{
    /// <inheritdoc />
    public partial class editSomeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Schools",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Created_By",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Schools",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Schools",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SortId",
                table: "Schools",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_At",
                table: "Schools",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Updated_By",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Buses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Created_By",
                table: "Buses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Buses",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Buses",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SortId",
                table: "Buses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_At",
                table: "Buses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Updated_By",
                table: "Buses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "ImageName", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "e222ae11-e93d-407a-8a3f-0855a19eaf45", new DateTime(2023, 8, 16, 9, 29, 29, 743, DateTimeKind.Local).AddTicks(61), "", "AQAAAAIAAYagAAAAEFuV7K+ztY3906Yz7KHpIzxwfvUie9LZNeukpqNLqzm7VqtoXPypsC1v8486WGheDg==", "2ecd4194-ec7c-4994-b071-05a722c0f838", new DateTime(2023, 8, 16, 9, 29, 29, 743, DateTimeKind.Local).AddTicks(116) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Created_By",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "SortId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Updated_At",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Updated_By",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "Created_By",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "SortId",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "Updated_At",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "Updated_By",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "932ddb82-ea13-465e-b5f5-c363bea7cf57", new DateTime(2023, 7, 28, 2, 19, 44, 616, DateTimeKind.Local).AddTicks(1229), "AQAAAAIAAYagAAAAEKyEqU/y4FQ8h5oOYmz41D3PAK9jhTVspkUIlopjASGG9JPJDy+E5N2xfQ/YTvQvFg==", "9ef4cb19-8de4-49f0-8155-3f94d086defc", new DateTime(2023, 7, 28, 2, 19, 44, 616, DateTimeKind.Local).AddTicks(1300) });
        }
    }
}
