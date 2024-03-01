using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionRequestAPI.Migrations
{
    /// <inheritdoc />
    public partial class Removedtoolreferencefrominspection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inspections_tools_ToolId",
                table: "inspections");

            migrationBuilder.DropIndex(
                name: "IX_inspections_ToolId",
                table: "inspections");

            migrationBuilder.DropColumn(
                name: "ToolId",
                table: "inspections");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ToolId",
                table: "inspections",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_inspections_ToolId",
                table: "inspections",
                column: "ToolId");

            migrationBuilder.AddForeignKey(
                name: "FK_inspections_tools_ToolId",
                table: "inspections",
                column: "ToolId",
                principalTable: "tools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
