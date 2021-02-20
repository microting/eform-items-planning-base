﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microting.ItemsPlanningBase.Infrastructure.Data;

namespace Microting.ItemsPlanningBase.Migrations
{
    [DbContext(typeof(ItemsPlanningPnDbContext))]
    [Migration("20200717124153_AddPlanningSites")]
    partial class AddPlanningSites
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            string autoIdGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            if (DbConfig.IsMySQL)
            {
                autoIdGenStrategy = "MySql:ValueGenerationStrategy";
                autoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }

            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("BuildYear");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.Property<string>("ItemNumber");

                    b.Property<string>("LocationCode");

                    b.Property<string>("Name");

                    b.Property<int>("PlanningId");

                    b.Property<string>("Sku");

                    b.Property<string>("Type");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("PlanningId")
                        .IsUnique();

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.ItemVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("BuildYear");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.Property<int>("ItemId");

                    b.Property<string>("ItemNumber");

                    b.Property<string>("LocationCode");

                    b.Property<string>("Name");

                    b.Property<int>("PlanningId");

                    b.Property<string>("Sku");

                    b.Property<string>("Type");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ItemVersions");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.Planning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<bool>("BuildYearEnabled");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int?>("DayOfMonth");

                    b.Property<int?>("DayOfWeek");

                    b.Property<bool>("DeployedAtEnabled");

                    b.Property<string>("Description");

                    b.Property<bool>("DescriptionEnabled");

                    b.Property<bool>("DoneAtEnabled");

                    b.Property<bool>("DoneByUserNameEnabled");

                    b.Property<bool>("Enabled");

                    b.Property<bool>("ItemNumberEnabled");

                    b.Property<bool>("LabelEnabled");

                    b.Property<DateTime?>("LastExecutedTime");

                    b.Property<bool>("LocationCodeEnabled");

                    b.Property<string>("Name");

                    b.Property<bool>("NumberOfImagesEnabled");

                    b.Property<int>("RelatedEFormId");

                    b.Property<string>("RelatedEFormName");

                    b.Property<int>("RepeatEvery");

                    b.Property<int>("RepeatType");

                    b.Property<DateTime?>("RepeatUntil");

                    b.Property<bool>("SdkFieldEnabled1");

                    b.Property<bool>("SdkFieldEnabled10");

                    b.Property<bool>("SdkFieldEnabled2");

                    b.Property<bool>("SdkFieldEnabled3");

                    b.Property<bool>("SdkFieldEnabled4");

                    b.Property<bool>("SdkFieldEnabled5");

                    b.Property<bool>("SdkFieldEnabled6");

                    b.Property<bool>("SdkFieldEnabled7");

                    b.Property<bool>("SdkFieldEnabled8");

                    b.Property<bool>("SdkFieldEnabled9");

                    b.Property<int?>("SdkFieldId1");

                    b.Property<int?>("SdkFieldId10");

                    b.Property<int?>("SdkFieldId2");

                    b.Property<int?>("SdkFieldId3");

                    b.Property<int?>("SdkFieldId4");

                    b.Property<int?>("SdkFieldId5");

                    b.Property<int?>("SdkFieldId6");

                    b.Property<int?>("SdkFieldId7");

                    b.Property<int?>("SdkFieldId8");

                    b.Property<int?>("SdkFieldId9");

                    b.Property<bool>("TypeEnabled");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<bool>("UploadedDataEnabled");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Plannings");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.PlanningCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("DoneByUserId");

                    b.Property<string>("DoneByUserName");

                    b.Property<string>("FieldStatus");

                    b.Property<int>("ItemId");

                    b.Property<string>("Location");

                    b.Property<DateTime?>("MicrotingSdkCaseDoneAt");

                    b.Property<int>("MicrotingSdkCaseId");

                    b.Property<int>("MicrotingSdkSiteId");

                    b.Property<int>("MicrotingSdkeFormId");

                    b.Property<int>("NumberOfImages");

                    b.Property<string>("SdkFieldValue1");

                    b.Property<string>("SdkFieldValue10");

                    b.Property<string>("SdkFieldValue2");

                    b.Property<string>("SdkFieldValue3");

                    b.Property<string>("SdkFieldValue4");

                    b.Property<string>("SdkFieldValue5");

                    b.Property<string>("SdkFieldValue6");

