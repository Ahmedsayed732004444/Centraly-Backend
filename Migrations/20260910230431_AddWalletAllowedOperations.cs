using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centraly.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddWalletAllowedOperations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AllowedOperations",
                table: "Wallets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowedOperations",
                table: "Wallets");
        }
    }
}
