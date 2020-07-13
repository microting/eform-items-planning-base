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

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.ItemsPlanningBase.Infrastructure.Data.Entities
{
    public class PlanningCaseSite : BaseEntity
    {
        public int MicrotingSdkSiteId { get; set; }

        public int MicrotingSdkeFormId { get; set; }

        public int Status { get; set; }
        
        public string FieldStatus { get; set; }

        public int MicrotingSdkCaseId { get; set; }
        
        public DateTime? MicrotingSdkCaseDoneAt { get; set; }
        
        public int NumberOfImages { get; set; }
        
        public string Comment { get; set; }
        
        public string Location { get; set; }

        public int ItemId { get; set; }
        
        public string SdkFieldValue1 { get; set; }
        
        public string SdkFieldValue2 { get; set; }
        
        public string SdkFieldValue3 { get; set; }
        
        public string SdkFieldValue4 { get; set; }
        
        public string SdkFieldValue5 { get; set; }
        
        public string SdkFieldValue6 { get; set; }
        
        public string SdkFieldValue7 { get; set; }
        
        public string SdkFieldValue8 { get; set; }
        
        public string SdkFieldValue9 { get; set; }
        
        public string SdkFieldValue10 { get; set; }
        
        public int DoneByUserId { get; set; }
        
        public string DoneByUserName { get; set; }
        
        [ForeignKey("PlanningCase")]
        public int PlanningCaseId { get; set; }

        public async Task Create(ItemsPlanningPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            await dbContext.PlanningCaseSites.AddAsync(this);
            await dbContext.SaveChangesAsync();

            await dbContext.PlanningCaseSiteVersions.AddAsync(MapVersion(this));
            await dbContext.SaveChangesAsync();

        }

        public async Task Update(ItemsPlanningPnDbContext dbContext)
        {
            PlanningCaseSite planningCaseSite = await dbContext.PlanningCaseSites.FirstOrDefaultAsync(x => x.Id == Id);

            if (planningCaseSite == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            planningCaseSite.MicrotingSdkSiteId = MicrotingSdkSiteId;
            planningCaseSite.MicrotingSdkeFormId = MicrotingSdkeFormId;
            planningCaseSite.Status = Status;
            planningCaseSite.FieldStatus = FieldStatus;
            planningCaseSite.MicrotingSdkCaseId = MicrotingSdkCaseId;
            planningCaseSite.ItemId = ItemId;
            planningCaseSite.MicrotingSdkCaseDoneAt = MicrotingSdkCaseDoneAt;
            planningCaseSite.WorkflowState = WorkflowState;
            planningCaseSite.NumberOfImages = NumberOfImages;
            planningCaseSite.Comment = Comment;
            planningCaseSite.Location = Location;
            planningCaseSite.SdkFieldValue1 = SdkFieldValue1;
            planningCaseSite.SdkFieldValue2 = SdkFieldValue2;
            planningCaseSite.SdkFieldValue3 = SdkFieldValue3;
            planningCaseSite.SdkFieldValue4 = SdkFieldValue4;
            planningCaseSite.SdkFieldValue5 = SdkFieldValue5;
            planningCaseSite.SdkFieldValue6 = SdkFieldValue6;
            planningCaseSite.SdkFieldValue7 = SdkFieldValue7;
            planningCaseSite.SdkFieldValue8 = SdkFieldValue8;
            planningCaseSite.SdkFieldValue9 = SdkFieldValue9;
            planningCaseSite.SdkFieldValue10 = SdkFieldValue10;
            planningCaseSite.DoneByUserId = DoneByUserId;
            planningCaseSite.DoneByUserName = DoneByUserName;
            planningCaseSite.PlanningCaseId = PlanningCaseId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                planningCaseSite.UpdatedAt = DateTime.UtcNow;
                planningCaseSite.Version += 1;

                await dbContext.PlanningCaseSiteVersions.AddAsync(MapVersion(planningCaseSite));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(ItemsPlanningPnDbContext dbContext)
        {
            PlanningCaseSite planningCaseSite = await dbContext.PlanningCaseSites.FirstOrDefaultAsync(x => x.Id == Id);

            if (planningCaseSite == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            planningCaseSite.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                planningCaseSite.UpdatedAt = DateTime.UtcNow;
                planningCaseSite.Version += 1;

                await dbContext.PlanningCaseSiteVersions.AddAsync(MapVersion(planningCaseSite));
                await dbContext.SaveChangesAsync();
            }
        }

        private PlanningCaseSiteVersion MapVersion(PlanningCaseSite planningCaseSite)
        {
            PlanningCaseSiteVersion planningCaseVersion = new PlanningCaseSiteVersion
            {
                MicrotingSdkSiteId = planningCaseSite.MicrotingSdkSiteId,
                MicrotingSdkeFormId = planningCaseSite.MicrotingSdkeFormId,
                Status = planningCaseSite.Status,
                FieldStatus = planningCaseSite.FieldStatus,
                MicrotingSdkCaseId = planningCaseSite.MicrotingSdkCaseId,
                ItemId = planningCaseSite.ItemId,
                MicrotingSdkCaseDoneAt = planningCaseSite.MicrotingSdkCaseDoneAt,
                NumberOfImages = planningCaseSite.NumberOfImages,
                Comment = planningCaseSite.Comment,
                Location = planningCaseSite.Location,
                PlanningCaseId = planningCaseSite.Id,
                Version = planningCaseSite.Version,
                CreatedAt = planningCaseSite.CreatedAt,
                CreatedByUserId = planningCaseSite.CreatedByUserId,
                UpdatedAt = planningCaseSite.UpdatedAt,
                UpdatedByUserId = planningCaseSite.UpdatedByUserId,
                WorkflowState = planningCaseSite.WorkflowState,
                SdkFieldValue1 = planningCaseSite.SdkFieldValue1,
                SdkFieldValue2 = planningCaseSite.SdkFieldValue2,
                SdkFieldValue3 = planningCaseSite.SdkFieldValue3,
                SdkFieldValue4 = planningCaseSite.SdkFieldValue4,
                SdkFieldValue5 = planningCaseSite.SdkFieldValue5,
                SdkFieldValue6 = planningCaseSite.SdkFieldValue6,
                SdkFieldValue7 = planningCaseSite.SdkFieldValue7,
                SdkFieldValue8 = planningCaseSite.SdkFieldValue8,
                SdkFieldValue9 = planningCaseSite.SdkFieldValue9,
                SdkFieldValue10 = planningCaseSite.SdkFieldValue10,
                DoneByUserId = planningCaseSite.DoneByUserId,
                DoneByUserName = planningCaseSite.DoneByUserName,
                PlanningCaseSiteId = planningCaseSite.PlanningCaseId,
            };

            return planningCaseVersion;
        }
        
    }
}