using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddSdkParentFolderNametoPlanningAndPlanningVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SdkParentFolderName",
                table: "PlanningVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkParentFolderName",
                table: "Plannings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SdkParentFolderName",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkParentFolderName",
                table: "Plannings");
        }
    }
}
