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
    public class Item : BaseEntity
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public string ItemNumber { get; set; }
        public string LocationCode { get; set; }
        public string BuildYear { get; set; }
        public string Type { get; set; }
        public int eFormSdkFolderId { get; set; }

        public int PlanningId { get; set; }
        public virtual Planning Planning { get; set; }

        public async Task Save(ItemsPlanningPnDbContext dbContext)
        {
            Item item = new Item
            {
                Sku = Sku,
                Name = Name,
                Description = Description,
                Enabled = Enabled,
                ItemNumber = ItemNumber,
                LocationCode = LocationCode,
                PlanningId = PlanningId,
                BuildYear = BuildYear,
                Type = Type,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created,
                UpdatedByUserId = UpdatedByUserId,
                CreatedByUserId = CreatedByUserId,
                eFormSdkFolderId = eFormSdkFolderId
            };

            await dbContext.Items.AddAsync(item);
            await dbContext.SaveChangesAsync();

            await dbContext.ItemVersions.AddAsync(MapItemVersion(item));
            await dbContext.SaveChangesAsync();

            Id = item.Id;
        }

        public async Task Update(ItemsPlanningPnDbContext dbContext)
        {
            Item item = await dbContext.Items.FirstOrDefaultAsync(x => x.Id == Id);

            if (item == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            item.Sku = Sku;
            item.Name = Name;
            item.Description = Description;
            item.WorkflowState = WorkflowState;
            item.ItemNumber = ItemNumber;
            item.LocationCode = LocationCode;
            item.BuildYear = BuildYear;
            item.Type = Type;
            item.UpdatedAt = UpdatedAt;
            item.UpdatedByUserId = UpdatedByUserId;
            item.eFormSdkFolderId = eFormSdkFolderId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                item.UpdatedAt = DateTime.UtcNow;
                item.Version += 1;

                await dbContext.ItemVersions.AddAsync(MapItemVersion(item));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(ItemsPlanningPnDbContext dbContext)
        {            
            Item item = await dbContext.Items.FirstOrDefaultAsync(x => x.Id == Id);

            if (item == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            item.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                item.UpdatedAt = DateTime.UtcNow;
                item.Version += 1;

                await dbContext.ItemVersions.AddAsync(MapItemVersion(item));
                await dbContext.SaveChangesAsync();
            }
            
        }

        private ItemVersion MapItemVersion(Item item)
        {
            ItemVersion itemVersion = new ItemVersion
            {
                Sku = item.Sku,
                Name = item.Name,
                Description = item.Description,
                Enabled = item.Enabled,
                PlanningId = item.PlanningId,
                Version = item.Version,
                ItemId = item.Id,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
                LocationCode = item.LocationCode,
                ItemNumber = item.ItemNumber,
                BuildYear = item.BuildYear,
                Type = item.Type,
                WorkflowState = item.WorkflowState,
                UpdatedByUserId = item.UpdatedByUserId,
                CreatedByUserId = item.CreatedByUserId,
                eFormSdkFolderId = item.eFormSdkFolderId
            };

            return itemVersion;
        }
    }
}