using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddFolderId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FolderId",
                table: "PlanningVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FolderId",
                table: "Plannings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FolderId",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "FolderId",
                table: "Plannings");
        }
    }
}
