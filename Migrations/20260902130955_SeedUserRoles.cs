using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Centraly.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0191a4b6-c4fc-752e-9d95-40b5e4e68054", "0191a4b6-c4fc-752e-9d95-40b30fa7a9b6" },
                    { "6340d7c9-5aba-483f-90ad-29979e56999b", "517ab86b-fd99-438a-be09-6647986a5ca9" },
                    { "4ec432f6-c564-4291-b079-98636f8b8b1d", "947aa516-7fd4-4864-95b1-40abf2d29a9f" },
                    { "0191a4b6-c4fc-752e-9d95-40b7a5cb88f0", "aa146cf1-fbca-46cd-b63e-5f7c20b11703" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0191a4b6-c4fc-752e-9d95-40b5e4e68054", "0191a4b6-c4fc-752e-9d95-40b30fa7a9b6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6340d7c9-5aba-483f-90ad-29979e56999b", "517ab86b-fd99-438a-be09-6647986a5ca9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4ec432f6-c564-4291-b079-98636f8b8b1d", "947aa516-7fd4-4864-95b1-40abf2d29a9f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0191a4b6-c4fc-752e-9d95-40b7a5cb88f0", "aa146cf1-fbca-46cd-b63e-5f7c20b11703" });
        }
    }
}
