using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microting.ItemsPlanningBase.Migrations
{
    /// <inheritdoc />
    public partial class RemovingLanguageFK2 : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
