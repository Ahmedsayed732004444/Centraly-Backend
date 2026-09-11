using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centraly.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddBatchIdToInvoiceItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchId",
                table: "InvoiceItems",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_BatchId",
                table: "InvoiceItems",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_ProductBatches_BatchId",
                table: "InvoiceItems",
                column: "BatchId",
                principalTable: "ProductBatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_ProductBatches_BatchId",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_BatchId",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "InvoiceItems");
        }
    }
}
