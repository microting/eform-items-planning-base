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
using Microting.eForm.Infrastructure.Data.Entities;
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
            var planning = new Planning
            {
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
                LocationCode = "2",
                PlanningNumber = "1",
            };

            // Act
            await planning.Create(DbContext);

            var planingNameTranslations = new List<PlanningNameTranslation>()
            {
                new PlanningNameTranslation()
                {
                    Name = Guid.NewGuid().ToString(),
                    Language = new Language()
                    {
                        LanguageCode = "da", Name = "Danish"
                    },
                    Planning = planning
                }
            };
            foreach (var translationModel in planingNameTranslations)
            {
                await translationModel.Create(DbContext);
            }

            var planningLists = DbContext.Plannings
                .AsNoTracking()
                .ToList();

            var planingNameTranslationsList = DbContext.PlanningNameTranslation
                .AsNoTracking()
                .Where(x => x.Planning.Id == planningLists[0].Id)
                .ToList();

            var planningVersionsList = DbContext.PlanningVersions.AsNoTracking().ToList();

            var planingNameTranslationsListVersions = DbContext.PlanningNameTranslationVersions
                .AsNoTracking()
                .Where(x => x.PlanningNameTranslationId == planingNameTranslationsList[0].Id)
                .ToList();

            // Assert
            Assert.AreEqual(1, planningLists.Count);
            Assert.AreEqual(1, planningVersionsList.Count);
            Assert.AreEqual(planingNameTranslations[0].Name, planingNameTranslationsList[0].Name);
            Assert.AreEqual(planning.CreatedByUserId, planningLists[0].CreatedByUserId);
            Assert.AreEqual(planning.UpdatedByUserId, planningLists[0].UpdatedByUserId);
            Assert.AreEqual(planning.Description, planningLists[0].Description);
            Assert.AreEqual(planning.Enabled, planningLists[0].Enabled);
            Assert.AreEqual(planning.RepeatType, planningLists[0].RepeatType);
            Assert.AreEqual(planning.RelatedEFormId, planningLists[0].RelatedEFormId);
            Assert.AreEqual(planning.RelatedEFormName, planningLists[0].RelatedEFormName);
            Assert.AreEqual(Constants.WorkflowStates.Created, planningLists[0].WorkflowState);
            Assert.AreEqual(planning.RepeatUntil, planningLists[0].RepeatUntil);
            Assert.AreEqual(planning.DayOfWeek, planningLists[0].DayOfWeek);
            Assert.AreEqual(planning.RepeatEvery, planningLists[0].RepeatEvery);
            Assert.AreEqual(planning.DayOfMonth, planningLists[0].DayOfMonth);
            Assert.AreEqual(planning.Id, planningLists[0].Id);
            Assert.AreEqual(planning.PlanningNumber, planningLists[0].PlanningNumber);
            Assert.AreEqual(planning.LocationCode, planningLists[0].LocationCode);
            Assert.AreEqual(1, planningLists[0].Version);

            // versions
            Assert.AreEqual(planingNameTranslations[0].Name, planingNameTranslationsListVersions[0].Name);
            Assert.AreEqual(planning.Description, planningVersionsList[0].Description);
            Assert.AreEqual(planning.Enabled, planningVersionsList[0].Enabled);
            Assert.AreEqual(planning.RepeatType, planningVersionsList[0].RepeatType);
            Assert.AreEqual(planning.RelatedEFormId, planningVersionsList[0].RelatedEFormId);
            Assert.AreEqual(planning.RelatedEFormName, planningVersionsList[0].RelatedEFormName);
            Assert.AreEqual(planning.Id, planningVersionsList[0].PlanningId);
            Assert.AreEqual(Constants.WorkflowStates.Created, planningVersionsList[0].WorkflowState);
            Assert.AreEqual(planning.RepeatUntil, planningVersionsList[0].RepeatUntil);
            Assert.AreEqual(planning.DayOfWeek, planningVersionsList[0].DayOfWeek);
            Assert.AreEqual(planning.DayOfMonth, planningVersionsList[0].DayOfMonth);
            Assert.AreEqual(planning.RepeatEvery, planningVersionsList[0].RepeatEvery);
            Assert.AreEqual(planning.PlanningNumber, planningVersionsList[0].PlanningNumber);
            Assert.AreEqual(planning.LocationCode, planningVersionsList[0].LocationCode);
            Assert.AreEqual(1, planningVersionsList[0].Version);
        }

        [Test]
        public async Task ItemList_Update_DoesUpdate()
        {
            // Arrange
            var planning = new Planning
            {
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
                PlanningNumber = "1",
                LocationCode = "2",

            };
            await planning.Create(DbContext);

            // Act

            var planingNameTranslations = new List<PlanningNameTranslation>()
            {
                new PlanningNameTranslation()
                {
                    Name = Guid.NewGuid().ToString(),
                    Language = new Language()
                    {
                        LanguageCode = "da", Name = "Danish"
                    },
                    Planning = planning
                }
            };
            foreach (var translationModel in planingNameTranslations)
            {
                await translationModel.Create(DbContext);
            }

            // planning = await DbContext.Plannings.AsNoTracking().FirstOrDefaultAsync();

            var oldName = planingNameTranslations[0].Name;
            planingNameTranslations[0].Name = "hello";
            await planingNameTranslations[0].Update(DbContext);

            var plannings = DbContext.Plannings.AsNoTracking().ToList();
            var planingNameTranslationsList = DbContext.PlanningNameTranslation
                .AsNoTracking()
                .Where(x => x.Planning.Id == plannings[0].Id)
                .ToList();
            var planningVersions = DbContext.PlanningVersions.AsNoTracking().ToList();
            var planingNameTranslationsListVersions = DbContext.PlanningNameTranslationVersions
                .AsNoTracking()
                .Where(x => x.PlanningNameTranslationId == planingNameTranslationsList[0].Id)
                .ToList();

            // Assert
            Assert.AreEqual(1, plannings.Count);
            Assert.AreEqual(1, planningVersions.Count);
            Assert.AreEqual(1, planingNameTranslationsList.Count);
            Assert.AreEqual(2, planingNameTranslationsListVersions.Count);
            Assert.AreEqual(planingNameTranslations[0].Name, planingNameTranslationsList[0].Name);
            Assert.AreEqual(planning.Description, plannings[0].Description);
            Assert.AreEqual(planning.Enabled, plannings[0].Enabled);
            Assert.AreEqual(planning.UpdatedByUserId, plannings[0].UpdatedByUserId);
            Assert.AreEqual(planning.CreatedByUserId, plannings[0].CreatedByUserId);
            Assert.AreEqual(planning.RepeatUntil, plannings[0].RepeatUntil);
            Assert.AreEqual(planning.DayOfWeek, plannings[0].DayOfWeek);
            Assert.AreEqual(planning.RepeatEvery, plannings[0].RepeatEvery);
            Assert.AreEqual(planning.RepeatType, plannings[0].RepeatType);
            Assert.AreEqual(planning.DayOfMonth, plannings[0].DayOfMonth);
            Assert.AreEqual(planning.RelatedEFormId, plannings[0].RelatedEFormId);
            Assert.AreEqual(planning.RelatedEFormName, plannings[0].RelatedEFormName);
            Assert.AreEqual(planning.LocationCode, plannings[0].LocationCode);
            Assert.AreEqual(planning.PlanningNumber, plannings[0].PlanningNumber);
            Assert.AreEqual(Constants.WorkflowStates.Created, plannings[0].WorkflowState);
            Assert.AreEqual(planning.Id, plannings[0].Id);
            Assert.AreEqual(1, plannings[0].Version);

            // Versions
            Assert.AreEqual(oldName, planingNameTranslationsListVersions[0].Name);
            Assert.AreEqual(planning.Description, planningVersions[0].Description);
            Assert.AreEqual(planning.Enabled, planningVersions[0].Enabled);
            Assert.AreEqual(planning.RepeatType, planningVersions[0].RepeatType);
            Assert.AreEqual(planning.RelatedEFormId, planningVersions[0].RelatedEFormId);
            Assert.AreEqual(planning.RelatedEFormName, planningVersions[0].RelatedEFormName);
            Assert.AreEqual(planning.UpdatedByUserId, planningVersions[0].UpdatedByUserId);
            Assert.AreEqual(planning.CreatedByUserId, planningVersions[0].CreatedByUserId);
            Assert.AreEqual(planning.RepeatUntil, planningVersions[0].RepeatUntil);
            Assert.AreEqual(planning.DayOfWeek, planningVersions[0].DayOfWeek);
            Assert.AreEqual(planning.RepeatEvery, planningVersions[0].RepeatEvery);
            Assert.AreEqual(planning.Id, planningVersions[0].PlanningId);
            Assert.AreEqual(Constants.WorkflowStates.Created, planningVersions[0].WorkflowState);
            Assert.AreEqual(1, planningVersions[0].Version);
            Assert.AreEqual("hello", planingNameTranslationsListVersions[1].Name);
        }

        [Test]
        public async Task ItemList_Delete_DoesDelete()
        {
            // Arrange
            var planning = new Planning
            {
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
                PlanningNumber = "1",
                LocationCode = "2",
            };
            await planning.Create(DbContext);

            var planingNameTranslations = new List<PlanningNameTranslation>()
            {
                new PlanningNameTranslation()
                {
                    Name = Guid.NewGuid().ToString(),
                    Language = new Language()
                    {
                        LanguageCode = "da", Name = "Danish"
                    },
                    Planning = planning
                }
            };
            foreach (var translationModel in planingNameTranslations)
            {
                await translationModel.Create(DbContext);
            }

            // Act
            // planning = await DbContext.Plannings.AsNoTracking().FirstOrDefaultAsync();

            Assert.AreEqual(Constants.WorkflowStates.Created, planning.WorkflowState);

            await planning.Delete(DbContext);
            await planingNameTranslations[0].Delete(DbContext);
            var plannings = DbContext.Plannings.AsNoTracking().ToList();
            var planingNameTranslationsList = DbContext.PlanningNameTranslation
                .AsNoTracking()
                .Where(x => x.Planning.Id == plannings[0].Id)
                .ToList();
            var planningVersions = DbContext.PlanningVersions.AsNoTracking().ToList();
            var planingNameTranslationsListVersions = DbContext.PlanningNameTranslationVersions
                .AsNoTracking()
                .Where(x => x.PlanningNameTranslationId == planingNameTranslationsList[0].Id)
                .ToList();

            // Assert
            Assert.AreEqual(1, plannings.Count);
            Assert.AreEqual(2, planningVersions.Count);
            Assert.AreEqual(1, planingNameTranslationsList.Count);
            Assert.AreEqual(2, planingNameTranslationsListVersions.Count);
            Assert.AreEqual(planingNameTranslationsList[0].Name, planingNameTranslations[0].Name);
            Assert.AreEqual(planning.Description, plannings[0].Description);
            Assert.AreEqual(planning.Enabled, plannings[0].Enabled);
            Assert.AreEqual(planning.RepeatType, plannings[0].RepeatType);
            Assert.AreEqual(planning.RelatedEFormId, plannings[0].RelatedEFormId);
            Assert.AreEqual(planning.RelatedEFormName, plannings[0].RelatedEFormName);
            Assert.AreEqual(planning.UpdatedByUserId, plannings[0].UpdatedByUserId);
            Assert.AreEqual(planning.CreatedByUserId, plannings[0].CreatedByUserId);
            Assert.AreEqual(planning.RepeatEvery, plannings[0].RepeatEvery);
            Assert.AreEqual(planning.RepeatUntil, plannings[0].RepeatUntil);
            Assert.AreEqual(planning.DayOfWeek, plannings[0].DayOfWeek);
            Assert.AreEqual(planning.DayOfMonth, plannings[0].DayOfMonth);
            Assert.AreEqual(Constants.WorkflowStates.Removed, plannings[0].WorkflowState);
            Assert.AreEqual(planning.Id, plannings[0].Id);
            Assert.AreEqual(planning.LocationCode, plannings[0].LocationCode);
            Assert.AreEqual(planning.PlanningNumber, plannings[0].PlanningNumber);
            Assert.AreEqual(2, plannings[0].Version);

            // Versions
            Assert.AreEqual(planingNameTranslations[0].Name, planingNameTranslationsListVersions[0].Name);
            Assert.AreEqual(planning.Description, planningVersions[0].Description);
            Assert.AreEqual(planning.Enabled, planningVersions[0].Enabled);
            Assert.AreEqual(planning.RepeatType, planningVersions[0].RepeatType);
            Assert.AreEqual(planning.RelatedEFormId, planningVersions[0].RelatedEFormId);
            Assert.AreEqual(planning.RelatedEFormName, planningVersions[0].RelatedEFormName);
            Assert.AreEqual(planning.UpdatedByUserId, planningVersions[0].UpdatedByUserId);
            Assert.AreEqual(planning.CreatedByUserId, planningVersions[0].CreatedByUserId);
            Assert.AreEqual(planning.RepeatEvery, planningVersions[0].RepeatEvery);
            Assert.AreEqual(planning.RepeatUntil, planningVersions[0].RepeatUntil);
            Assert.AreEqual(planning.DayOfWeek, planningVersions[0].DayOfWeek);
            Assert.AreEqual(planning.DayOfMonth, planningVersions[0].DayOfMonth);
            Assert.AreEqual(planning.Id, planningVersions[0].PlanningId);
            Assert.AreEqual(Constants.WorkflowStates.Created, planningVersions[0].WorkflowState);
            Assert.AreEqual(1, planningVersions[0].Version);
            Assert.AreEqual(planingNameTranslations[0].Name, planingNameTranslationsListVersions[1].Name);
            Assert.AreEqual(planning.Description, planningVersions[1].Description);
            Assert.AreEqual(planning.Enabled, planningVersions[1].Enabled);
            Assert.AreEqual(planning.RepeatType, planningVersions[1].RepeatType);
            Assert.AreEqual(planning.RelatedEFormId, planningVersions[1].RelatedEFormId);
            Assert.AreEqual(planning.RelatedEFormName, planningVersions[1].RelatedEFormName);
            Assert.AreEqual(planning.UpdatedByUserId, planningVersions[1].UpdatedByUserId);
            Assert.AreEqual(planning.CreatedByUserId, planningVersions[1].CreatedByUserId);
            Assert.AreEqual(planning.RepeatEvery, planningVersions[1].RepeatEvery);
            Assert.AreEqual(planning.RepeatUntil, planningVersions[1].RepeatUntil);
            Assert.AreEqual(planning.DayOfWeek, planningVersions[1].DayOfWeek);
            Assert.AreEqual(planning.Id, planningVersions[1].PlanningId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, planningVersions[1].WorkflowState);
            Assert.AreEqual(2, planningVersions[1].Version);
        }
    }
}