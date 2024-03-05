using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionRequestAPI.Migrations
{
    /// <inheritdoc />
    public partial class Inspectionplannedduration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "PlannedDuration",
                table: "inspections",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlannedDuration",
                table: "inspections");
        }
    }
}
