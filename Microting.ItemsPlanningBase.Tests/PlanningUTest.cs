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
    using Infrastructure.Enums;

    [TestFixture]
    public class PlanningUTest : DbTestFixture
    {
        [Test]
        public async Task ItemList_Save_DoesSave()
        {
            // Arrange
            Planning planning = new Planning
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Enabled = true,
                RelatedEFormId = 35,
                RelatedEFormName = Guid.NewGuid().ToString(),
                RepeatType = RepeatType.Day,
                UpdatedByUserId = 1,
                CreatedByUserId = 1,
                RepeatUntil = new DateTime(2050,1,1,1,1,1),
                DayOfWeek = DayOfWeek.Friday,
                RepeatEvery = 1,
                DayOfMonth = 3,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created,
                FolderId = 1,
            };

            // Act
            await planning.Create(DbContext);

            List<Planning> itemLists = DbContext.Plannings
                .AsNoTracking()
                .ToList();

            List<PlanningVersion> itemListVersions = DbContext.PlanningVersions.AsNoTracking().ToList();
            
            // Assert
            Assert.AreEqual(1, itemLists.Count);
            Assert.AreEqual(1, itemListVersions.Count);
            Assert.AreEqual(planning.Name, itemLists[0].Name);
            Assert.AreEqual(planning.CreatedByUserId, itemLists[0].CreatedByUserId);
            Assert.AreEqual(planning.UpdatedByUserId, itemLists[0].UpdatedByUserId);
            Assert.AreEqual(planning.Description, itemLists[0].Description);
            Assert.AreEqual(planning.Enabled, itemLists[0].Enabled);
            Assert.AreEqual(planning.RepeatType, itemLists[0].RepeatType);
            Assert.AreEqual(planning.RelatedEFormId, itemLists[0].RelatedEFormId);
            Assert.AreEqual(planning.RelatedEFormName, itemLists[0].RelatedEFormName);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemLists[0].WorkflowState);
            Assert.AreEqual(planning.RepeatUntil, itemLists[0].RepeatUntil);
            Assert.AreEqual(planning.DayOfWeek, itemLists[0].DayOfWeek);
            Assert.AreEqual(planning.RepeatEvery, itemLists[0].RepeatEvery);
            Assert.AreEqual(planning.DayOfMonth, itemLists[0].DayOfMonth);
            Assert.AreEqual(planning.Id, itemLists[0].Id);
            Assert.AreEqual(1, itemLists[0].Version);
                        
            Assert.AreEqual(planning.Name, itemListVersions[0].Name);
            Assert.AreEqual(planning.Description, itemListVersions[0].Description);
            Assert.AreEqual(planning.Enabled, itemListVersions[0].Enabled);
            Assert.AreEqual(planning.RepeatType, itemListVersions[0].RepeatType);
            Assert.AreEqual(planning.RelatedEFormId, itemListVersions[0].RelatedEFormId);
            Assert.AreEqual(planning.RelatedEFormName, itemListVersions[0].RelatedEFormName);
            Assert.AreEqual(planning.Id, itemListVersions[0].PlanningId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemListVersions[0].WorkflowState);
            Assert.AreEqual(planning.RepeatUntil, itemListVersions[0].RepeatUntil);
            Assert.AreEqual(planning.DayOfWeek, itemListVersions[0].DayOfWeek);
            Assert.AreEqual(planning.DayOfMonth, itemListVersions[0].DayOfMonth);
            Assert.AreEqual(planning.RepeatEvery, itemListVersions[0].RepeatEvery);
            Assert.AreEqual(1, itemListVersions[0].Version);
        }

        [Test]
        public async Task ItemList_Update_DoesUpdate()
        {
            // Arrange
            Planning planning = new Planning
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Enabled = true,
                RelatedEFormId = 35,
                RelatedEFormName = Guid.NewGuid().ToString(),
                RepeatType = RepeatType.Day,
                UpdatedByUserId = 1,
                CreatedByUserId = 1,
                RepeatUntil = new DateTime(2050,1,1,1,1,1),
                DayOfWeek = DayOfWeek.Friday,
                RepeatEvery = 1,
                DayOfMonth = 1,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created,
                FolderId = 1,
            };
            await planning.Create(DbContext);

            // Act
            planning = await DbContext.Plannings.AsNoTracking().FirstOrDefaultAsync();

            string oldName = planning.Name;
            planning.Name = "hello";
            await planning.Update(DbContext);

            List<Planning> itemLists = DbContext.Plannings.AsNoTracking().ToList();
            List<PlanningVersion> itemListVersions = DbContext.PlanningVersions.AsNoTracking().ToList();
            
            // Assert
            Assert.AreEqual(1, itemLists.Count);
            Assert.AreEqual(2, itemListVersions.Count);
            Assert.AreEqual(planning.Name, itemLists[0].Name);
            Assert.AreEqual(planning.Description, itemLists[0].Description);
            Assert.AreEqual(planning.Enabled, itemLists[0].Enabled);
            Assert.AreEqual(planning.UpdatedByUserId, itemLists[0].UpdatedByUserId);
            Assert.AreEqual(planning.CreatedByUserId, itemLists[0].CreatedByUserId);
            Assert.AreEqual(planning.RepeatUntil, itemLists[0].RepeatUntil);
            Assert.AreEqual(planning.DayOfWeek, itemLists[0].DayOfWeek);
            Assert.AreEqual(planning.RepeatEvery, itemLists[0].RepeatEvery);
            Assert.AreEqual(planning.RepeatType, itemLists[0].RepeatType);
            Assert.AreEqual(planning.DayOfMonth, itemLists[0].DayOfMonth);
            Assert.AreEqual(planning.RelatedEFormId, itemLists[0].RelatedEFormId);
            Assert.AreEqual(planning.RelatedEFormName, itemLists[0].RelatedEFormName);
            Assert.AreEqual(planning.FolderId, itemLists[0].FolderId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemLists[0].WorkflowState);
            Assert.AreEqual(planning.Id, itemLists[0].Id);
            Assert.AreEqual(2, itemLists[0].Version);
                        
            Assert.AreEqual(oldName, itemListVersions[0].Name);
            Assert.AreEqual(planning.Description, itemListVersions[0].Description);
            Assert.AreEqual(planning.Enabled, itemListVersions[0].Enabled);
            Assert.AreEqual(planning.RepeatType, itemListVersions[0].RepeatType);
            Assert.AreEqual(planning.RelatedEFormId, itemListVersions[0].RelatedEFormId);
            Assert.AreEqual(planning.RelatedEFormName, itemListVersions[0].RelatedEFormName);

            Assert.AreEqual(planning.UpdatedByUserId, itemListVersions[0].UpdatedByUserId);
            Assert.AreEqual(planning.CreatedByUserId, itemListVersions[0].CreatedByUserId);
            Assert.AreEqual(planning.RepeatUntil, itemListVersions[0].RepeatUntil);
            Assert.AreEqual(planning.DayOfWeek, itemListVersions[0].DayOfWeek);
            Assert.AreEqual(planning.RepeatEvery, itemListVersions[0].RepeatEvery);
            Assert.AreEqual(planning.Id, itemListVersions[0].PlanningId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemListVersions[0].WorkflowState);
            Assert.AreEqual(1, itemListVersions[0].Version);
            Assert.AreEqual("hello", itemListVersions[1].Name);
            Assert.AreEqual(planning.Description, itemListVersions[1].Description);
            Assert.AreEqual(planning.Enabled, itemListVersions[1].Enabled);
            Assert.AreEqual(planning.RepeatType, itemListVersions[1].RepeatType);
            Assert.AreEqual(planning.RelatedEFormId, itemListVersions[1].RelatedEFormId);
            Assert.AreEqual(planning.RelatedEFormName, itemListVersions[1].RelatedEFormName);

            Assert.AreEqual(planning.UpdatedByUserId, itemListVersions[1].UpdatedByUserId);
            Assert.AreEqual(planning.CreatedByUserId, itemListVersions[1].CreatedByUserId);
            Assert.AreEqual(planning.RepeatUntil, itemListVersions[1].RepeatUntil);
            Assert.AreEqual(planning.DayOfWeek, itemListVersions[1].DayOfWeek);
            Assert.AreEqual(planning.RepeatEvery, itemListVersions[1].RepeatEvery);

            Assert.AreEqual(planning.Id, itemListVersions[1].PlanningId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemListVersions[1].WorkflowState);
            Assert.AreEqual(2, itemListVersions[1].Version);
        }

        [Test]
        public async Task ItemList_Delete_DoesDelete()
        {
            // Arrange
            Planning planning = new Planning
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Enabled = true,
                RelatedEFormId = 35,
                RelatedEFormName = Guid.NewGuid().ToString(),
                RepeatType = RepeatType.Day,
                UpdatedByUserId = 1,
                CreatedByUserId = 1,
                RepeatEvery = 1,
                DayOfMonth = 1,
                RepeatUntil = new DateTime(2050,1,1,1,1,1),
                WorkflowState = Constants.WorkflowStates.Created,
                DayOfWeek = DayOfWeek.Friday,
            };
            await planning.Create(DbContext);

            // Act
            planning = await DbContext.Plannings.AsNoTracking().FirstOrDefaultAsync();

            Assert.AreEqual(Constants.WorkflowStates.Created, planning.WorkflowState);

            await planning.Delete(DbContext);

            List<Planning> itemLists = DbContext.Plannings.AsNoTracking().ToList();
            List<PlanningVersion> itemListVersions = DbContext.PlanningVersions.AsNoTracking().ToList();
            
            // Assert
            Assert.AreEqual(1, itemLists.Count);
            Assert.AreEqual(2, itemListVersions.Count);
            Assert.AreEqual(planning.Name, itemLists[0].Name);
            Assert.AreEqual(planning.Description, itemLists[0].Description);
            Assert.AreEqual(planning.Enabled, itemLists[0].Enabled);
            Assert.AreEqual(planning.RepeatType, itemLists[0].RepeatType);
            Assert.AreEqual(planning.RelatedEFormId, itemLists[0].RelatedEFormId);
            Assert.AreEqual(planning.RelatedEFormName, itemLists[0].RelatedEFormName);

            Assert.AreEqual(planning.UpdatedByUserId, itemLists[0].UpdatedByUserId);
            Assert.AreEqual(planning.CreatedByUserId, itemLists[0].CreatedByUserId);
            Assert.AreEqual(planning.RepeatEvery, itemLists[0].RepeatEvery);
            Assert.AreEqual(planning.RepeatUntil, itemLists[0].RepeatUntil);
            Assert.AreEqual(planning.DayOfWeek, itemLists[0].DayOfWeek);
            Assert.AreEqual(planning.DayOfMonth, itemLists[0].DayOfMonth);

            Assert.AreEqual(Constants.WorkflowStates.Removed, itemLists[0].WorkflowState);
            Assert.AreEqual(planning.Id, itemLists[0].Id);
            Assert.AreEqual(2, itemLists[0].Version);
                        
            Assert.AreEqual(planning.Name, itemListVersions[0].Name);
            Assert.AreEqual(planning.Description, itemListVersions[0].Description);
            Assert.AreEqual(planning.Enabled, itemListVersions[0].Enabled);
            Assert.AreEqual(planning.RepeatType, itemListVersions[0].RepeatType);
            Assert.AreEqual(planning.RelatedEFormId, itemListVersions[0].RelatedEFormId);
            Assert.AreEqual(planning.RelatedEFormName, itemListVersions[0].RelatedEFormName);

            Assert.AreEqual(planning.UpdatedByUserId, itemListVersions[0].UpdatedByUserId);
            Assert.AreEqual(planning.CreatedByUserId, itemListVersions[0].CreatedByUserId);
            Assert.AreEqual(planning.RepeatEvery, itemListVersions[0].RepeatEvery);
            Assert.AreEqual(planning.RepeatUntil, itemListVersions[0].RepeatUntil);
            Assert.AreEqual(planning.DayOfWeek, itemListVersions[0].DayOfWeek);
            Assert.AreEqual(planning.DayOfMonth, itemListVersions[0].DayOfMonth);

            Assert.AreEqual(planning.Id, itemListVersions[0].PlanningId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemListVersions[0].WorkflowState);
            Assert.AreEqual(1, itemListVersions[0].Version);
            
            Assert.AreEqual(planning.Name, itemListVersions[1].Name);
            Assert.AreEqual(planning.Description, itemListVersions[1].Description);
            Assert.AreEqual(planning.Enabled, itemListVersions[1].Enabled);
            Assert.AreEqual(planning.RepeatType, itemListVersions[1].RepeatType);
            Assert.AreEqual(planning.RelatedEFormId, itemListVersions[1].RelatedEFormId);
            Assert.AreEqual(planning.RelatedEFormName, itemListVersions[1].RelatedEFormName);
            Assert.AreEqual(planning.UpdatedByUserId, itemListVersions[1].UpdatedByUserId);
            Assert.AreEqual(planning.CreatedByUserId, itemListVersions[1].CreatedByUserId);
            Assert.AreEqual(planning.RepeatEvery, itemListVersions[1].RepeatEvery);
            Assert.AreEqual(planning.RepeatUntil, itemListVersions[1].RepeatUntil);
            Assert.AreEqual(planning.DayOfWeek, itemListVersions[1].DayOfWeek);

            Assert.AreEqual(planning.Id, itemListVersions[1].PlanningId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, itemListVersions[1].WorkflowState);
            Assert.AreEqual(2, itemListVersions[1].Version);
        }
    }
}