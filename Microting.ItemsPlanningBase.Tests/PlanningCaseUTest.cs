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

[TestFixture]
public class PlanningCaseUTest : DbTestFixture
{
    [Test]
    public async Task PlanningCase_Save_DoesSave()
    {
        // Arrange
        var planning = new Planning();

        await planning.Create(DbContext);

        var commonTranslationModels = new List<PlanningNameTranslation>()
        {
            new()
            {
                Name = Guid.NewGuid().ToString(),
                LanguageId = 1,
                Planning = planning
            }
        };
        foreach (var translationModel in commonTranslationModels)
        {
            await translationModel.Create(DbContext);
        }


        var planningCase = new PlanningCase
        {
            MicrotingSdkSiteId = 24,
            MicrotingSdkCaseId = 34,
            MicrotingSdkeFormId = 234,
            Status = 66,
            PlanningId = planning.Id
        };

        // Act
        await planningCase.Create(DbContext);

        var planningCases = DbContext.PlanningCases.AsNoTracking().ToList();
        var planningCaseVersions = DbContext.PlanningCaseVersions.AsNoTracking().ToList();

        // Assert
        Assert.That(planningCases.Count, Is.EqualTo(1));
        Assert.That(planningCaseVersions.Count, Is.EqualTo(1));
        Assert.That(planningCases[0].MicrotingSdkSiteId, Is.EqualTo(planningCase.MicrotingSdkSiteId));
        Assert.That(planningCases[0].MicrotingSdkCaseId, Is.EqualTo(planningCase.MicrotingSdkCaseId));
        Assert.That(planningCases[0].MicrotingSdkeFormId, Is.EqualTo(planningCase.MicrotingSdkeFormId));
        Assert.That(planningCases[0].Status, Is.EqualTo(planningCase.Status));
        Assert.That(planningCases[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
        Assert.That(planningCases[0].Id, Is.EqualTo(planningCase.Id));
        Assert.That(planningCases[0].PlanningId, Is.EqualTo(planningCase.PlanningId));
        Assert.That(planningCases[0].Version, Is.EqualTo(1));

        Assert.That(planningCaseVersions[0].MicrotingSdkSiteId, Is.EqualTo(planningCase.MicrotingSdkSiteId));
        Assert.That(planningCaseVersions[0].MicrotingSdkCaseId, Is.EqualTo(planningCase.MicrotingSdkCaseId));
        Assert.That(planningCaseVersions[0].MicrotingSdkeFormId, Is.EqualTo(planningCase.MicrotingSdkeFormId));
        Assert.That(planningCaseVersions[0].Status, Is.EqualTo(planningCase.Status));
        Assert.That(planningCaseVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
        Assert.That(planningCaseVersions[0].PlanningCaseId, Is.EqualTo(planningCase.Id));
        Assert.That(planningCaseVersions[0].PlanningId, Is.EqualTo(planningCase.PlanningId));
        Assert.That(planningCaseVersions[0].Version, Is.EqualTo(1));
    }

    [Test]
    public async Task PlanningCase_Update_DoesUpdate()
    {
        // Arrange
        var planning = new Planning();

        await planning.Create(DbContext);

        var commonTranslationModels = new List<PlanningNameTranslation>()
        {
            new()
            {
                Name = Guid.NewGuid().ToString(),
                LanguageId = 1,
                Planning = planning
            }
        };
        foreach (var translationModel in commonTranslationModels)
        {
            await translationModel.Create(DbContext);
        }

        var planningCase = new PlanningCase
        {
            MicrotingSdkSiteId = 24,
            MicrotingSdkCaseId = 34,
            MicrotingSdkeFormId = 234,
            Status = 66,
            PlanningId = planning.Id
        };

        await planningCase.Create(DbContext);
        // Act
        // itemCase = await DbContext.PlanningCases.AsNoTracking().FirstOrDefaultAsync();

        planningCase.Status = 77;
        await planningCase.Update(DbContext);

        var planningCases = DbContext.PlanningCases.AsNoTracking().ToList();
        var planningCaseVersions = DbContext.PlanningCaseVersions.AsNoTracking().ToList();

        // Assert
        Assert.That(planningCases.Count, Is.EqualTo(1));
        Assert.That(planningCaseVersions.Count, Is.EqualTo(2));
        Assert.That(planningCases[0].MicrotingSdkSiteId, Is.EqualTo(planningCase.MicrotingSdkSiteId));
        Assert.That(planningCases[0].MicrotingSdkCaseId, Is.EqualTo(planningCase.MicrotingSdkCaseId));
        Assert.That(planningCases[0].MicrotingSdkeFormId, Is.EqualTo(planningCase.MicrotingSdkeFormId));
        Assert.That(planningCases[0].Status, Is.EqualTo(77));
        Assert.That(planningCases[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
        Assert.That(planningCases[0].Id, Is.EqualTo(planningCase.Id));
        Assert.That(planningCases[0].PlanningId, Is.EqualTo(planningCase.PlanningId));
        Assert.That(planningCases[0].Version, Is.EqualTo(2));

        Assert.That(planningCaseVersions[0].MicrotingSdkSiteId, Is.EqualTo(planningCase.MicrotingSdkSiteId));
        Assert.That(planningCaseVersions[0].MicrotingSdkCaseId, Is.EqualTo(planningCase.MicrotingSdkCaseId));
        Assert.That(planningCaseVersions[0].MicrotingSdkeFormId, Is.EqualTo(planningCase.MicrotingSdkeFormId));
        Assert.That(planningCaseVersions[0].Status, Is.EqualTo(66));
        Assert.That(planningCaseVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
        Assert.That(planningCaseVersions[0].PlanningCaseId, Is.EqualTo(planningCase.Id));
        Assert.That(planningCaseVersions[0].Version, Is.EqualTo(1));

        Assert.That(planningCaseVersions[1].MicrotingSdkSiteId, Is.EqualTo(planningCase.MicrotingSdkSiteId));
        Assert.That(planningCaseVersions[1].MicrotingSdkCaseId, Is.EqualTo(planningCase.MicrotingSdkCaseId));
        Assert.That(planningCaseVersions[1].MicrotingSdkeFormId, Is.EqualTo(planningCase.MicrotingSdkeFormId));
        Assert.That(planningCaseVersions[1].Status, Is.EqualTo(77));
        Assert.That(planningCaseVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
        Assert.That(planningCaseVersions[1].PlanningCaseId, Is.EqualTo(planningCase.Id));
        Assert.That(planningCaseVersions[0].PlanningId, Is.EqualTo(planningCase.PlanningId));
        Assert.That(planningCaseVersions[1].Version, Is.EqualTo(2));
    }

    [Test]
    public async Task PlanningCase_Delete_DoesDelete()
    {
        // Arrange
        var planning = new Planning();

        await planning.Create(DbContext);

        var commonTranslationModels = new List<PlanningNameTranslation>
        {
            new()
            {
                Name = Guid.NewGuid().ToString(),
                LanguageId = 1,
                Planning = planning
            }
        };
        foreach (var translationModel in commonTranslationModels)
        {
            await translationModel.Create(DbContext);
        }

        var planningCase = new PlanningCase
        {
            MicrotingSdkSiteId = 24,
            MicrotingSdkCaseId = 34,
            MicrotingSdkeFormId = 234,
            Status = 66,
            PlanningId = planning.Id
        };

        await planningCase.Create(DbContext);
        // Act
        // itemCase = await DbContext.PlanningCases.AsNoTracking().FirstOrDefaultAsync();

        await planningCase.Delete(DbContext);

        var planningCases = DbContext.PlanningCases.AsNoTracking().ToList();
        var planningCaseVersions = DbContext.PlanningCaseVersions.AsNoTracking().ToList();

        // Assert
        Assert.That(planningCases.Count, Is.EqualTo(1));
        Assert.That(planningCaseVersions.Count, Is.EqualTo(2));
        Assert.That(planningCases[0].MicrotingSdkSiteId, Is.EqualTo(planningCase.MicrotingSdkSiteId));
        Assert.That(planningCases[0].MicrotingSdkCaseId, Is.EqualTo(planningCase.MicrotingSdkCaseId));
        Assert.That(planningCases[0].MicrotingSdkeFormId, Is.EqualTo(planningCase.MicrotingSdkeFormId));
        Assert.That(planningCases[0].PlanningId, Is.EqualTo(planningCase.PlanningId));
        Assert.That(planningCases[0].Status, Is.EqualTo(planningCase.Status));
        Assert.That(planningCases[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
        Assert.That(planningCases[0].Id, Is.EqualTo(planningCase.Id));
        Assert.That(planningCases[0].Version, Is.EqualTo(2));

        Assert.That(planningCaseVersions[0].MicrotingSdkSiteId, Is.EqualTo(planningCase.MicrotingSdkSiteId));
        Assert.That(planningCaseVersions[0].MicrotingSdkCaseId, Is.EqualTo(planningCase.MicrotingSdkCaseId));
        Assert.That(planningCaseVersions[0].MicrotingSdkeFormId, Is.EqualTo(planningCase.MicrotingSdkeFormId));
        Assert.That(planningCaseVersions[0].Status, Is.EqualTo(planningCase.Status));
        Assert.That(planningCaseVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
        Assert.That(planningCaseVersions[0].PlanningCaseId, Is.EqualTo(planningCase.Id));
        Assert.That(planningCaseVersions[0].PlanningId, Is.EqualTo(planningCase.PlanningId));
        Assert.That(planningCaseVersions[0].Version, Is.EqualTo(1));

        Assert.That(planningCaseVersions[1].MicrotingSdkSiteId, Is.EqualTo(planningCase.MicrotingSdkSiteId));
        Assert.That(planningCaseVersions[1].MicrotingSdkCaseId, Is.EqualTo(planningCase.MicrotingSdkCaseId));
        Assert.That(planningCaseVersions[1].MicrotingSdkeFormId, Is.EqualTo(planningCase.MicrotingSdkeFormId));
        Assert.That(planningCaseVersions[1].PlanningId, Is.EqualTo(planningCase.PlanningId));
        Assert.That(planningCaseVersions[1].Status, Is.EqualTo(planningCase.Status));
        Assert.That(planningCaseVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
        Assert.That(planningCaseVersions[1].PlanningCaseId, Is.EqualTo(planningCase.Id));
        Assert.That(planningCaseVersions[1].Version, Is.EqualTo(2));
    }
}