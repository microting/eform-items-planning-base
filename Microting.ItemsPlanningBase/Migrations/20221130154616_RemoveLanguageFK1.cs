using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microting.ItemsPlanningBase.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLanguageFK1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanningNameTranslationVersions_Languages_LanguageId",
                table: "PlanningNameTranslationVersions");

            migrationBuilder.DropIndex(
                name: "IX_PlanningNameTranslationVersions_LanguageId",
                table: "PlanningNameTranslationVersions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PlanningNameTranslationVersions_LanguageId",
                table: "PlanningNameTranslationVersions",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningNameTranslationVersions_Languages_LanguageId",
                table: "PlanningNameTranslationVersions",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
