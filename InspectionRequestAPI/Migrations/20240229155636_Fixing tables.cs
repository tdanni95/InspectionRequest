using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionRequestAPI.Migrations
{
    /// <inheritdoc />
    public partial class Fixingtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "inspectionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inspectionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsEngineer = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false),
                    ForName = table.Column<string>(type: "TEXT", nullable: false),
                    SurName = table.Column<string>(type: "TEXT", nullable: false),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToolUser",
                columns: table => new
                {
                    EngineersWhoCanUseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ToolsICanUseId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolUser", x => new { x.EngineersWhoCanUseId, x.ToolsICanUseId });
                    table.ForeignKey(
                        name: "FK_ToolUser_tools_ToolsICanUseId",
                        column: x => x.ToolsICanUseId,
                        principalTable: "tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToolUser_users_EngineersWhoCanUseId",
                        column: x => x.EngineersWhoCanUseId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "attendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_attendances_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "inspectionRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PartNumber = table.Column<string>(type: "TEXT", nullable: false),
                    RequestorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RequestorRequest = table.Column<string>(type: "TEXT", nullable: false),
                    IsWaste = table.Column<bool>(type: "INTEGER", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    InspectionTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    Visible = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inspectionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inspectionRequests_inspectionTypes_InspectionTypeId",
                        column: x => x.InspectionTypeId,
                        principalTable: "inspectionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inspectionRequests_users_RequestorId",
                        column: x => x.RequestorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chemicalInspections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MustDiscardAfterInspection = table.Column<bool>(type: "INTEGER", nullable: false),
                    DangerComment = table.Column<string>(type: "TEXT", nullable: false),
                    ParentInspectionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chemicalInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chemicalInspections_inspectionRequests_ParentInspectionId",
                        column: x => x.ParentInspectionId,
                        principalTable: "inspectionRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FinishedAd = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Order = table.Column<uint>(type: "INTEGER", nullable: false),
                    ToolId = table.Column<Guid>(type: "TEXT", nullable: false),
                    InspectionRequestId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inspections_inspectionRequests_InspectionRequestId",
                        column: x => x.InspectionRequestId,
                        principalTable: "inspectionRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_inspections_tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mechanicalInspections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Length = table.Column<uint>(type: "INTEGER", nullable: false),
                    Width = table.Column<uint>(type: "INTEGER", nullable: false),
                    Depth = table.Column<uint>(type: "INTEGER", nullable: false),
                    StructuralIntegrity = table.Column<string>(type: "TEXT", nullable: false),
                    ParentInspectionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mechanicalInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mechanicalInspections_inspectionRequests_ParentInspectionId",
                        column: x => x.ParentInspectionId,
                        principalTable: "inspectionRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "particles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<uint>(type: "INTEGER", nullable: false),
                    ChemicalInspectionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_particles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_particles_chemicalInspections_ChemicalInspectionId",
                        column: x => x.ChemicalInspectionId,
                        principalTable: "chemicalInspections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToolUser_ToolsICanUseId",
                table: "ToolUser",
                column: "ToolsICanUseId");

            migrationBuilder.CreateIndex(
                name: "IX_attendances_UserId",
                table: "attendances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_chemicalInspections_ParentInspectionId",
                table: "chemicalInspections",
                column: "ParentInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_inspectionRequests_InspectionTypeId",
                table: "inspectionRequests",
                column: "InspectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_inspectionRequests_RequestorId",
                table: "inspectionRequests",
                column: "RequestorId");

            migrationBuilder.CreateIndex(
                name: "IX_inspections_InspectionRequestId",
                table: "inspections",
                column: "InspectionRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_inspections_ToolId",
                table: "inspections",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_mechanicalInspections_ParentInspectionId",
                table: "mechanicalInspections",
                column: "ParentInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_particles_ChemicalInspectionId",
                table: "particles",
                column: "ChemicalInspectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToolUser");

            migrationBuilder.DropTable(
                name: "attendances");

            migrationBuilder.DropTable(
                name: "inspections");

            migrationBuilder.DropTable(
                name: "mechanicalInspections");

            migrationBuilder.DropTable(
                name: "particles");

            migrationBuilder.DropTable(
                name: "tools");

            migrationBuilder.DropTable(
                name: "chemicalInspections");

            migrationBuilder.DropTable(
                name: "inspectionRequests");

            migrationBuilder.DropTable(
                name: "inspectionTypes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
