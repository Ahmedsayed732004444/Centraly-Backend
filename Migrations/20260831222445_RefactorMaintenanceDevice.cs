using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centraly.Api.Migrations
{
    /// <inheritdoc />
    public partial class RefactorMaintenanceDevice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "MaintenanceDevices");

            migrationBuilder.AlterColumn<string>(
                name: "Problem",
                table: "MaintenanceDevices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DeviceDescription",
                table: "MaintenanceDevices",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceDescription",
                table: "MaintenanceDevices");

            migrationBuilder.AlterColumn<string>(
                name: "Problem",
                table: "MaintenanceDevices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "MaintenanceDevices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
