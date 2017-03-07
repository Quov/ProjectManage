using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eTeamProjectManagement.Data.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectData_ProjectPriorities_PriorityId",
                table: "ProjectData");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectData_ProjectTypes_ProjectTypeId",
                table: "ProjectData");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectData_ProjectStatuses_StatusId",
                table: "ProjectData");

            migrationBuilder.DropIndex(
                name: "IX_ProjectData_PriorityId",
                table: "ProjectData");

            migrationBuilder.DropIndex(
                name: "IX_ProjectData_ProjectTypeId",
                table: "ProjectData");

            migrationBuilder.DropIndex(
                name: "IX_ProjectData_StatusId",
                table: "ProjectData");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "ProjectData");

            migrationBuilder.DropColumn(
                name: "ProjectTypeId",
                table: "ProjectData");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ProjectData");

            migrationBuilder.DropTable(
                name: "ProjectPriorities");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "ProjectData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectType",
                table: "ProjectData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ProjectData",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "ProjectData");

            migrationBuilder.DropColumn(
                name: "ProjectType",
                table: "ProjectData");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProjectData");

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

            migrationBuilder.AddColumn<int>(
                name: "PriorityId",
                table: "ProjectData",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectTypeId",
                table: "ProjectData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ProjectData",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectData_ProjectPriorities_PriorityId",
                table: "ProjectData",
                column: "PriorityId",
                principalTable: "ProjectPriorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectData_ProjectTypes_ProjectTypeId",
                table: "ProjectData",
                column: "ProjectTypeId",
                principalTable: "ProjectTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectData_ProjectStatuses_StatusId",
                table: "ProjectData",
                column: "StatusId",
                principalTable: "ProjectStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
