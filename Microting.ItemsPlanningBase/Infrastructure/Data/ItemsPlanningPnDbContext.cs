/*
The MIT License (MIT)

Copyright (c) 2007 - 2019 Microting A/S

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using Microsoft.EntityFrameworkCore;
using Microting.eFormApi.BasePn.Abstractions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Entities;
using Microting.ItemsPlanningBase.Infrastructure.Data.Entities;

namespace Microting.ItemsPlanningBase.Infrastructure.Data
{
    public class ItemsPlanningPnDbContext: DbContext, IPluginDbContext
    {
        public ItemsPlanningPnDbContext() { }

        public ItemsPlanningPnDbContext(DbContextOptions<ItemsPlanningPnDbContext> options) : base(options)
        {
        }

        public DbSet<Planning> Plannings { get; set; }
        public DbSet<PlanningVersion> PlanningVersions { get; set; }
        public DbSet<UploadedData> UploadedDatas { get; set; }
        public DbSet<UploadedDataVersion> UploadedDataVersions { get; set; }
        public DbSet<PlanningCase> PlanningCases { get; set; }
        public DbSet<PlanningCaseVersion> PlanningCaseVersions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemVersion> ItemVersions { get; set;}
        public DbSet<PlanningCaseSite> PlanningCaseSites { get; set; }
        public DbSet<PlanningCaseSiteVersion> PlanningCaseSiteVersions { get; set; }
        public DbSet<PlanningSite> PlanningSites { get; set; }
        public DbSet<PlanningSiteVersion> PlanningSiteVersions { get; set; }
        public DbSet<PlanningTag> PlanningTags { get; set; }
        public DbSet<PlanningTagVersion> PlanningTagVersions { get; set; }
        public DbSet<PlanningsTags> PlanningsTags { get; set; }
        public DbSet<PlanningsTagsVersion> PlanningsTagsVersions { get; set; }

        // common tables
        public DbSet<PluginConfigurationValue> PluginConfigurationValues { get; set; }
        public DbSet<PluginConfigurationValueVersion> PluginConfigurationValueVersions { get; set; }
        public DbSet<PluginPermission> PluginPermissions { get; set; }
        public DbSet<PluginGroupPermission> PluginGroupPermissions { get; set; }
        public DbSet<PluginGroupPermissionVersion> PluginGroupPermissionVersions { get; set; }
        public DbSet<PlaningNameTranslations> PlaningNameTranslations { get; set; }
        public DbSet<PlaningNameTranslationsVersion> PlaningNameTranslationsVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<PluginGroupPermissionVersion>()
            //    .HasOne<PluginGroupPermission>(x => x.PluginGroupPermissionId)
            //    .WithMany()
            //    .HasForeignKey("FK_PluginGroupPermissionVersions_PluginGroupPermissionId")
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}