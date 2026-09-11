using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centraly.Api.Migrations
{
    /// <inheritdoc />
    public partial class fornfi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Wallets",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Wallets");
        }
    }
}
