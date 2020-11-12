using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddPlanningSiteExecutedTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastExecutedTime",
                table: "PlanningSiteVersions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastExecutedTime",
                table: "PlanningSites",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastExecutedTime",
                table: "PlanningSiteVersions");

            migrationBuilder.DropColumn(
                name: "LastExecutedTime",
                table: "PlanningSites");
        }
    }
}
