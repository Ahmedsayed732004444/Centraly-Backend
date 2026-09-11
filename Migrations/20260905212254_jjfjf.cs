using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Centraly.Api.Migrations
{
    /// <inheritdoc />
    public partial class jjfjf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TransactionSourcePolicies",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111");

            migrationBuilder.DeleteData(
                table: "TransactionSourcePolicies",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-222222222222");

            migrationBuilder.DeleteData(
                table: "TransactionSourcePolicies",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333");

            migrationBuilder.DeleteData(
                table: "TransactionSourcePolicies",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444");

            migrationBuilder.DeleteData(
                table: "TransactionSourcePolicies",
                keyColumn: "Id",
                keyValue: "55555555-5555-5555-5555-555555555555");

            migrationBuilder.DeleteData(
                table: "TransactionSourcePolicies",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666");

            migrationBuilder.DeleteData(
                table: "TransactionSourcePolicies",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777");

            migrationBuilder.DeleteData(
                table: "TransactionSourcePolicies",
                keyColumn: "Id",
                keyValue: "88888888-8888-8888-8888-888888888888");

            migrationBuilder.DeleteData(
                table: "TransactionSourcePolicies",
                keyColumn: "Id",
                keyValue: "99999999-9999-9999-9999-999999999999");

            migrationBuilder.DeleteData(
                table: "TransactionSourcePolicies",
                keyColumn: "Id",
                keyValue: "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

            migrationBuilder.DeleteData(
                table: "TransactionSourcePolicies",
                keyColumn: "Id",
                keyValue: "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

            migrationBuilder.DeleteData(
                table: "TransactionSourcePolicies",
                keyColumn: "Id",
                keyValue: "cccccccc-cccc-cccc-cccc-cccccccccccc");

            migrationBuilder.DeleteData(
                table: "TransactionSourcePolicies",
                keyColumn: "Id",
                keyValue: "dddddddd-dddd-dddd-dddd-dddddddddddd");

            migrationBuilder.InsertData(
                table: "Safes",
                columns: new[] { "Id", "Balance", "CreatedAt", "CreatedByUserId", "DeletedAt", "IsDeleted", "IsMain", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { "0191a4b6-c4fc-752e-9d95-40b900000001", 0m, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, true, "الخزينة الرئيسية", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Safes",
                keyColumn: "Id",
                keyValue: "0191a4b6-c4fc-752e-9d95-40b900000001");

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
    }
}
