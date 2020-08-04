using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class FixingMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PluginGroupPermissionVersions_PluginGroupPermissions_FK_Plugi",
                table: "PluginGroupPermissionVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_PluginGroupPermissionVersions_PluginPermissions_PermissionId",
                table: "PluginGroupPermissionVersions");

            migrationBuilder.DropIndex(
                name: "IX_PluginGroupPermissionVersions_PermissionId",
                table: "PluginGroupPermissionVersions");

            migrationBuilder.DropColumn(
                name: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningCases_ItemId",
                table: "PlanningCases",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningCases_Items_ItemId",
                table: "PlanningCases",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanningCases_Items_ItemId",
                table: "PlanningCases");

            migrationBuilder.DropIndex(
                name: "IX_PlanningCases_ItemId",
                table: "PlanningCases");

            migrationBuilder.AddColumn<int>(
                name: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PluginGroupPermissionVersions_FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions",
                column: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PluginGroupPermissionVersions_PermissionId",
                table: "PluginGroupPermissionVersions",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PluginGroupPermissionVersions_PluginGroupPermissions_FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions",
                column: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                principalTable: "PluginGroupPermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PluginGroupPermissionVersions_PluginPermissions_PermissionId",
                table: "PluginGroupPermissionVersions",
                column: "PermissionId",
                principalTable: "PluginPermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
