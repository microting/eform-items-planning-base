using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddTranslateForPlaningName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Plannings");

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Version = table.Column<int>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LanguageCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanningNameTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: true),
                    PlanningId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningNameTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningNameTranslations_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanningNameTranslations_Plannings_PlanningId",
                        column: x => x.PlanningId,
                        principalTable: "Plannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanningNameTranslationsVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: true),
                    PlanningId = table.Column<int>(nullable: true),
                    PlanningNameTranslationsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningNameTranslationsVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningNameTranslationsVersions_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanningNameTranslationsVersions_Plannings_PlanningId",
                        column: x => x.PlanningId,
                        principalTable: "Plannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanningNameTranslationsVersions_PlanningNameTranslations_Pl~",
                        column: x => x.PlanningNameTranslationsId,
                        principalTable: "PlanningNameTranslations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNameTranslations_LanguageId",
                table: "PlanningNameTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNameTranslations_PlanningId",
                table: "PlanningNameTranslations",
                column: "PlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNameTranslationsVersions_LanguageId",
                table: "PlanningNameTranslationsVersions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNameTranslationsVersions_PlanningId",
                table: "PlanningNameTranslationsVersions",
                column: "PlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNameTranslationsVersions_PlanningNameTranslationsId",
                table: "PlanningNameTranslationsVersions",
                column: "PlanningNameTranslationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanningNameTranslationsVersions");

            migrationBuilder.DropTable(
                name: "PlanningNameTranslations");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PlanningVersions",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Plannings",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
