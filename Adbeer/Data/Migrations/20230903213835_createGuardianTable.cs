using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adbeer.Data.Migrations
{
    /// <inheritdoc />
    public partial class createGuardianTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "GuardianId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Guardian",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardian", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "bcff8fe0-453b-47ee-b719-7eea7bc6ce67", new DateTime(2023, 9, 4, 0, 38, 34, 549, DateTimeKind.Local).AddTicks(6863), "AQAAAAIAAYagAAAAEB3ugvf7cHWVk8y5NFrU7RT93/M0ydmE4uuP4JyRMr64QDAbFih7dW39c+SZJTvCUQ==", "243a0f15-bf70-40ed-9a25-293628be8862", new DateTime(2023, 9, 4, 0, 38, 34, 549, DateTimeKind.Local).AddTicks(6944) });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GuardianId",
                table: "Students",
                column: "GuardianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Guardian_GuardianId",
                table: "Students",
                column: "GuardianId",
                principalTable: "Guardian",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Guardian_GuardianId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Guardian");

            migrationBuilder.DropIndex(
                name: "IX_Students_GuardianId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GuardianId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "eca12630-9590-42c5-b109-079d64ab7769", new DateTime(2023, 9, 2, 23, 43, 59, 606, DateTimeKind.Local).AddTicks(2353), "AQAAAAIAAYagAAAAEO2Ou/wPvK2VspqFCzEGCB7TmULRr8C6dhvpp9+hkprXH05MrJIjf9PGhQ+4Q2gopw==", "9a0cb047-032f-4dcb-96ac-b5183974e3d6", new DateTime(2023, 9, 2, 23, 43, 59, 606, DateTimeKind.Local).AddTicks(2406) });
        }
    }
}
