using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Organizations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "constacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 101);

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NIP = table.Column<string>(type: "TEXT", nullable: false),
                    REGON = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_City = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_Street = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "constacts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "OrganizationId" },
                values: new object[] { new DateTime(2024, 11, 13, 11, 12, 32, 123, DateTimeKind.Local).AddTicks(5856), 101 });

            migrationBuilder.UpdateData(
                table: "constacts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "OrganizationId" },
                values: new object[] { new DateTime(2024, 11, 13, 11, 12, 32, 123, DateTimeKind.Local).AddTicks(5904), 101 });

            migrationBuilder.UpdateData(
                table: "constacts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "OrganizationId" },
                values: new object[] { new DateTime(2024, 11, 13, 11, 12, 32, 123, DateTimeKind.Local).AddTicks(5908), 101 });

            migrationBuilder.InsertData(
                table: "organizations",
                columns: new[] { "Id", "Adress_City", "Adress_Street", "NIP", "Name", "REGON" },
                values: new object[,]
                {
                    { 101, "Kraków", "św. Filipa", "12312313", "WSEI", "123131231" },
                    { 102, "Łódź", "Dworcowa", "123123132", "WSEI2", "123131231213" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_constacts_OrganizationId",
                table: "constacts",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_constacts_organizations_OrganizationId",
                table: "constacts",
                column: "OrganizationId",
                principalTable: "organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_constacts_organizations_OrganizationId",
                table: "constacts");

            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropIndex(
                name: "IX_constacts_OrganizationId",
                table: "constacts");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "constacts");

            migrationBuilder.UpdateData(
                table: "constacts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 6, 11, 39, 25, 28, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "constacts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 11, 6, 11, 39, 25, 28, DateTimeKind.Local).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "constacts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 11, 6, 11, 39, 25, 28, DateTimeKind.Local).AddTicks(2465));
        }
    }
}
