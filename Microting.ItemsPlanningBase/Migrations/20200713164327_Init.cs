using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var autoIdGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIdGenStrategyValue = SqlServerValueGenerationStrategy.IdentityColumn;

            // Setup for MySQL Provider
            if (migrationBuilder.ActiveProvider == "Pomelo.EntityFrameworkCore.MySql")
            {
                DbConfig.IsMySQL = true;
                autoIdGenStrategy = "MySql:ValueGenerationStrategy";
                autoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }

            migrationBuilder.CreateTable(
                name: "ItemVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Sku = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    ItemNumber = table.Column<string>(nullable: true),
                    LocationCode = table.Column<string>(nullable: true),
                    BuildYear = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    PlanningId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanningCases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    MicrotingSdkSiteId = table.Column<int>(nullable: false),
                    MicrotingSdkeFormId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    FieldStatus = table.Column<string>(nullable: true),
                    MicrotingSdkCaseId = table.Column<int>(nullable: false),
                    MicrotingSdkCaseDoneAt = table.Column<DateTime>(nullable: true),
                    NumberOfImages = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false),
                    SdkFieldValue1 = table.Column<string>(nullable: true),
                    SdkFieldValue2 = table.Column<string>(nullable: true),
                    SdkFieldValue3 = table.Column<string>(nullable: true),
                    SdkFieldValue4 = table.Column<string>(nullable: true),
                    SdkFieldValue5 = table.Column<string>(nullable: true),
                    SdkFieldValue6 = table.Column<string>(nullable: true),
                    SdkFieldValue7 = table.Column<string>(nullable: true),
                    SdkFieldValue8 = table.Column<string>(nullable: true),
                    SdkFieldValue9 = table.Column<string>(nullable: true),
                    SdkFieldValue10 = table.Column<string>(nullable: true),
                    DoneByUserId = table.Column<int>(nullable: false),
                    DoneByUserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningCases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanningCaseSites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    MicrotingSdkSiteId = table.Column<int>(nullable: false),
                    MicrotingSdkeFormId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    FieldStatus = table.Column<string>(nullable: true),
                    MicrotingSdkCaseId = table.Column<int>(nullable: false),
                    MicrotingSdkCaseDoneAt = table.Column<DateTime>(nullable: true),
                    NumberOfImages = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false),
                    SdkFieldValue1 = table.Column<string>(nullable: true),
                    SdkFieldValue2 = table.Column<string>(nullable: true),
                    SdkFieldValue3 = table.Column<string>(nullable: true),
                    SdkFieldValue4 = table.Column<string>(nullable: true),
                    SdkFieldValue5 = table.Column<string>(nullable: true),
                    SdkFieldValue6 = table.Column<string>(nullable: true),
                    SdkFieldValue7 = table.Column<string>(nullable: true),
                    SdkFieldValue8 = table.Column<string>(nullable: true),
                    SdkFieldValue9 = table.Column<string>(nullable: true),
                    SdkFieldValue10 = table.Column<string>(nullable: true),
                    DoneByUserId = table.Column<int>(nullable: false),
                    DoneByUserName = table.Column<string>(nullable: true),
                    PlanningCaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningCaseSites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanningCaseSiteVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    MicrotingSdkSiteId = table.Column<int>(nullable: false),
                    MicrotingSdkeFormId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    FieldStatus = table.Column<string>(nullable: true),
                    MicrotingSdkCaseId = table.Column<int>(nullable: false),
                    MicrotingSdkCaseDoneAt = table.Column<DateTime>(nullable: true),
                    NumberOfImages = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false),
                    PlanningCaseSiteId = table.Column<int>(nullable: false),
                    SdkFieldValue1 = table.Column<string>(nullable: true),
                    SdkFieldValue2 = table.Column<string>(nullable: true),
                    SdkFieldValue3 = table.Column<string>(nullable: true),
                    SdkFieldValue4 = table.Column<string>(nullable: true),
                    SdkFieldValue5 = table.Column<string>(nullable: true),
                    SdkFieldValue6 = table.Column<string>(nullable: true),
                    SdkFieldValue7 = table.Column<string>(nullable: true),
                    SdkFieldValue8 = table.Column<string>(nullable: true),
                    SdkFieldValue9 = table.Column<string>(nullable: true),
                    SdkFieldValue10 = table.Column<string>(nullable: true),
                    DoneByUserId = table.Column<int>(nullable: false),
                    DoneByUserName = table.Column<string>(nullable: true),
                    PlanningCaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningCaseSiteVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanningCaseVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    MicrotingSdkSiteId = table.Column<int>(nullable: false),
                    MicrotingSdkeFormId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    FieldStatus = table.Column<string>(nullable: true),
                    MicrotingSdkCaseId = table.Column<int>(nullable: false),
                    MicrotingSdkCaseDoneAt = table.Column<DateTime>(nullable: true),
                    NumberOfImages = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false),
                    PlanningCaseId = table.Column<int>(nullable: false),
                    SdkFieldValue1 = table.Column<string>(nullable: true),
                    SdkFieldValue2 = table.Column<string>(nullable: true),
                    SdkFieldValue3 = table.Column<string>(nullable: true),
                    SdkFieldValue4 = table.Column<string>(nullable: true),
                    SdkFieldValue5 = table.Column<string>(nullable: true),
                    SdkFieldValue6 = table.Column<string>(nullable: true),
                    SdkFieldValue7 = table.Column<string>(nullable: true),
                    SdkFieldValue8 = table.Column<string>(nullable: true),
                    SdkFieldValue9 = table.Column<string>(nullable: true),
                    SdkFieldValue10 = table.Column<string>(nullable: true),
                    DoneByUserId = table.Column<int>(nullable: false),
                    DoneByUserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningCaseVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plannings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RepeatEvery = table.Column<int>(nullable: false),
                    RepeatType = table.Column<int>(nullable: false),
                    RepeatUntil = table.Column<DateTime>(nullable: true),
                    DayOfWeek = table.Column<int>(nullable: true),
                    DayOfMonth = table.Column<int>(nullable: true),
                    LastExecutedTime = table.Column<DateTime>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    RelatedEFormId = table.Column<int>(nullable: false),
                    RelatedEFormName = table.Column<string>(nullable: true),
                    DeployedAtEnabled = table.Column<bool>(nullable: false),
                    DoneAtEnabled = table.Column<bool>(nullable: false),
                    DoneByUserNameEnabled = table.Column<bool>(nullable: false),
                    UploadedDataEnabled = table.Column<bool>(nullable: false),
                    LabelEnabled = table.Column<bool>(nullable: false),
                    DescriptionEnabled = table.Column<bool>(nullable: false),
                    SdkFieldEnabled1 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled2 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled3 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled4 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled5 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled6 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled7 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled8 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled9 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled10 = table.Column<bool>(nullable: false),
                    ItemNumberEnabled = table.Column<bool>(nullable: false),
                    LocationCodeEnabled = table.Column<bool>(nullable: false),
                    BuildYearEnabled = table.Column<bool>(nullable: false),
                    NumberOfImagesEnabled = table.Column<bool>(nullable: false),
                    TypeEnabled = table.Column<bool>(nullable: false),
                    SdkFieldId1 = table.Column<int>(nullable: true),
                    SdkFieldId2 = table.Column<int>(nullable: true),
                    SdkFieldId3 = table.Column<int>(nullable: true),
                    SdkFieldId4 = table.Column<int>(nullable: true),
                    SdkFieldId5 = table.Column<int>(nullable: true),
                    SdkFieldId6 = table.Column<int>(nullable: true),
                    SdkFieldId7 = table.Column<int>(nullable: true),
                    SdkFieldId8 = table.Column<int>(nullable: true),
                    SdkFieldId9 = table.Column<int>(nullable: true),
                    SdkFieldId10 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plannings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanningVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RepeatEvery = table.Column<int>(nullable: false),
                    RepeatType = table.Column<int>(nullable: false),
                    RepeatUntil = table.Column<DateTime>(nullable: true),
                    DayOfWeek = table.Column<int>(nullable: true),
                    DayOfMonth = table.Column<int>(nullable: true),
                    LastExecutedTime = table.Column<DateTime>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    RelatedEFormId = table.Column<int>(nullable: false),
                    RelatedEFormName = table.Column<string>(nullable: true),
                    PlanningId = table.Column<int>(nullable: false),
                    DeployedAtEnabled = table.Column<bool>(nullable: false),
                    DoneAtEnabled = table.Column<bool>(nullable: false),
                    DoneByUserNameEnabled = table.Column<bool>(nullable: false),
                    UploadedDataEnabled = table.Column<bool>(nullable: false),
                    LabelEnabled = table.Column<bool>(nullable: false),
                    DescriptionEnabled = table.Column<bool>(nullable: false),
                    SdkFieldEnabled1 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled2 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled3 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled4 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled5 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled6 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled7 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled8 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled9 = table.Column<bool>(nullable: false),
                    SdkFieldEnabled10 = table.Column<bool>(nullable: false),
                    ItemNumberEnabled = table.Column<bool>(nullable: false),
                    LocationCodeEnabled = table.Column<bool>(nullable: false),
                    BuildYearEnabled = table.Column<bool>(nullable: false),
                    TypeEnabled = table.Column<bool>(nullable: false),
                    NumberOfImagesEnabled = table.Column<bool>(nullable: false),
                    SdkFieldId1 = table.Column<int>(nullable: true),
                    SdkFieldId2 = table.Column<int>(nullable: true),
                    SdkFieldId3 = table.Column<int>(nullable: true),
                    SdkFieldId4 = table.Column<int>(nullable: true),
                    SdkFieldId5 = table.Column<int>(nullable: true),
                    SdkFieldId6 = table.Column<int>(nullable: true),
                    SdkFieldId7 = table.Column<int>(nullable: true),
                    SdkFieldId8 = table.Column<int>(nullable: true),
                    SdkFieldId9 = table.Column<int>(nullable: true),
                    SdkFieldId10 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PluginConfigurationValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginConfigurationValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PluginConfigurationValueVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginConfigurationValueVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PluginPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    PermissionName = table.Column<string>(nullable: true),
                    ClaimName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadedDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    PlanningCaseId = table.Column<int>(nullable: false),
                    Checksum = table.Column<string>(maxLength: 255, nullable: true),
                    Extension = table.Column<string>(maxLength: 255, nullable: true),
                    CurrentFile = table.Column<string>(maxLength: 255, nullable: true),
                    UploaderType = table.Column<string>(maxLength: 255, nullable: true),
                    FileLocation = table.Column<string>(maxLength: 255, nullable: true),
                    FileName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadedDataVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    PlanningCaseId = table.Column<int>(nullable: false),
                    Checksum = table.Column<string>(maxLength: 255, nullable: true),
                    Extension = table.Column<string>(maxLength: 255, nullable: true),
                    CurrentFile = table.Column<string>(maxLength: 255, nullable: true),
                    UploaderType = table.Column<string>(maxLength: 255, nullable: true),
                    FileLocation = table.Column<string>(maxLength: 255, nullable: true),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    UploadedDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedDataVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Sku = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    ItemNumber = table.Column<string>(nullable: true),
                    LocationCode = table.Column<string>(nullable: true),
                    BuildYear = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    PlanningId = table.Column<int>(nullable: false)
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
                name: "PluginGroupPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginGroupPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PluginGroupPermissions_PluginPermissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "PluginPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PluginGroupPermissionVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    PluginGroupPermissionId = table.Column<int>(nullable: false),
                    FK_PluginGroupPermissionVersions_PluginGroupPermissionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginGroupPermissionVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PluginGroupPermissionVersions_PluginGroupPermissions_FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                        column: x => x.FK_PluginGroupPermissionVersions_PluginGroupPermissionId,
                        principalTable: "PluginGroupPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PluginGroupPermissionVersions_PluginPermissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "PluginPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_PlanningId",
                table: "Items",
                column: "PlanningId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PluginGroupPermissions_PermissionId",
                table: "PluginGroupPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PluginGroupPermissionVersions_FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions",
                column: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PluginGroupPermissionVersions_PermissionId",
                table: "PluginGroupPermissionVersions",
                column: "PermissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ItemVersions");

            migrationBuilder.DropTable(
                name: "PlanningCases");

            migrationBuilder.DropTable(
                name: "PlanningCaseSites");

            migrationBuilder.DropTable(
                name: "PlanningCaseSiteVersions");

            migrationBuilder.DropTable(
                name: "PlanningCaseVersions");

            migrationBuilder.DropTable(
                name: "PlanningVersions");

            migrationBuilder.DropTable(
                name: "PluginConfigurationValues");

            migrationBuilder.DropTable(
                name: "PluginConfigurationValueVersions");

            migrationBuilder.DropTable(
                name: "PluginGroupPermissionVersions");

            migrationBuilder.DropTable(
                name: "UploadedDatas");

            migrationBuilder.DropTable(
                name: "UploadedDataVersions");

            migrationBuilder.DropTable(
                name: "Plannings");

            migrationBuilder.DropTable(
                name: "PluginGroupPermissions");

            migrationBuilder.DropTable(
                name: "PluginPermissions");
        }
    }
}
