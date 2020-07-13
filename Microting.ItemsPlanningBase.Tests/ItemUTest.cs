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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.ItemsPlanningBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace Microting.ItemsPlanningBase.Tests
{
    [TestFixture]
    public class ItemUTest : DbTestFixture
    {
        [Test]
        public async Task Item_Save_DoesSave()
        {
            // Arrange
            Planning itemList = new Planning
            {
                Name = Guid.NewGuid().ToString()
            };

            await itemList.Create(DbContext);
            
            Item item = new Item
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Enabled = true,
                PlanningId = itemList.Id,
                UpdatedByUserId = 1,
                CreatedByUserId = 1,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created,
                ItemNumber = "1",
                LocationCode = "2",
                Sku = "3",
            };

            // Act
            await item.Save(DbContext);

            List<Item> items = DbContext.Items.AsNoTracking().ToList();
            List<ItemVersion> itemVersions = DbContext.ItemVersions.AsNoTracking().ToList();
            
            // Assert
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual(1, itemVersions.Count);
            Assert.AreEqual(item.Name, items[0].Name);
            Assert.AreEqual(item.Description, items[0].Description);
            Assert.AreEqual(item.Enabled, items[0].Enabled);
            Assert.AreEqual(item.PlanningId, items[0].PlanningId);

            Assert.AreEqual(item.UpdatedByUserId, items[0].UpdatedByUserId);
            Assert.AreEqual(item.CreatedByUserId, items[0].CreatedByUserId);
            Assert.AreEqual(item.Version, items[0].Version);
            Assert.AreEqual(item.WorkflowState, items[0].WorkflowState);
            Assert.AreEqual(item.ItemNumber, items[0].ItemNumber);
            Assert.AreEqual(item.LocationCode, items[0].LocationCode);

            Assert.AreEqual(Constants.WorkflowStates.Created, items[0].WorkflowState);
            Assert.AreEqual(item.Id, items[0].Id);
            Assert.AreEqual(1, items[0].Version);
                        
            Assert.AreEqual(item.Name, itemVersions[0].Name);
            Assert.AreEqual(item.Description, itemVersions[0].Description);
            Assert.AreEqual(item.Enabled, itemVersions[0].Enabled);
            Assert.AreEqual(item.PlanningId, itemVersions[0].PlanningId);

            Assert.AreEqual(item.UpdatedByUserId, itemVersions[0].UpdatedByUserId);
            Assert.AreEqual(item.CreatedByUserId, itemVersions[0].CreatedByUserId);
            Assert.AreEqual(item.Version, itemVersions[0].Version);
            Assert.AreEqual(item.WorkflowState, itemVersions[0].WorkflowState);
            Assert.AreEqual(item.ItemNumber, itemVersions[0].ItemNumber);
            Assert.AreEqual(item.LocationCode, itemVersions[0].LocationCode);

            Assert.AreEqual(Constants.WorkflowStates.Created, itemVersions[0].WorkflowState);
            Assert.AreEqual(1, itemVersions[0].Version);
        }

        [Test]
        public async Task Item_Update_DoesUpdate()
        {            
            // Arrange
            Planning itemList = new Planning
            {
                Name = Guid.NewGuid().ToString()
            };

            await itemList.Create(DbContext);
            
            Item item = new Item
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Enabled = true,
                PlanningId = itemList.Id,
                UpdatedByUserId = 1,
                CreatedByUserId = 1,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created,
                ItemNumber = "1",
                LocationCode = "2",
                Sku = "3",
            };
            await item.Save(DbContext);

            // Act
            item = await DbContext.Items.AsNoTracking().FirstOrDefaultAsync();

            string oldName = item.Name;
            item.Name = "hello";
            await item.Update(DbContext);
            
            List<Item> items = DbContext.Items.AsNoTracking().ToList();
            List<ItemVersion> itemVersions = DbContext.ItemVersions.AsNoTracking().ToList();

            // Assert
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual(2, itemVersions.Count);
            Assert.AreEqual("hello", items[0].Name);
            Assert.AreEqual(item.Description, items[0].Description);
            Assert.AreEqual(item.Enabled, items[0].Enabled);
            Assert.AreEqual(item.PlanningId, items[0].PlanningId);

            Assert.AreEqual(item.UpdatedByUserId, items[0].UpdatedByUserId);
            Assert.AreEqual(item.CreatedByUserId, items[0].CreatedByUserId);
            Assert.AreEqual(item.WorkflowState, items[0].WorkflowState);
            Assert.AreEqual(item.ItemNumber, items[0].ItemNumber);
            Assert.AreEqual(item.LocationCode, items[0].LocationCode);
            
            Assert.AreEqual(Constants.WorkflowStates.Created, items[0].WorkflowState);
            Assert.AreEqual(item.Id, items[0].Id);
            Assert.AreEqual(2, items[0].Version);
                        
            Assert.AreEqual(oldName, itemVersions[0].Name);
            Assert.AreEqual(item.Description, itemVersions[0].Description);
            Assert.AreEqual(item.Enabled, itemVersions[0].Enabled);
            Assert.AreEqual(item.PlanningId, itemVersions[0].PlanningId);

            Assert.AreEqual(item.UpdatedByUserId, itemVersions[0].UpdatedByUserId);
            Assert.AreEqual(item.CreatedByUserId, itemVersions[0].CreatedByUserId);
            Assert.AreEqual(item.Version, itemVersions[0].Version);
            Assert.AreEqual(item.WorkflowState, itemVersions[0].WorkflowState);
            Assert.AreEqual(item.ItemNumber, itemVersions[0].ItemNumber);
            Assert.AreEqual(item.LocationCode, itemVersions[0].LocationCode);

            Assert.AreEqual(Constants.WorkflowStates.Created, itemVersions[0].WorkflowState);
            Assert.AreEqual(item.Id, itemVersions[0].ItemId);
            Assert.AreEqual(1, itemVersions[0].Version);            
                        
            Assert.AreEqual("hello", itemVersions[1].Name);
            Assert.AreEqual(item.Description, itemVersions[1].Description);
            Assert.AreEqual(item.Enabled, itemVersions[1].Enabled);
            Assert.AreEqual(item.PlanningId, itemVersions[1].PlanningId);

            Assert.AreEqual(item.UpdatedByUserId, itemVersions[1].UpdatedByUserId);
            Assert.AreEqual(item.CreatedByUserId, itemVersions[1].CreatedByUserId);
            Assert.AreEqual(2, itemVersions[1].Version);
            Assert.AreEqual(item.WorkflowState, itemVersions[1].WorkflowState);
            Assert.AreEqual(item.ItemNumber, itemVersions[1].ItemNumber);
            Assert.AreEqual(item.LocationCode, itemVersions[1].LocationCode);

            Assert.AreEqual(Constants.WorkflowStates.Created, itemVersions[1].WorkflowState);
            Assert.AreEqual(item.Id, itemVersions[1].ItemId);
            Assert.AreEqual(2, itemVersions[1].Version);
        }

        [Test]
        public async Task Item_Delete_DoesDelete()
        {
            // Arrange
            Planning itemList = new Planning
            {
                Name = Guid.NewGuid().ToString()
            };

            await itemList.Create(DbContext);
            
            Item item = new Item
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Enabled = true,
                PlanningId = itemList.Id,
                UpdatedByUserId = 1,
                CreatedByUserId = 1,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created,
                ItemNumber = "1",
                LocationCode = "2",
                Sku = "3",
            };
            await item.Save(DbContext);

            // Act
            item = await DbContext.Items.FirstOrDefaultAsync();

            await item.Delete(DbContext);
            
            
            List<Item> items = DbContext.Items.AsNoTracking().ToList();
            List<ItemVersion> itemVersions = DbContext.ItemVersions.AsNoTracking().ToList();

            // Assert
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual(2, itemVersions.Count);
            Assert.AreEqual(item.Name, items[0].Name);
            Assert.AreEqual(item.Description, items[0].Description);
            Assert.AreEqual(item.Enabled, items[0].Enabled);
            Assert.AreEqual(item.PlanningId, items[0].PlanningId);
            Assert.AreEqual(item.UpdatedByUserId, items[0].UpdatedByUserId);
            Assert.AreEqual(item.CreatedByUserId, items[0].CreatedByUserId);
            Assert.AreEqual(item.Version, items[0].Version);
            Assert.AreEqual(item.WorkflowState, items[0].WorkflowState);
            Assert.AreEqual(item.ItemNumber, items[0].ItemNumber);
            Assert.AreEqual(item.LocationCode, items[0].LocationCode);

            Assert.AreEqual(Constants.WorkflowStates.Removed, items[0].WorkflowState);
            Assert.AreEqual(item.Id, items[0].Id);
            Assert.AreEqual(2, items[0].Version);
                        
            Assert.AreEqual(item.Name, itemVersions[0].Name);
            Assert.AreEqual(item.Description, itemVersions[0].Description);
            Assert.AreEqual(item.Enabled, itemVersions[0].Enabled);
            Assert.AreEqual(item.PlanningId, itemVersions[0].PlanningId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemVersions[0].WorkflowState);
            Assert.AreEqual(item.Id, itemVersions[0].ItemId);
            Assert.AreEqual(1, itemVersions[0].Version);            
                        
            Assert.AreEqual(item.Name, itemVersions[1].Name);
            Assert.AreEqual(item.Description, itemVersions[1].Description);
            Assert.AreEqual(item.Enabled, itemVersions[1].Enabled);
            Assert.AreEqual(item.PlanningId, itemVersions[1].PlanningId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, itemVersions[1].WorkflowState);
            Assert.AreEqual(item.Id, itemVersions[1].ItemId);
            Assert.AreEqual(2, itemVersions[1].Version);
        }
    }
}