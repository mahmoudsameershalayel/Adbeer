using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adbeer.Data.Migrations
{
    /// <inheritdoc />
    public partial class addSchoolSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { 8, "f1446937-109c-4e1a-97ce-0560442484f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "eca12630-9590-42c5-b109-079d64ab7769", new DateTime(2023, 9, 2, 23, 43, 59, 606, DateTimeKind.Local).AddTicks(2353), "AQAAAAIAAYagAAAAEO2Ou/wPvK2VspqFCzEGCB7TmULRr8C6dhvpp9+hkprXH05MrJIjf9PGhQ+4Q2gopw==", "9a0cb047-032f-4dcb-96ac-b5183974e3d6", new DateTime(2023, 9, 2, 23, 43, 59, 606, DateTimeKind.Local).AddTicks(2406) });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Address", "AdministratorId", "AdministratorName", "City", "Country", "Created_At", "Created_By", "Email", "IsActive", "IsDelete", "MobileNumber", "Name", "Password", "SortId", "Updated_At", "Updated_By" },
                values: new object[] { 8, "test", 8, "System_Administrator", "Rafah", "Palestine", null, null, "Administrator@admin.com", null, null, "45626541851", "AdminSchool", "123456", null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "b3aab7f1-3349-4e49-96e0-a4dae98f8acc", new DateTime(2023, 9, 2, 23, 28, 1, 976, DateTimeKind.Local).AddTicks(8890), "AQAAAAIAAYagAAAAEC20c6QIxsW1XwBbqPC7pwG/5ZkV4etnjWfK7SfblrtSh6X5DrpxsEbIvy2p0zrReg==", "1589e29a-cf00-4837-a4e8-01c862b9b08d", new DateTime(2023, 9, 2, 23, 28, 1, 976, DateTimeKind.Local).AddTicks(8952) });
        }
    }
}
