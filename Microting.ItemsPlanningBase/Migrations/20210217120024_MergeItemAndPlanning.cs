using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class MergeItemAndPlanning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuildYear",
                table: "PlanningVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationCode",
                table: "PlanningVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanningNumber",
                table: "PlanningVersions",
                nullable: true);
            
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "PlanningVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildYear",
                table: "Plannings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationCode",
                table: "Plannings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanningNumber",
                table: "Plannings",
                nullable: true);

            migrationBuilder.RenameColumn(
                name: "ItemNumberEnabled",
                table: "Plannings",
                newName: "PlanningNumberEnabled");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Plannings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanningId",
                table: "PlanningCaseVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanningId",
                table: "PlanningCaseSiteVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanningId",
                table: "PlanningCaseSites",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanningId",
                table: "PlanningCases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlanningCases_PlanningId",
                table: "PlanningCases",
                column: "PlanningId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningCases_Plannings_PlanningId",
                table: "PlanningCases",
                column: "PlanningId",
                principalTable: "Plannings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            
            migrationBuilder.Sql(@"UPDATE Plannings p
                                   INNER JOIN Items i ON p.Id = i.PlanningId
                                   SET p.PlanningNumber = i.ItemNumber;");

            migrationBuilder.Sql(@"UPDATE PlanningVersions p
                                   INNER JOIN ItemVersions i ON p.PlanningId = i.PlanningId
                                   SET p.PlanningNumber = i.ItemNumber;");
            
            migrationBuilder.Sql(@"UPDATE PlanningCases p
                                   INNER JOIN Items i ON p.ItemId = i.Id
                                   SET p.PlanningId = i.PlanningId;");

            migrationBuilder.Sql(@"UPDATE PlanningCaseVersions p
                                   INNER JOIN ItemVersions i ON p.ItemId = i.Id
                                   SET p.PlanningId = i.PlanningId;");

            migrationBuilder.Sql(@"UPDATE PlanningCaseSites p
                                   INNER JOIN Items i ON p.ItemId = i.Id
                                   SET p.PlanningId = i.PlanningId;");

            migrationBuilder.Sql(@"UPDATE PlanningCaseSiteVersions p
                                   INNER JOIN ItemVersions i ON p.ItemId = i.Id
                                   SET p.PlanningId = i.PlanningId;");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanningCases_Items_ItemId",
                table: "PlanningCases");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ItemVersions");

            migrationBuilder.DropIndex(
                name: "IX_PlanningCases_ItemId",
                table: "PlanningCases");

            migrationBuilder.RenameColumn(
                name: "ItemNumberEnabled",
                table: "PlanningVersions",
                newName: "PlanningNumberEnabled");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "PlanningCaseVersions");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "PlanningCaseSiteVersions");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "PlanningCaseSites");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "PlanningCases");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "PlanningCaseVersions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "PlanningCaseSiteVersions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "PlanningCaseSites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "PlanningCases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BuildYear = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ItemNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    LocationCode = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PlanningId = table.Column<int>(type: "int", nullable: false),
                    Sku = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    WorkflowState = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", maxLength: 255, nullable: true),
                    eFormSdkFolderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Plannings_PlanningId",
                        column: x => x.PlanningId,
                        principalTable: "Plannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BuildYear = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ItemNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    LocationCode = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PlanningId = table.Column<int>(type: "int", nullable: false),
                    Sku = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    WorkflowState = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", maxLength: 255, nullable: true),
                    eFormSdkFolderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVersions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanningCases_ItemId",
                table: "PlanningCases",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PlanningId",
                table: "Items",
                column: "PlanningId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningCases_Items_ItemId",
                table: "PlanningCases",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql(@"UPDATE Items i
                                   INNER JOIN Plannings p ON p.Id = i.PlanningId
                                   SET i.ItemNumber = p.PlanningNumber;");

            migrationBuilder.Sql(@"UPDATE ItemVersions i
                                   INNER JOIN PlanningVersions p ON p.PlanningId = i.PlanningId
                                   SET i.ItemNumber = p.PlanningNumber;");

            migrationBuilder.Sql(@"UPDATE Items i
                                   INNER JOIN PlanningCases p ON p.ItemId = i.Id
                                   SET i.PlanningId = p.PlanningId;");

            migrationBuilder.Sql(@"UPDATE ItemVersions i
                                   INNER JOIN PlanningCaseVersions p ON p.ItemId = i.Id
                                   SET i.PlanningId = p.PlanningId;");

            migrationBuilder.Sql(@"UPDATE Items i
                                   INNER JOIN PlanningCaseSites p ON p.ItemId = i.Id
                                   SET i.PlanningId = p.PlanningId;");

            migrationBuilder.Sql(@"UPDATE ItemVersions i
                                   INNER JOIN PlanningCaseSiteVersions p ON p.ItemId = i.Id
                                   SET i.PlanningId = p.PlanningId;");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanningCases_Plannings_PlanningId",
                table: "PlanningCases");

            migrationBuilder.DropIndex(
                name: "IX_PlanningCases_PlanningId",
                table: "PlanningCases");

            migrationBuilder.DropColumn(
                name: "BuildYear",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "LocationCode",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "PlanningNumber",
                table: "PlanningVersions");

            migrationBuilder.RenameColumn(
                name: "PlanningNumberEnabled",
                table: "PlanningVersions",
                newName: "ItemNumberEnabled");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PlanningVersions");

            migrationBuilder.DropColumn(
                name: "BuildYear",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "LocationCode",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "PlanningNumber",
                table: "Plannings");

            migrationBuilder.RenameColumn(
                name: "PlanningNumberEnabled",
                table: "Plannings",
                newName: "ItemNumberEnabled");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Plannings");
            
            migrationBuilder.DropColumn(
                name: "PlanningId",
                table: "PlanningCaseVersions");

            migrationBuilder.DropColumn(
                name: "PlanningId",
                table: "PlanningCaseSiteVersions");

            migrationBuilder.DropColumn(
                name: "PlanningId",
                table: "PlanningCaseSites");

            migrationBuilder.DropColumn(
                name: "PlanningId",
                table: "PlanningCases");

        }
    }
}
