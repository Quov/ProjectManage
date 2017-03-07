using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eTeamProjectManagement.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IssueType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    InitialLogged = table.Column<DateTime>(nullable: false),
                    InitialLoggedBy = table.Column<string>(nullable: true),
                    IssueId = table.Column<int>(nullable: false),
                    IssueUpdateId = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    UpdateType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueUpdates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectContactData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactEmail = table.Column<string>(nullable: true),
                    ContactNote = table.Column<string>(nullable: true),
                    ContactPhone = table.Column<string>(nullable: true),
                    ContactRole = table.Column<string>(nullable: true),
                    ContactTimeZone = table.Column<string>(nullable: true),
                    ProjectContactId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContactData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPriorities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectPriority = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPriorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUpdatePartys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UpdateParty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUpdatePartys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUpdateTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectUpdateType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUpdateTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateLogged = table.Column<DateTime>(nullable: false),
                    DateResolved = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IssueTypeId = table.Column<int>(nullable: true),
                    LoggedBy = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueData_IssueTypes_IssueTypeId",
                        column: x => x.IssueTypeId,
                        principalTable: "IssueTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssignedTeam = table.Column<string>(nullable: false),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    BillToClientNumber = table.Column<string>(maxLength: 6, nullable: false),
                    ClientName = table.Column<string>(nullable: false),
                    ClientNumber = table.Column<string>(maxLength: 6, nullable: false),
                    Cst = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PriorityId = table.Column<int>(nullable: true),
                    ProjectOwner = table.Column<string>(nullable: false),
                    ProjectTypeId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: true),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectData_ProjectPriorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "ProjectPriorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectData_ProjectTypes_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "ProjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectData_ProjectStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ProjectStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectITUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    InitialUpdate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    ProjectITUpdateId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    UpdateFromId = table.Column<int>(nullable: true),
                    UpdateTypeId = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectITUpdates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectITUpdates_ProjectUpdatePartys_UpdateFromId",
                        column: x => x.UpdateFromId,
                        principalTable: "ProjectUpdatePartys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectITUpdates_ProjectUpdateTypes_UpdateTypeId",
                        column: x => x.UpdateTypeId,
                        principalTable: "ProjectUpdateTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTeamUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    InitialUpdate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    ProjectUpdateId = table.Column<int>(nullable: false),
                    UpdateFromId = table.Column<int>(nullable: true),
                    UpdateTypeId = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTeamUpdates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTeamUpdates_ProjectUpdatePartys_UpdateFromId",
                        column: x => x.UpdateFromId,
                        principalTable: "ProjectUpdatePartys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectTeamUpdates_ProjectUpdateTypes_UpdateTypeId",
                        column: x => x.UpdateTypeId,
                        principalTable: "ProjectUpdateTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueData_IssueTypeId",
                table: "IssueData",
                column: "IssueTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectData_PriorityId",
                table: "ProjectData",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectData_ProjectTypeId",
                table: "ProjectData",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectData_StatusId",
                table: "ProjectData",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectITUpdates_UpdateFromId",
                table: "ProjectITUpdates",
                column: "UpdateFromId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectITUpdates_UpdateTypeId",
                table: "ProjectITUpdates",
                column: "UpdateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTeamUpdates_UpdateFromId",
                table: "ProjectTeamUpdates",
                column: "UpdateFromId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTeamUpdates_UpdateTypeId",
                table: "ProjectTeamUpdates",
                column: "UpdateTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueData");

            migrationBuilder.DropTable(
                name: "IssueUpdates");

            migrationBuilder.DropTable(
                name: "ProjectContactData");

            migrationBuilder.DropTable(
                name: "ProjectData");

            migrationBuilder.DropTable(
                name: "ProjectITUpdates");

            migrationBuilder.DropTable(
                name: "ProjectTeamUpdates");

            migrationBuilder.DropTable(
                name: "IssueTypes");

            migrationBuilder.DropTable(
                name: "ProjectPriorities");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropTable(
                name: "ProjectStatuses");

            migrationBuilder.DropTable(
                name: "ProjectUpdatePartys");

            migrationBuilder.DropTable(
                name: "ProjectUpdateTypes");
        }
    }
}
