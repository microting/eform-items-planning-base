using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microting.ItemsPlanningBase.Migrations
{
    /// <inheritdoc />
    public partial class AddShowExpireDateExpireInYearsToPlannings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanningNameTranslation_Languages_LanguageId",
                table: "PlanningNameTranslation");

            migrationBuilder.AddColumn<int>(
                name: "ExpireInYears",
                table: "PlanningVersions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ShowExpireDate",
                table: "PlanningVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ExpireInYears",
                table: "Plannings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ShowExpireDate",
                table: "Plannings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningNameTranslation_Languages_LanguageId",
                table: "PlanningNameTranslation",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanningNameTranslation_Languages_LanguageId",
                table: "PlanningNameTranslation");

            migrationBuilder.DropColumn(
                name: "ExpireInYears",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "ShowExpireDate",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "ExpireInYears",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "ShowExpireDate",
                table: "Plannings");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningNameTranslation_Languages_LanguageId",
                table: "PlanningNameTranslation",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
