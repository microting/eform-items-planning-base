using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microting.ItemsPlanningBase.Migrations
{
    /// <inheritdoc />
    public partial class AddRepeatOrdinalWeekToPlanning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepeatOrdinalWeek",
                table: "PlanningVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepeatOrdinalWeek",
                table: "Plannings",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepeatOrdinalWeek",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "RepeatOrdinalWeek",
                table: "Plannings");
        }
    }
}
