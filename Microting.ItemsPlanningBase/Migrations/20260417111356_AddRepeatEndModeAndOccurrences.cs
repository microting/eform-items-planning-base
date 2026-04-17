using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microting.ItemsPlanningBase.Migrations
{
    /// <inheritdoc />
    public partial class AddRepeatEndModeAndOccurrences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepeatEndMode",
                table: "PlanningVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepeatOccurrences",
                table: "PlanningVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepeatEndMode",
                table: "Plannings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepeatOccurrences",
                table: "Plannings",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepeatEndMode",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "RepeatOccurrences",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "RepeatEndMode",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "RepeatOccurrences",
                table: "Plannings");
        }
    }
}
