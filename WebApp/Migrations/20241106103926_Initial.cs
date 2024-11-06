using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "constacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    phone = table.Column<string>(type: "TEXT", nullable: false),
                    Birth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_constacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "constacts",
                columns: new[] { "Id", "Birth", "Category", "Created", "Email", "FirstName", "LastName", "phone" },
                values: new object[,]
                {
                    { 4, new DateOnly(2000, 10, 10), 0, new DateTime(2024, 11, 6, 11, 39, 25, 28, DateTimeKind.Local).AddTicks(2422), "123@123", "123", "123", "123123123" },
                    { 5, new DateOnly(2000, 10, 10), 0, new DateTime(2024, 11, 6, 11, 39, 25, 28, DateTimeKind.Local).AddTicks(2463), "abc@abc", "abc", "abc", "123123124" },
                    { 6, new DateOnly(2000, 10, 10), 0, new DateTime(2024, 11, 6, 11, 39, 25, 28, DateTimeKind.Local).AddTicks(2465), "123@1235abc", "1235abc", "1235abc", "123123125" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "constacts");
        }
    }
}