                    b.Property<string>("SdkFieldValue7");

                    b.Property<string>("SdkFieldValue8");

                    b.Property<string>("SdkFieldValue9");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PlanningCases");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.PlanningCaseSite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("DoneByUserId");

                    b.Property<string>("DoneByUserName");

                    b.Property<string>("FieldStatus");

                    b.Property<int>("ItemId");

                    b.Property<string>("Location");

                    b.Property<DateTime?>("MicrotingSdkCaseDoneAt");

                    b.Property<int>("MicrotingSdkCaseId");

                    b.Property<int>("MicrotingSdkSiteId");

                    b.Property<int>("MicrotingSdkeFormId");

                    b.Property<int>("NumberOfImages");

                    b.Property<int>("PlanningCaseId");

                    b.Property<string>("SdkFieldValue1");

                    b.Property<string>("SdkFieldValue10");

                    b.Property<string>("SdkFieldValue2");

                    b.Property<string>("SdkFieldValue3");

                    b.Property<string>("SdkFieldValue4");

                    b.Property<string>("SdkFieldValue5");

                    b.Property<string>("SdkFieldValue6");

                    b.Property<string>("SdkFieldValue7");

                    b.Property<string>("SdkFieldValue8");

                    b.Property<string>("SdkFieldValue9");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PlanningCaseSites");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.PlanningCaseSiteVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("DoneByUserId");

                    b.Property<string>("DoneByUserName");

                    b.Property<string>("FieldStatus");

                    b.Property<int>("ItemId");

                    b.Property<string>("Location");

                    b.Property<DateTime?>("MicrotingSdkCaseDoneAt");

                    b.Property<int>("MicrotingSdkCaseId");

                    b.Property<int>("MicrotingSdkSiteId");

                    b.Property<int>("MicrotingSdkeFormId");

                    b.Property<int>("NumberOfImages");

                    b.Property<int>("PlanningCaseId");

                    b.Property<int>("PlanningCaseSiteId");

                    b.Property<string>("SdkFieldValue1");

                    b.Property<string>("SdkFieldValue10");

                    b.Property<string>("SdkFieldValue2");

                    b.Property<string>("SdkFieldValue3");

                    b.Property<string>("SdkFieldValue4");

                    b.Property<string>("SdkFieldValue5");

                    b.Property<string>("SdkFieldValue6");

                    b.Property<string>("SdkFieldValue7");

                    b.Property<string>("SdkFieldValue8");

                    b.Property<string>("SdkFieldValue9");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PlanningCaseSiteVersions");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.PlanningCaseVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("DoneByUserId");

                    b.Property<string>("DoneByUserName");

                    b.Property<string>("FieldStatus");

                    b.Property<int>("ItemId");

                    b.Property<string>("Location");

                    b.Property<DateTime?>("MicrotingSdkCaseDoneAt");

                    b.Property<int>("MicrotingSdkCaseId");

                    b.Property<int>("MicrotingSdkSiteId");

                    b.Property<int>("MicrotingSdkeFormId");

                    b.Property<int>("NumberOfImages");

                    b.Property<int>("PlanningCaseId");

                    b.Property<string>("SdkFieldValue1");

                    b.Property<string>("SdkFieldValue10");

                    b.Property<string>("SdkFieldValue2");

                    b.Property<string>("SdkFieldValue3");

                    b.Property<string>("SdkFieldValue4");

                    b.Property<string>("SdkFieldValue5");

                    b.Property<string>("SdkFieldValue6");

                    b.Property<string>("SdkFieldValue7");

                    b.Property<string>("SdkFieldValue8");

                    b.Property<string>("SdkFieldValue9");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PlanningCaseVersions");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.PlanningSite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("PlanningId");

