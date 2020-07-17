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
    using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microting.eForm.Infrastructure.Constants;

    public class PlanningSite : BaseEntity
    {
        public int SiteId { get; set; }
        public int PlanningId { get; set; }
        public virtual Planning Planning { get; set; }

        public async Task Create(ItemsPlanningPnDbContext dbContext)
        {
            WorkflowState = Constants.WorkflowStates.Created;
            Version = 1;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            await dbContext.PlanningSites.AddAsync(this);
            await dbContext.SaveChangesAsync();

            await dbContext.PlanningSiteVersions.AddAsync(MapItemListVersion(this));
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(ItemsPlanningPnDbContext dbContext)
        {
            var planningSite = await dbContext.PlanningSites.FirstOrDefaultAsync(x => x.Id == Id);

            if (planningSite == null)
            {
                throw new NullReferenceException($"Could not find planning site with id: {Id}");
            }

            planningSite.PlanningId = PlanningId;
            planningSite.SiteId = SiteId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                planningSite.UpdatedAt = DateTime.UtcNow;
                planningSite.Version += 1;

                await dbContext.PlanningSiteVersions.AddAsync(MapItemListVersion(planningSite));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(ItemsPlanningPnDbContext dbContext)
        {
            var planningSite = await dbContext.PlanningSites.FirstOrDefaultAsync(x => x.Id == Id);

            if (planningSite == null)
            {
                throw new NullReferenceException($"Could not find planning site with id: {Id}");
            }

            planningSite.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                planningSite.UpdatedAt = DateTime.UtcNow;
                planningSite.Version += 1;

                await dbContext.PlanningSiteVersions.AddAsync(MapItemListVersion(planningSite));
                await dbContext.SaveChangesAsync();
            }
        }

        private PlanningSiteVersion MapItemListVersion(PlanningSite planningSite)
        {
            var planningSiteVersion = new PlanningSiteVersion
            {
                PlanningId = planningSite.PlanningId,
                Version = planningSite.Version,
                CreatedAt = planningSite.CreatedAt,
                WorkflowState = planningSite.WorkflowState,
                UpdatedAt = planningSite.UpdatedAt,
                UpdatedByUserId = planningSite.UpdatedByUserId,
                CreatedByUserId = planningSite.CreatedByUserId,
                SiteId = planningSite.SiteId,
                PlanningSiteId = planningSite.Id,
            };

            return planningSiteVersion;
        }
    }
}