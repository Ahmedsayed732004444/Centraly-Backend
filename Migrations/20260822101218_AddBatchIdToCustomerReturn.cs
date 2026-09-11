using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centraly.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddBatchIdToCustomerReturn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BatchId",
                table: "ReturnItems",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnItems_BatchId",
                table: "ReturnItems",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnItems_ProductBatches_BatchId",
                table: "ReturnItems",
                column: "BatchId",
                principalTable: "ProductBatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnItems_ProductBatches_BatchId",
                table: "ReturnItems");

            migrationBuilder.DropIndex(
                name: "IX_ReturnItems_BatchId",
                table: "ReturnItems");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "ReturnItems");
        }
    }
}
