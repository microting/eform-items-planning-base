using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddingMicrotingCheckListSitId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MicrotingCheckListSitId",
                table: "PlanningCaseSiteVersions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MicrotingCheckListSitId",
                table: "PlanningCaseSites",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MicrotingCheckListSitId",
                table: "PlanningCaseSiteVersions");

            migrationBuilder.DropColumn(
                name: "MicrotingCheckListSitId",
                table: "PlanningCaseSites");
        }
    }
}
