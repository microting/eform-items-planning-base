using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddDaysBeforeRedeploymentPushMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DaysBeforeRedeploymentPushMessage",
                table: "PlanningVersions",
                nullable: false,
                defaultValue: 5);

            migrationBuilder.AddColumn<bool>(
                name: "DaysBeforeRedeploymentPushMessageRepeat",
                table: "PlanningVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DaysBeforeRedeploymentPushMessage",
                table: "Plannings",
                nullable: false,
                defaultValue: 5);

            migrationBuilder.AddColumn<bool>(
                name: "DaysBeforeRedeploymentPushMessageRepeat",
                table: "Plannings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysBeforeRedeploymentPushMessage",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "DaysBeforeRedeploymentPushMessageRepeat",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "DaysBeforeRedeploymentPushMessage",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "DaysBeforeRedeploymentPushMessageRepeat",
                table: "Plannings");
        }
    }
}
