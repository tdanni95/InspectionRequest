using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionRequestAPI.Migrations
{
    /// <inheritdoc />
    public partial class Addedexaminationandengineertoinspection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "inspections",
                newName: "ExaminationId");

            migrationBuilder.AddColumn<Guid>(
                name: "PerformedById",
                table: "inspections",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspections_ExaminationId",
                table: "inspections",
                column: "ExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_inspections_PerformedById",
                table: "inspections",
                column: "PerformedById");

            migrationBuilder.AddForeignKey(
                name: "FK_inspections_examinations_ExaminationId",
                table: "inspections",
                column: "ExaminationId",
                principalTable: "examinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inspections_users_PerformedById",
                table: "inspections",
                column: "PerformedById",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inspections_examinations_ExaminationId",
                table: "inspections");

            migrationBuilder.DropForeignKey(
                name: "FK_inspections_users_PerformedById",
                table: "inspections");

            migrationBuilder.DropIndex(
                name: "IX_inspections_ExaminationId",
                table: "inspections");

            migrationBuilder.DropIndex(
                name: "IX_inspections_PerformedById",
                table: "inspections");

            migrationBuilder.DropColumn(
                name: "PerformedById",
                table: "inspections");

            migrationBuilder.RenameColumn(
                name: "ExaminationId",
                table: "inspections",
                newName: "Name");
        }
    }
}
