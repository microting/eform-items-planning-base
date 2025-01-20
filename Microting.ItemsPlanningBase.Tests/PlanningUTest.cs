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

namespace Microting.ItemsPlanningBase.Tests;

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
            PlanningNumber = "1"
        };

        // Act
        await planning.Create(DbContext);

        var planingNameTranslations = new List<PlanningNameTranslation>()
        {
            new()
            {
                Name = Guid.NewGuid().ToString(),
                LanguageId = 1,
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
        Assert.That(planningLists.Count, Is.EqualTo(1));
        Assert.That(planningVersionsList.Count, Is.EqualTo(1));
        Assert.That(planingNameTranslationsList[0].Name, Is.EqualTo(planingNameTranslations[0].Name));
        Assert.That(planningLists[0].CreatedByUserId, Is.EqualTo(planning.CreatedByUserId));
        Assert.That(planningLists[0].UpdatedByUserId, Is.EqualTo(planning.UpdatedByUserId));
        Assert.That(planningLists[0].Description, Is.EqualTo(planning.Description));
        Assert.That(planningLists[0].Enabled, Is.EqualTo(planning.Enabled));
        Assert.That(planningLists[0].RepeatType, Is.EqualTo(planning.RepeatType));
        Assert.That(planningLists[0].RelatedEFormId, Is.EqualTo(planning.RelatedEFormId));
        Assert.That(planningLists[0].RelatedEFormName, Is.EqualTo(planning.RelatedEFormName));
        Assert.That(planningLists[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
        Assert.That(planningLists[0].RepeatUntil, Is.EqualTo(planning.RepeatUntil));
        Assert.That(planningLists[0].DayOfWeek, Is.EqualTo(planning.DayOfWeek));
        Assert.That(planningLists[0].RepeatEvery, Is.EqualTo(planning.RepeatEvery));
        Assert.That(planningLists[0].DayOfMonth, Is.EqualTo(planning.DayOfMonth));
        Assert.That(planningLists[0].Id, Is.EqualTo(planning.Id));
        Assert.That(planningLists[0].PlanningNumber, Is.EqualTo(planning.PlanningNumber));
        Assert.That(planningLists[0].LocationCode, Is.EqualTo(planning.LocationCode));
        Assert.That(planningLists[0].Version, Is.EqualTo(1));

        // versions
        Assert.That(planingNameTranslationsListVersions[0].Name, Is.EqualTo(planingNameTranslations[0].Name));
        Assert.That(planningVersionsList[0].Description, Is.EqualTo(planning.Description));
        Assert.That(planningVersionsList[0].Enabled, Is.EqualTo(planning.Enabled));
        Assert.That(planningVersionsList[0].RepeatType, Is.EqualTo(planning.RepeatType));
        Assert.That(planningVersionsList[0].RelatedEFormId, Is.EqualTo(planning.RelatedEFormId));
        Assert.That(planningVersionsList[0].RelatedEFormName, Is.EqualTo(planning.RelatedEFormName));
        Assert.That(planningVersionsList[0].PlanningId, Is.EqualTo(planning.Id));
        Assert.That(planningVersionsList[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
        Assert.That(planningVersionsList[0].RepeatUntil, Is.EqualTo(planning.RepeatUntil));
        Assert.That(planningVersionsList[0].DayOfWeek, Is.EqualTo(planning.DayOfWeek));
        Assert.That(planningVersionsList[0].DayOfMonth, Is.EqualTo(planning.DayOfMonth));
        Assert.That(planningVersionsList[0].RepeatEvery, Is.EqualTo(planning.RepeatEvery));
        Assert.That(planningVersionsList[0].PlanningNumber, Is.EqualTo(planning.PlanningNumber));
        Assert.That(planningVersionsList[0].LocationCode, Is.EqualTo(planning.LocationCode));
        Assert.That(planningVersionsList[0].Version, Is.EqualTo(1));
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
            LocationCode = "2"

        };
        await planning.Create(DbContext);

        // Act

        var planingNameTranslations = new List<PlanningNameTranslation>()
        {
            new()
            {
                Name = Guid.NewGuid().ToString(),
                LanguageId = 1,
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
        Assert.That(plannings.Count, Is.EqualTo(1));
        Assert.That(planningVersions.Count, Is.EqualTo(1));
        Assert.That(planingNameTranslationsList.Count, Is.EqualTo(1));
        Assert.That(planingNameTranslationsListVersions.Count, Is.EqualTo(2));
        Assert.That(planingNameTranslationsList[0].Name, Is.EqualTo(planingNameTranslations[0].Name));
        Assert.That(plannings[0].Description, Is.EqualTo(planning.Description));
        Assert.That(plannings[0].Enabled, Is.EqualTo(planning.Enabled));
        Assert.That(plannings[0].UpdatedByUserId, Is.EqualTo(planning.UpdatedByUserId));
        Assert.That(plannings[0].CreatedByUserId, Is.EqualTo(planning.CreatedByUserId));
        Assert.That(plannings[0].RepeatUntil, Is.EqualTo(planning.RepeatUntil));
        Assert.That(plannings[0].DayOfWeek, Is.EqualTo(planning.DayOfWeek));
        Assert.That(plannings[0].RepeatEvery, Is.EqualTo(planning.RepeatEvery));
        Assert.That(plannings[0].RepeatType, Is.EqualTo(planning.RepeatType));
        Assert.That(plannings[0].DayOfMonth, Is.EqualTo(planning.DayOfMonth));
        Assert.That(plannings[0].RelatedEFormId, Is.EqualTo(planning.RelatedEFormId));
        Assert.That(plannings[0].RelatedEFormName, Is.EqualTo(planning.RelatedEFormName));
        Assert.That(plannings[0].LocationCode, Is.EqualTo(planning.LocationCode));
        Assert.That(plannings[0].PlanningNumber, Is.EqualTo(planning.PlanningNumber));
        Assert.That(plannings[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
        Assert.That(plannings[0].Id, Is.EqualTo(planning.Id));
        Assert.That(plannings[0].Version, Is.EqualTo(1));

        // Versions
        Assert.That(planingNameTranslationsListVersions[0].Name, Is.EqualTo(oldName));
        Assert.That(planningVersions[0].Description, Is.EqualTo(planning.Description));
        Assert.That(planningVersions[0].Enabled, Is.EqualTo(planning.Enabled));
        Assert.That(planningVersions[0].RepeatType, Is.EqualTo(planning.RepeatType));
        Assert.That(planningVersions[0].RelatedEFormId, Is.EqualTo(planning.RelatedEFormId));
        Assert.That(planningVersions[0].RelatedEFormName, Is.EqualTo(planning.RelatedEFormName));
        Assert.That(planningVersions[0].UpdatedByUserId, Is.EqualTo(planning.UpdatedByUserId));
        Assert.That(planningVersions[0].CreatedByUserId, Is.EqualTo(planning.CreatedByUserId));
        Assert.That(planningVersions[0].RepeatUntil, Is.EqualTo(planning.RepeatUntil));
        Assert.That(planningVersions[0].DayOfWeek, Is.EqualTo(planning.DayOfWeek));
        Assert.That(planningVersions[0].RepeatEvery, Is.EqualTo(planning.RepeatEvery));
        Assert.That(planningVersions[0].PlanningId, Is.EqualTo(planning.Id));
        Assert.That(planningVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
        Assert.That(planningVersions[0].Version, Is.EqualTo(1));
        Assert.That(planingNameTranslationsListVersions[1].Name, Is.EqualTo("hello"));
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
            LocationCode = "2"
        };
        await planning.Create(DbContext);

        var planingNameTranslations = new List<PlanningNameTranslation>()
        {
            new()
            {
                Name = Guid.NewGuid().ToString(),
                LanguageId = 1,
                Planning = planning
            }
        };
        foreach (var translationModel in planingNameTranslations)
        {
            await translationModel.Create(DbContext);
        }

        // Act
        // planning = await DbContext.Plannings.AsNoTracking().FirstOrDefaultAsync();

        Assert.That(planning.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));

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
        Assert.That(plannings.Count, Is.EqualTo(1));
        Assert.That(planningVersions.Count, Is.EqualTo(2));
        Assert.That(planingNameTranslationsList.Count, Is.EqualTo(1));
        Assert.That(planingNameTranslationsListVersions.Count, Is.EqualTo(2));
        Assert.That(planingNameTranslations[0].Name, Is.EqualTo(planingNameTranslationsList[0].Name));
        Assert.That(plannings[0].Description, Is.EqualTo(planning.Description));
        Assert.That(plannings[0].Enabled, Is.EqualTo(planning.Enabled));
        Assert.That(plannings[0].RepeatType, Is.EqualTo(planning.RepeatType));
        Assert.That(plannings[0].RelatedEFormId, Is.EqualTo(planning.RelatedEFormId));
        Assert.That(plannings[0].RelatedEFormName, Is.EqualTo(planning.RelatedEFormName));
        Assert.That(plannings[0].UpdatedByUserId, Is.EqualTo(planning.UpdatedByUserId));
        Assert.That(plannings[0].CreatedByUserId, Is.EqualTo(planning.CreatedByUserId));
        Assert.That(plannings[0].RepeatEvery, Is.EqualTo(planning.RepeatEvery));
        Assert.That(plannings[0].RepeatUntil, Is.EqualTo(planning.RepeatUntil));
        Assert.That(plannings[0].DayOfWeek, Is.EqualTo(planning.DayOfWeek));
        Assert.That(plannings[0].DayOfMonth, Is.EqualTo(planning.DayOfMonth));
        Assert.That(plannings[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
        Assert.That(plannings[0].Id, Is.EqualTo(planning.Id));
        Assert.That(plannings[0].LocationCode, Is.EqualTo(planning.LocationCode));
        Assert.That(plannings[0].PlanningNumber, Is.EqualTo(planning.PlanningNumber));
        Assert.That(plannings[0].Version, Is.EqualTo(2));

        // Versions
        Assert.That(planingNameTranslationsListVersions[0].Name, Is.EqualTo(planingNameTranslations[0].Name));
        Assert.That(planningVersions[0].Description, Is.EqualTo(planning.Description));
        Assert.That(planningVersions[0].Enabled, Is.EqualTo(planning.Enabled));
        Assert.That(planningVersions[0].RepeatType, Is.EqualTo(planning.RepeatType));
        Assert.That(planningVersions[0].RelatedEFormId, Is.EqualTo(planning.RelatedEFormId));
        Assert.That(planningVersions[0].RelatedEFormName, Is.EqualTo(planning.RelatedEFormName));
        Assert.That(planningVersions[0].UpdatedByUserId, Is.EqualTo(planning.UpdatedByUserId));
        Assert.That(planningVersions[0].CreatedByUserId, Is.EqualTo(planning.CreatedByUserId));
        Assert.That(planningVersions[0].RepeatEvery, Is.EqualTo(planning.RepeatEvery));
        Assert.That(planningVersions[0].RepeatUntil, Is.EqualTo(planning.RepeatUntil));
        Assert.That(planningVersions[0].DayOfWeek, Is.EqualTo(planning.DayOfWeek));
        Assert.That(planningVersions[0].DayOfMonth, Is.EqualTo(planning.DayOfMonth));
        Assert.That(planningVersions[0].PlanningId, Is.EqualTo(planning.Id));
        Assert.That(planningVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
        Assert.That(planningVersions[0].Version, Is.EqualTo(1));
        Assert.That(planingNameTranslationsListVersions[1].Name, Is.EqualTo(planingNameTranslations[0].Name));
        Assert.That(planningVersions[1].Description, Is.EqualTo(planning.Description));
        Assert.That(planningVersions[1].Enabled, Is.EqualTo(planning.Enabled));
        Assert.That(planningVersions[1].RepeatType, Is.EqualTo(planning.RepeatType));
        Assert.That(planningVersions[1].RelatedEFormId, Is.EqualTo(planning.RelatedEFormId));
        Assert.That(planningVersions[1].RelatedEFormName, Is.EqualTo(planning.RelatedEFormName));
        Assert.That(planningVersions[1].UpdatedByUserId, Is.EqualTo(planning.UpdatedByUserId));
        Assert.That(planningVersions[1].CreatedByUserId, Is.EqualTo(planning.CreatedByUserId));
        Assert.That(planningVersions[1].RepeatEvery, Is.EqualTo(planning.RepeatEvery));
        Assert.That(planningVersions[1].RepeatUntil, Is.EqualTo(planning.RepeatUntil));
        Assert.That(planningVersions[1].DayOfWeek, Is.EqualTo(planning.DayOfWeek));
        Assert.That(planningVersions[1].PlanningId, Is.EqualTo(planning.Id));
        Assert.That(planningVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
        Assert.That(planningVersions[1].Version, Is.EqualTo(2));
    }
}