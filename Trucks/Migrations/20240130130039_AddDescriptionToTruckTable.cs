using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trucks.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToTruckTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Trucks",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Trucks");
        }
    }
}
