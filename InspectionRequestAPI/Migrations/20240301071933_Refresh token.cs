using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionRequestAPI.Migrations
{
    /// <inheritdoc />
    public partial class Refreshtoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshToken_Created",
                table: "users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshToken_Expires",
                table: "users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken_Token",
                table: "users",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken_Created",
                table: "users");

            migrationBuilder.DropColumn(
                name: "RefreshToken_Expires",
                table: "users");

            migrationBuilder.DropColumn(
                name: "RefreshToken_Token",
                table: "users");
        }
    }
}
