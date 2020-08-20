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

namespace Microting.ItemsPlanningBase.Infrastructure.Data.Entities
{
    using System.Collections.Generic;
    using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
    using System;
    using System.Threading.Tasks;
    using Enums;
    using Microsoft.EntityFrameworkCore;
    using Microting.eForm.Infrastructure.Constants;

    public class Planning : BaseEntity
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public int RepeatEvery { get; set; }
        
        public RepeatType RepeatType { get; set; }
        
        public DateTime? RepeatUntil { get; set; }
        
        public DayOfWeek? DayOfWeek { get; set; }
        
        public int? DayOfMonth { get; set; }
        
        public DateTime? LastExecutedTime { get; set; }

        public bool Enabled { get; set; }
        
        public int RelatedEFormId { get; set; }
        
        public string RelatedEFormName { get; set; }
        
        public bool DeployedAtEnabled { get; set; }
        
        public bool DoneAtEnabled { get; set; }
        
        public bool DoneByUserNameEnabled { get; set; }
        
        public bool UploadedDataEnabled { get; set; }
        
        public bool LabelEnabled { get; set; }
        
        public bool DescriptionEnabled { get; set; }
        
        public bool ItemNumberEnabled { get; set; }
        
        public bool LocationCodeEnabled { get; set; }
        
        public bool BuildYearEnabled { get; set; }
        
        public bool NumberOfImagesEnabled { get; set; }
        
        public bool TypeEnabled { get; set; }

        public int? FolderId { get; set; }

        public virtual Item Item { get; set; } = new Item();

        public string SdkFolderName { get; set; }

        public virtual List<PlanningSite> PlanningSites { get; set; }
            = new List<PlanningSite>();

        public async Task Create(ItemsPlanningPnDbContext dbContext)
        {
            WorkflowState = Constants.WorkflowStates.Created;
            Version = 1;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            await dbContext.Plannings.AddAsync(this);
            await dbContext.SaveChangesAsync();

            await dbContext.PlanningVersions.AddAsync(MapItemListVersion(this));
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(ItemsPlanningPnDbContext dbContext)
        {
            var planning = await dbContext.Plannings.FirstOrDefaultAsync(x => x.Id == Id);

            if (planning == null)
            {
                throw new NullReferenceException($"Could not find planning with id: {Id}");
            }

            planning.Name = Name;
            planning.Description = Description;
            planning.Enabled = Enabled;
            planning.RepeatUntil = RepeatUntil;
            planning.RelatedEFormId = RelatedEFormId;
            planning.RelatedEFormName = RelatedEFormName;
            planning.RepeatEvery = RepeatEvery;
            planning.DayOfWeek = DayOfWeek;
            planning.RepeatType = RepeatType;
            planning.DayOfMonth = DayOfMonth;
            planning.WorkflowState = WorkflowState;
            planning.UpdatedByUserId = UpdatedByUserId;
            planning.LastExecutedTime = LastExecutedTime;
            planning.DoneAtEnabled = DoneAtEnabled;
            planning.DeployedAtEnabled = DeployedAtEnabled;
            planning.DoneByUserNameEnabled = DoneByUserNameEnabled;
            planning.UploadedDataEnabled = UploadedDataEnabled;
            planning.LabelEnabled = LabelEnabled;
            planning.DescriptionEnabled = DescriptionEnabled;
            planning.ItemNumberEnabled = ItemNumberEnabled;
            planning.LocationCodeEnabled = LocationCodeEnabled;
            planning.BuildYearEnabled = BuildYearEnabled;
            planning.TypeEnabled = TypeEnabled;
            planning.NumberOfImagesEnabled = NumberOfImagesEnabled;
            planning.FolderId = FolderId;
            planning.SdkFolderName = SdkFolderName;

            if (dbContext.ChangeTracker.HasChanges())
            {
                planning.UpdatedAt = DateTime.UtcNow;
                planning.Version += 1;

                await dbContext.PlanningVersions.AddAsync(MapItemListVersion(planning));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(ItemsPlanningPnDbContext dbContext)
        {
            Planning planning = await dbContext.Plannings.FirstOrDefaultAsync(x => x.Id == Id);

            if (planning == null)
            {
                throw new NullReferenceException($"Could not find planning with id: {Id}");
            }

            planning.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                planning.UpdatedAt = DateTime.UtcNow;
                planning.Version += 1;

                await dbContext.PlanningVersions.AddAsync(MapItemListVersion(planning));
                await dbContext.SaveChangesAsync();
            }
        }

        private PlanningVersion MapItemListVersion(Planning planning)
        {
            var planningVersion = new PlanningVersion
            {
                Name = planning.Name,
                Description = planning.Description,
                Enabled = planning.Enabled,
                RepeatUntil = planning.RepeatUntil,
                RelatedEFormId = planning.RelatedEFormId,
                RelatedEFormName = planning.RelatedEFormName,
                DayOfWeek = planning.DayOfWeek,
                RepeatEvery = planning.RepeatEvery,
                RepeatType = planning.RepeatType,
                DayOfMonth = planning.DayOfMonth,
                PlanningId = planning.Id,
                Version = planning.Version,
                CreatedAt = planning.CreatedAt,
                WorkflowState = planning.WorkflowState,
                UpdatedAt = planning.UpdatedAt,
                UpdatedByUserId = planning.UpdatedByUserId,
                CreatedByUserId = planning.CreatedByUserId,
                LastExecutedTime = planning.LastExecutedTime,
                DoneAtEnabled = planning.DoneAtEnabled,
                DeployedAtEnabled = planning.DeployedAtEnabled,
                DoneByUserNameEnabled = planning.DoneByUserNameEnabled,
                UploadedDataEnabled = planning.UploadedDataEnabled,
                LabelEnabled = planning.LabelEnabled,
                DescriptionEnabled = planning.DescriptionEnabled,
                ItemNumberEnabled = planning.ItemNumberEnabled,
                LocationCodeEnabled = planning.LocationCodeEnabled,
                BuildYearEnabled = planning.BuildYearEnabled,
                NumberOfImagesEnabled = planning.NumberOfImagesEnabled,
                TypeEnabled = planning.TypeEnabled,
                SdkFieldId1 = planning.SdkFieldId1,
                SdkFieldId2 = planning.SdkFieldId2,
                SdkFieldId3 = planning.SdkFieldId3,
                SdkFieldId4 = planning.SdkFieldId4,
                SdkFieldId5 = planning.SdkFieldId5,
                SdkFieldId6 = planning.SdkFieldId6,
                SdkFieldId7 = planning.SdkFieldId7,
                SdkFieldId8 = planning.SdkFieldId8,
                SdkFieldId9 = planning.SdkFieldId9,
                SdkFieldId10 = planning.SdkFieldId10,
                FolderId = planning.FolderId,
                SdkFolderName = planning.SdkFolderName
            };

            return planningVersion;
        }
    }
}