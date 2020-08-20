using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddingFolderNameToPlanning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled1",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled10",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled2",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled3",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled4",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled5",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled6",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled7",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled8",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled9",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId1",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId10",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId2",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId3",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId4",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId5",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId6",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId7",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId8",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId9",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled1",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled10",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled2",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled3",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled4",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled5",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled6",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled7",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled8",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled9",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldId1",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldId10",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldId2",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldId3",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldId4",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldId5",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldId6",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldId7",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldId8",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "SdkFieldId9",
                table: "Plannings");

            migrationBuilder.AddColumn<string>(
                name: "SdkFolderName",
                table: "PlanningVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFolderName",
                table: "Plannings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SdkFolderName",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "SdkFolderName",
                table: "Plannings");

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled1",
                table: "PlanningVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled10",
                table: "PlanningVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled2",
                table: "PlanningVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled3",
                table: "PlanningVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled4",
                table: "PlanningVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled5",
                table: "PlanningVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled6",
                table: "PlanningVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled7",
                table: "PlanningVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled8",
                table: "PlanningVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled9",
                table: "PlanningVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId1",
                table: "PlanningVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId10",
                table: "PlanningVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId2",
                table: "PlanningVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId3",
                table: "PlanningVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId4",
                table: "PlanningVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId5",
                table: "PlanningVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId6",
                table: "PlanningVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId7",
                table: "PlanningVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId8",
                table: "PlanningVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId9",
                table: "PlanningVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled1",
                table: "Plannings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled10",
                table: "Plannings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled2",
                table: "Plannings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled3",
                table: "Plannings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled4",
                table: "Plannings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled5",
                table: "Plannings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled6",
                table: "Plannings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled7",
                table: "Plannings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled8",
                table: "Plannings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled9",
                table: "Plannings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId1",
                table: "Plannings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId10",
                table: "Plannings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId2",
                table: "Plannings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId3",
                table: "Plannings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId4",
                table: "Plannings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId5",
                table: "Plannings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId6",
                table: "Plannings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId7",
                table: "Plannings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId8",
                table: "Plannings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId9",
                table: "Plannings",
                type: "int",
                nullable: true);
        }
    }
}