                    b.Property<int>("SiteId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("PlanningId");

                    b.ToTable("PlanningSites");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.PlanningSiteVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("PlanningId");

                    b.Property<int>("PlanningSiteId");

                    b.Property<int>("SiteId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PlanningSiteVersions");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.PlanningVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<bool>("BuildYearEnabled");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int?>("DayOfMonth");

                    b.Property<int?>("DayOfWeek");

                    b.Property<bool>("DeployedAtEnabled");

                    b.Property<string>("Description");

                    b.Property<bool>("DescriptionEnabled");

                    b.Property<bool>("DoneAtEnabled");

                    b.Property<bool>("DoneByUserNameEnabled");

                    b.Property<bool>("Enabled");

                    b.Property<bool>("ItemNumberEnabled");

                    b.Property<bool>("LabelEnabled");

                    b.Property<DateTime?>("LastExecutedTime");

                    b.Property<bool>("LocationCodeEnabled");

                    b.Property<string>("Name");

                    b.Property<bool>("NumberOfImagesEnabled");

                    b.Property<int>("PlanningId");

                    b.Property<int>("RelatedEFormId");

                    b.Property<string>("RelatedEFormName");

                    b.Property<int>("RepeatEvery");

                    b.Property<int>("RepeatType");

                    b.Property<DateTime?>("RepeatUntil");

                    b.Property<bool>("SdkFieldEnabled1");

                    b.Property<bool>("SdkFieldEnabled10");

                    b.Property<bool>("SdkFieldEnabled2");

                    b.Property<bool>("SdkFieldEnabled3");

                    b.Property<bool>("SdkFieldEnabled4");

                    b.Property<bool>("SdkFieldEnabled5");

                    b.Property<bool>("SdkFieldEnabled6");

                    b.Property<bool>("SdkFieldEnabled7");

                    b.Property<bool>("SdkFieldEnabled8");

                    b.Property<bool>("SdkFieldEnabled9");

                    b.Property<int?>("SdkFieldId1");

                    b.Property<int?>("SdkFieldId10");

                    b.Property<int?>("SdkFieldId2");

                    b.Property<int?>("SdkFieldId3");

                    b.Property<int?>("SdkFieldId4");

                    b.Property<int?>("SdkFieldId5");

                    b.Property<int?>("SdkFieldId6");

                    b.Property<int?>("SdkFieldId7");

                    b.Property<int?>("SdkFieldId8");

                    b.Property<int?>("SdkFieldId9");

                    b.Property<bool>("TypeEnabled");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<bool>("UploadedDataEnabled");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PlanningVersions");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.UploadedData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("Checksum")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("CurrentFile")
                        .HasMaxLength(255);

                    b.Property<string>("Extension")
                        .HasMaxLength(255);

                    b.Property<string>("FileLocation")
                        .HasMaxLength(255);

                    b.Property<string>("FileName")
                        .HasMaxLength(255);

                    b.Property<int>("PlanningCaseId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("UploaderType")
                        .HasMaxLength(255);

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("UploadedDatas");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.UploadedDataVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("Checksum")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("CurrentFile")
                        .HasMaxLength(255);

                    b.Property<string>("Extension")
                        .HasMaxLength(255);

                    b.Property<string>("FileLocation")
                        .HasMaxLength(255);

                    b.Property<string>("FileName")
                        .HasMaxLength(255);

                    b.Property<int>("PlanningCaseId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("UploadedDataId");

                    b.Property<string>("UploaderType")
                        .HasMaxLength(255);

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("UploadedDataVersions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginConfigurationValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("Value");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginConfigurationValues");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginConfigurationValueVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("Value");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginConfigurationValueVersions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsEnabled");

                    b.Property<int>("PermissionId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("PluginGroupPermissions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermissionVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int?>("FK_PluginGroupPermissionVersions_PluginGroupPermissionId");

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsEnabled");

                    b.Property<int>("PermissionId");

                    b.Property<int>("PluginGroupPermissionId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("FK_PluginGroupPermissionVersions_PluginGroupPermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("PluginGroupPermissionVersions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", autoIdGenStrategyValue);

                    b.Property<string>("ClaimName");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("PermissionName");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginPermissions");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.Item", b =>
                {
                    b.HasOne("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.Planning")
                        .WithOne("Item")
                        .HasForeignKey("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.Item", "PlanningId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.PlanningSite", b =>
                {
                    b.HasOne("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.Planning", "Planning")
                        .WithMany()
                        .HasForeignKey("PlanningId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermission", b =>
                {
                    b.HasOne("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginPermission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermissionVersion", b =>
                {
                    b.HasOne("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermission", "PluginGroupPermission")
                        .WithMany()
                        .HasForeignKey("FK_PluginGroupPermissionVersions_PluginGroupPermissionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginPermission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
