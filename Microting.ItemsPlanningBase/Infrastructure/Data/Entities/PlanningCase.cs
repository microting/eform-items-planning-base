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
using System.Threading.Tasks;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;

namespace Microting.ItemsPlanningBase.Infrastructure.Data.Entities
{
    public class PlanningCase : BaseEntity
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
        public virtual Item Item { get; set; }
        
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

        public async Task Create(ItemsPlanningPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            await dbContext.PlanningCases.AddAsync(this);
            await dbContext.SaveChangesAsync();

            await dbContext.PlanningCaseVersions.AddAsync(MapVersion(this));
            await dbContext.SaveChangesAsync();

        }

        public async Task Update(ItemsPlanningPnDbContext dbContext)
        {
            PlanningCase planningCase = await dbContext.PlanningCases.FirstOrDefaultAsync(x => x.Id == Id);

            if (planningCase == null)
            {
                throw new NullReferenceException($"Could not find planning case with id: {Id}");
            }

            planningCase.MicrotingSdkSiteId = MicrotingSdkSiteId;
            planningCase.MicrotingSdkeFormId = MicrotingSdkeFormId;
            planningCase.Status = Status;
            planningCase.FieldStatus = FieldStatus;
            planningCase.MicrotingSdkCaseId = MicrotingSdkCaseId;
            planningCase.ItemId = ItemId;
            planningCase.MicrotingSdkCaseDoneAt = MicrotingSdkCaseDoneAt;
            planningCase.WorkflowState = WorkflowState;
            planningCase.NumberOfImages = NumberOfImages;
            planningCase.Comment = Comment;
            planningCase.Location = Location;
            planningCase.SdkFieldValue1 = SdkFieldValue1;
            planningCase.SdkFieldValue2 = SdkFieldValue2;
            planningCase.SdkFieldValue3 = SdkFieldValue3;
            planningCase.SdkFieldValue4 = SdkFieldValue4;
            planningCase.SdkFieldValue5 = SdkFieldValue5;
            planningCase.SdkFieldValue6 = SdkFieldValue6;
            planningCase.SdkFieldValue7 = SdkFieldValue7;
            planningCase.SdkFieldValue8 = SdkFieldValue8;
            planningCase.SdkFieldValue9 = SdkFieldValue9;
            planningCase.SdkFieldValue10 = SdkFieldValue10;
            planningCase.DoneByUserId = DoneByUserId;
            planningCase.DoneByUserName = DoneByUserName;

            if (dbContext.ChangeTracker.HasChanges())
            {
                planningCase.UpdatedAt = DateTime.UtcNow;
                planningCase.Version += 1;

                await dbContext.PlanningCaseVersions.AddAsync(MapVersion(planningCase));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(ItemsPlanningPnDbContext dbContext)
        {
            PlanningCase planningCase = await dbContext.PlanningCases.FirstOrDefaultAsync(x => x.Id == Id);

            if (planningCase == null)
            {
                throw new NullReferenceException($"Could not find planning case with id: {Id}");
            }

            planningCase.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                planningCase.UpdatedAt = DateTime.UtcNow;
                planningCase.Version += 1;

                await dbContext.PlanningCaseVersions.AddAsync(MapVersion(planningCase));
                await dbContext.SaveChangesAsync();
            }
        }

        private PlanningCaseVersion MapVersion(PlanningCase item)
        {
            PlanningCaseVersion itemCaseVersion = new PlanningCaseVersion
            {
                MicrotingSdkSiteId = item.MicrotingSdkSiteId,
                MicrotingSdkeFormId = item.MicrotingSdkeFormId,
                Status = item.Status,
                FieldStatus = item.FieldStatus,
                MicrotingSdkCaseId = item.MicrotingSdkCaseId,
                ItemId = item.ItemId,
                MicrotingSdkCaseDoneAt = item.MicrotingSdkCaseDoneAt,
                NumberOfImages = item.NumberOfImages,
                Comment = item.Comment,
                Location = item.Location,
                PlanningCaseId = item.Id,
                Version = item.Version,
                CreatedAt = item.CreatedAt,
                CreatedByUserId = item.CreatedByUserId,
                UpdatedAt = item.UpdatedAt,
                UpdatedByUserId = item.UpdatedByUserId,
                WorkflowState = item.WorkflowState,
                SdkFieldValue1 = item.SdkFieldValue1,
                SdkFieldValue2 = item.SdkFieldValue2,
                SdkFieldValue3 = item.SdkFieldValue3,
                SdkFieldValue4 = item.SdkFieldValue4,
                SdkFieldValue5 = item.SdkFieldValue5,
                SdkFieldValue6 = item.SdkFieldValue6,
                SdkFieldValue7 = item.SdkFieldValue7,
                SdkFieldValue8 = item.SdkFieldValue8,
                SdkFieldValue9 = item.SdkFieldValue9,
                SdkFieldValue10 = item.SdkFieldValue10,
                DoneByUserId = item.DoneByUserId,
                DoneByUserName = item.DoneByUserName,
            };

            return itemCaseVersion;
        }
    }
}