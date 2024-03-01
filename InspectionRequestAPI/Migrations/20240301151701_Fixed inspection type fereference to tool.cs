using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionRequestAPI.Migrations
{
    /// <inheritdoc />
    public partial class Fixedinspectiontypefereferencetotool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_examinations_inspectionTypes_UsedForTypeId",
                table: "examinations");

            migrationBuilder.DropIndex(
                name: "IX_examinations_UsedForTypeId",
                table: "examinations");

            migrationBuilder.DropColumn(
                name: "UsedForTypeId",
                table: "examinations");

            migrationBuilder.AddColumn<Guid>(
                name: "UsedForTypeId",
                table: "tools",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tools_UsedForTypeId",
                table: "tools",
                column: "UsedForTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tools_inspectionTypes_UsedForTypeId",
                table: "tools",
                column: "UsedForTypeId",
                principalTable: "inspectionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tools_inspectionTypes_UsedForTypeId",
                table: "tools");

            migrationBuilder.DropIndex(
                name: "IX_tools_UsedForTypeId",
                table: "tools");

            migrationBuilder.DropColumn(
                name: "UsedForTypeId",
                table: "tools");

            migrationBuilder.AddColumn<Guid>(
                name: "UsedForTypeId",
                table: "examinations",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_examinations_UsedForTypeId",
                table: "examinations",
                column: "UsedForTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_examinations_inspectionTypes_UsedForTypeId",
                table: "examinations",
                column: "UsedForTypeId",
                principalTable: "inspectionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
