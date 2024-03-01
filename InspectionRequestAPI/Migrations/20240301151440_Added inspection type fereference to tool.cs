using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionRequestAPI.Migrations
{
    /// <inheritdoc />
    public partial class Addedinspectiontypefereferencetotool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
