using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Centraly.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionSourcePolicies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionSourcePolicies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    AllowedSource = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionSourcePolicies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TransactionSourcePolicies",
                columns: new[] { "Id", "AllowedSource", "Category", "UpdatedAt" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", 1, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { "22222222-2222-2222-2222-222222222222", 1, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { "33333333-3333-3333-3333-333333333333", 1, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { "44444444-4444-4444-4444-444444444444", 1, 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { "55555555-5555-5555-5555-555555555555", 3, 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { "66666666-6666-6666-6666-666666666666", 3, 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { "77777777-7777-7777-7777-777777777777", 3, 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { "88888888-8888-8888-8888-888888888888", 3, 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { "99999999-9999-9999-9999-999999999999", 3, 9, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa", 2, 10, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb", 2, 11, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { "cccccccc-cccc-cccc-cccc-cccccccccccc", 3, 12, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { "dddddddd-dddd-dddd-dddd-dddddddddddd", 3, 13, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionSourcePolicies");
        }
    }
}
