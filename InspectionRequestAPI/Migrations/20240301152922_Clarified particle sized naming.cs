using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionRequestAPI.Migrations
{
    /// <inheritdoc />
    public partial class Clarifiedparticlesizednaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "particles",
                newName: "SizeInNm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SizeInNm",
                table: "particles",
                newName: "Size");
        }
    }
}
