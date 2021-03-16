using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddingAttributesForPush : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DoneInPeriod",
                table: "PlanningVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextExecutionTime",
                table: "PlanningVersions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DoneInPeriod",
                table: "Plannings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextExecutionTime",
                table: "Plannings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoneInPeriod",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "NextExecutionTime",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "DoneInPeriod",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "NextExecutionTime",
                table: "Plannings");
        }
    }
}
