using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microting.ItemsPlanningBase.Migrations
{
    /// <inheritdoc />
    public partial class AddingReportGroupPlanningTagId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportGroupPlanningTagId",
                table: "PlanningVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportGroupPlanningTagId",
                table: "Plannings",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportGroupPlanningTagId",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "ReportGroupPlanningTagId",
                table: "Plannings");
        }
    }
}