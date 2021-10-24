using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddingLockHiddenEditableAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEditable",
                table: "PlanningVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "PlanningVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "PlanningVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEditable",
                table: "Plannings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Plannings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Plannings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEditable",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "IsEditable",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Plannings");
        }
    }
}
