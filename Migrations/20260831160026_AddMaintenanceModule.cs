using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centraly.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddMaintenanceModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SparePartUsages");

            migrationBuilder.DropTable(
                name: "SpareParts");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceDevices_DrawerTransactionId",
                table: "MaintenanceDevices");

            migrationBuilder.DropCheckConstraint(
                name: "CK_MaintenanceDevice_PaidAmount",
                table: "MaintenanceDevices");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MaintenanceDevices");

            migrationBuilder.AddColumn<decimal>(
                name: "ServicePrice",
                table: "MaintenanceDevices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "MaintenanceDevices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPartsPrice",
                table: "MaintenanceDevices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "MaintenanceDevices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "DrawerSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MaintenanceProductItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    MaintenanceDeviceId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MaintenancePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceProductItems", x => x.Id);
                    table.CheckConstraint("CK_MaintenanceProductItem_Quantity", "[Quantity] > 0");
                    table.ForeignKey(
                        name: "FK_MaintenanceProductItems_MaintenanceDevices_MaintenanceDeviceId",
                        column: x => x.MaintenanceDeviceId,
                        principalTable: "MaintenanceDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceProductItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDevices_DrawerTransactionId",
                table: "MaintenanceDevices",
                column: "DrawerTransactionId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_MaintenanceDevice_PaidAmount",
                table: "MaintenanceDevices",
                sql: "[PaidAmount] >= 0");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceProductItems_MaintenanceDeviceId",
                table: "MaintenanceProductItems",
                column: "MaintenanceDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceProductItems_ProductId",
                table: "MaintenanceProductItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceProductItems");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceDevices_DrawerTransactionId",
                table: "MaintenanceDevices");

            migrationBuilder.DropCheckConstraint(
                name: "CK_MaintenanceDevice_PaidAmount",
                table: "MaintenanceDevices");

            migrationBuilder.DropColumn(
                name: "ServicePrice",
                table: "MaintenanceDevices");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "MaintenanceDevices");

            migrationBuilder.DropColumn(
                name: "TotalPartsPrice",
                table: "MaintenanceDevices");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "MaintenanceDevices");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "DrawerSessions");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "MaintenanceDevices",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "SpareParts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MinQuantityAlert = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StorageLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpareParts", x => x.Id);
                    table.CheckConstraint("CK_SparePart_Quantity", "[Quantity] >= 0");
                });

            migrationBuilder.CreateTable(
                name: "SparePartUsages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    MaintenanceDeviceId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    SparePartId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    QuantityUsed = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UsedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SparePartUsages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SparePartUsages_MaintenanceDevices_MaintenanceDeviceId",
                        column: x => x.MaintenanceDeviceId,
                        principalTable: "MaintenanceDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SparePartUsages_SpareParts_SparePartId",
                        column: x => x.SparePartId,
                        principalTable: "SpareParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDevices_DrawerTransactionId",
                table: "MaintenanceDevices",
                column: "DrawerTransactionId",
                unique: true,
                filter: "[DrawerTransactionId] IS NOT NULL");

            migrationBuilder.AddCheckConstraint(
                name: "CK_MaintenanceDevice_PaidAmount",
                table: "MaintenanceDevices",
                sql: "[PaidAmount] >= 0 AND [PaidAmount] <= [Price]");

            migrationBuilder.CreateIndex(
                name: "IX_SparePartUsages_MaintenanceDeviceId",
                table: "SparePartUsages",
                column: "MaintenanceDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_SparePartUsages_SparePartId",
                table: "SparePartUsages",
                column: "SparePartId");
        }
    }
}
