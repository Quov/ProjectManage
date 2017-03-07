using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eTeamProjectManagement.Data.Migrations
{
    public partial class finalintchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PriorityId",
                table: "ProjectData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectTypeId",
                table: "ProjectData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ProjectData",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "ProjectData");

            migrationBuilder.DropColumn(
                name: "ProjectTypeId",
                table: "ProjectData");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ProjectData");

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
    }
}
