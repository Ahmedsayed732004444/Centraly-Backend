using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centraly.Api.Migrations
{
    /// <inheritdoc />
    public partial class FixFinancialAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Profit",
                table: "SafeTransactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Products",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "ProductBatches",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<decimal>(
                name: "RecordedProfit",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Profit",
                table: "Expenses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RunningBalance",
                table: "DrawerSessions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profit",
                table: "SafeTransactions");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "ProductBatches");

            migrationBuilder.DropColumn(
                name: "RecordedProfit",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Profit",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "RunningBalance",
                table: "DrawerSessions");
        }
    }
}
