using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Centraly.Api.Migrations
{
    /// <inheritdoc />
    public partial class hhdgd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DeletedAt", "IsDefault", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0191a4b6-c4fc-752e-9d95-40b7a5cb88f0", "0191a4b6-c4fc-752e-9d95-40b85cf3fd22", null, false, false, "Salesperson", "SALESPERSON" },
                    { "4ec432f6-c564-4291-b079-98636f8b8b1d", "19a49e8c-9372-4b21-937b-9304b99a4d01", null, false, false, "Technician", "TECHNICIAN" },
                    { "6340d7c9-5aba-483f-90ad-29979e56999b", "fb6de3d0-ca0a-44d4-97d4-03caa996184a", null, false, false, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "517ab86b-fd99-438a-be09-6647986a5ca9", 0, "3ac4ffe0-30dd-433a-9212-088346bedcf6", new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "manager@gmail.com", true, false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAIAAYagAAAAEKRku5u6K325Irl1Utujiuil/WUhjTvShS9mJLXxO+2v/GKrMT1Ofhdp/0taFUO2bA==", null, false, "4831b51a-68fc-40ed-90ac-815d0e218a24", false, "manager@gmail.com" },
                    { "947aa516-7fd4-4864-95b1-40abf2d29a9f", 0, "ba02318d-c674-4ff5-b607-55e43cad9aff", new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tech@gmail.com", true, false, null, "TECH@GMAIL.COM", "TECH@GMAIL.COM", "AQAAAAIAAYagAAAAEKRku5u6K325Irl1Utujiuil/WUhjTvShS9mJLXxO+2v/GKrMT1Ofhdp/0taFUO2bA==", null, false, "7cc9e897-ce48-49aa-926f-7831277b1d14", false, "tech@gmail.com" },
                    { "aa146cf1-fbca-46cd-b63e-5f7c20b11703", 0, "37635289-2152-499a-982f-599964b8f80f", new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "sales@gmail.com", true, false, null, "SALES@GMAIL.COM", "SALES@GMAIL.COM", "AQAAAAIAAYagAAAAEKRku5u6K325Irl1Utujiuil/WUhjTvShS9mJLXxO+2v/GKrMT1Ofhdp/0taFUO2bA==", null, false, "9a1bb131-a421-438d-b468-f5b59564f706", false, "sales@gmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0191a4b6-c4fc-752e-9d95-40b7a5cb88f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ec432f6-c564-4291-b079-98636f8b8b1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6340d7c9-5aba-483f-90ad-29979e56999b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "517ab86b-fd99-438a-be09-6647986a5ca9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "947aa516-7fd4-4864-95b1-40abf2d29a9f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa146cf1-fbca-46cd-b63e-5f7c20b11703");
        }
    }
}
