using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microting.ItemsPlanningBase.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLanguageFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanningNameTranslation_Languages_LanguageId",
                table: "PlanningNameTranslation");

            migrationBuilder.DropIndex(
                name: "IX_PlanningNameTranslation_LanguageId",
                table: "PlanningNameTranslation");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Languages",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Languages");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNameTranslation_LanguageId",
                table: "PlanningNameTranslation",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningNameTranslation_Languages_LanguageId",
                table: "PlanningNameTranslation",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
