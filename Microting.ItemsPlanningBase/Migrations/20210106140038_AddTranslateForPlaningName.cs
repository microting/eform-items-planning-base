using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddTranslateForPlaningName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Languages",
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
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.Sql("INSERT INTO Languages VALUES (1, 1, 'created', now(), now(), 'Danish', 'da')");
            migrationBuilder.Sql("INSERT INTO Languages VALUES (2, 1, 'created', now(), now(), 'English', 'en-US')");
            migrationBuilder.Sql("INSERT INTO Languages VALUES (3, 1, 'created', now(), now(), 'German', 'de-DE')");

            migrationBuilder.CreateTable(
                name: "PlanningNameTranslation",
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
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    LanguageId = table.Column<int>(nullable: false),
                    PlanningId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningNameTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningNameTranslation_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanningNameTranslation_Plannings_PlanningId",
                        column: x => x.PlanningId,
                        principalTable: "Plannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanningNameTranslationVersions",
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
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    LanguageId = table.Column<int>(nullable: false),
                    PlanningId = table.Column<int>(nullable: false),
                    PlanningNameTranslationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningNameTranslationVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningNameTranslationVersions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanningNameTranslationVersions_PlanningNameTranslation_Plan~",
                        column: x => x.PlanningNameTranslationId,
                        principalTable: "PlanningNameTranslation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("INSERT INTO PlanningNameTranslation (Name, PlanningId, LanguageId, CreatedAt, UpdatedAt, Version, UpdatedByUserId, CreatedByUserId, WorkflowState) SELECT Name, Id, 1, CreatedAt, UpdatedAt, Version, UpdatedByUserId, CreatedByUserId, WorkflowState FROM Plannings;");
            migrationBuilder.Sql("INSERT INTO PlanningNameTranslationVersions (Name, PlanningId, LanguageId, CreatedAt, UpdatedAt, Version, UpdatedByUserId, CreatedByUserId, WorkflowState, PlanningNameTranslationId) SELECT Name, PlanningId, 1, CreatedAt, UpdatedAt, Version, UpdatedByUserId, CreatedByUserId, WorkflowState, Id FROM PlanningNameTranslation;");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNameTranslation_LanguageId",
                table: "PlanningNameTranslation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNameTranslation_PlanningId",
                table: "PlanningNameTranslation",
                column: "PlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNameTranslationVersions_LanguageId",
                table: "PlanningNameTranslationVersions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNameTranslationVersions_PlanningNameTranslationId",
                table: "PlanningNameTranslationVersions",
                column: "PlanningNameTranslationId");
            
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Plannings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanningNameTranslationVersions");

            migrationBuilder.DropTable(
                name: "PlanningNameTranslation");

            migrationBuilder.DropTable(
                name: "Languages");

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
