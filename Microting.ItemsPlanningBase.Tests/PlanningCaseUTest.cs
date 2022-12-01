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
                new PlanningNameTranslation()
                {
                    Name = Guid.NewGuid().ToString(),
                    Language = new Language()
                    {
                        Name = "Danish",
                        LanguageCode = "da"
                    },
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
                PlanningId = planning.Id,
            };

            // Act
            await planningCase.Create(DbContext);

            var planningCases = DbContext.PlanningCases.AsNoTracking().ToList();
            var planningCaseVersions = DbContext.PlanningCaseVersions.AsNoTracking().ToList();

            // Assert
            Assert.AreEqual(1, planningCases.Count);
            Assert.AreEqual(1, planningCaseVersions.Count);
            Assert.AreEqual(planningCase.MicrotingSdkSiteId, planningCases[0].MicrotingSdkSiteId);
            Assert.AreEqual(planningCase.MicrotingSdkCaseId, planningCases[0].MicrotingSdkCaseId);
            Assert.AreEqual(planningCase.MicrotingSdkeFormId, planningCases[0].MicrotingSdkeFormId);
            Assert.AreEqual(planningCase.Status, planningCases[0].Status);
            Assert.AreEqual(Constants.WorkflowStates.Created, planningCases[0].WorkflowState);
            Assert.AreEqual(planningCase.Id, planningCases[0].Id);
            Assert.AreEqual(planningCase.PlanningId, planningCases[0].PlanningId);
            Assert.AreEqual(1, planningCases[0].Version);

            Assert.AreEqual(planningCase.MicrotingSdkSiteId, planningCaseVersions[0].MicrotingSdkSiteId);
            Assert.AreEqual(planningCase.MicrotingSdkCaseId, planningCaseVersions[0].MicrotingSdkCaseId);
            Assert.AreEqual(planningCase.MicrotingSdkeFormId, planningCaseVersions[0].MicrotingSdkeFormId);
            Assert.AreEqual(planningCase.Status, planningCaseVersions[0].Status);
            Assert.AreEqual(Constants.WorkflowStates.Created, planningCaseVersions[0].WorkflowState);
            Assert.AreEqual(planningCase.Id, planningCaseVersions[0].PlanningCaseId);
            Assert.AreEqual(planningCase.PlanningId, planningCaseVersions[0].PlanningId);
            Assert.AreEqual(1, planningCaseVersions[0].Version);
        }

        [Test]
        public async Task PlanningCase_Update_DoesUpdate()
        {
            // Arrange
            var planning = new Planning();

            await planning.Create(DbContext);

            var commonTranslationModels = new List<PlanningNameTranslation>()
            {
                new PlanningNameTranslation()
                {
                    Name = Guid.NewGuid().ToString(),
                    Language = new Language()
                    {
                        Name = "Danish",
                        LanguageCode = "da"
                    },
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
                PlanningId = planning.Id,
            };

            await planningCase.Create(DbContext);
            // Act
            // itemCase = await DbContext.PlanningCases.AsNoTracking().FirstOrDefaultAsync();

            planningCase.Status = 77;
            await planningCase.Update(DbContext);

            var planningCases = DbContext.PlanningCases.AsNoTracking().ToList();
            var planningCaseVersions = DbContext.PlanningCaseVersions.AsNoTracking().ToList();

            // Assert
            Assert.AreEqual(1, planningCases.Count);
            Assert.AreEqual(2, planningCaseVersions.Count);
            Assert.AreEqual(planningCase.MicrotingSdkSiteId, planningCases[0].MicrotingSdkSiteId);
            Assert.AreEqual(planningCase.MicrotingSdkCaseId, planningCases[0].MicrotingSdkCaseId);
            Assert.AreEqual(planningCase.MicrotingSdkeFormId, planningCases[0].MicrotingSdkeFormId);
            Assert.AreEqual(77, planningCases[0].Status);
            Assert.AreEqual(Constants.WorkflowStates.Created, planningCases[0].WorkflowState);
            Assert.AreEqual(planningCase.Id, planningCases[0].Id);
            Assert.AreEqual(planningCase.PlanningId, planningCases[0].PlanningId);
            Assert.AreEqual(2, planningCases[0].Version);

            Assert.AreEqual(planningCase.MicrotingSdkSiteId, planningCaseVersions[0].MicrotingSdkSiteId);
            Assert.AreEqual(planningCase.MicrotingSdkCaseId, planningCaseVersions[0].MicrotingSdkCaseId);
            Assert.AreEqual(planningCase.MicrotingSdkeFormId, planningCaseVersions[0].MicrotingSdkeFormId);
            Assert.AreEqual(66, planningCaseVersions[0].Status);
            Assert.AreEqual(Constants.WorkflowStates.Created, planningCaseVersions[0].WorkflowState);
            Assert.AreEqual(planningCase.Id, planningCaseVersions[0].PlanningCaseId);
            Assert.AreEqual(1, planningCaseVersions[0].Version);

            Assert.AreEqual(planningCase.MicrotingSdkSiteId, planningCaseVersions[1].MicrotingSdkSiteId);
            Assert.AreEqual(planningCase.MicrotingSdkCaseId, planningCaseVersions[1].MicrotingSdkCaseId);
            Assert.AreEqual(planningCase.MicrotingSdkeFormId, planningCaseVersions[1].MicrotingSdkeFormId);
            Assert.AreEqual(77, planningCaseVersions[1].Status);
            Assert.AreEqual(Constants.WorkflowStates.Created, planningCaseVersions[1].WorkflowState);
            Assert.AreEqual(planningCase.Id, planningCaseVersions[1].PlanningCaseId);
            Assert.AreEqual(planningCase.PlanningId, planningCaseVersions[0].PlanningId);
            Assert.AreEqual(2, planningCaseVersions[1].Version);
        }

        [Test]
        public async Task PlanningCase_Delete_DoesDelete()
        {
            // Arrange
            var planning = new Planning();

            await planning.Create(DbContext);

            var commonTranslationModels = new List<PlanningNameTranslation>()
            {
                new PlanningNameTranslation()
                {
                    Name = Guid.NewGuid().ToString(),
                    Language = new Language()
                    {
                        Name = "Danish",
                        LanguageCode = "da"
                    },
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
                PlanningId = planning.Id,
            };

            await planningCase.Create(DbContext);
            // Act
            // itemCase = await DbContext.PlanningCases.AsNoTracking().FirstOrDefaultAsync();

            await planningCase.Delete(DbContext);

            var planningCases = DbContext.PlanningCases.AsNoTracking().ToList();
            var planningCaseVersions = DbContext.PlanningCaseVersions.AsNoTracking().ToList();

            // Assert
            Assert.AreEqual(1, planningCases.Count);
            Assert.AreEqual(2, planningCaseVersions.Count);
            Assert.AreEqual(planningCase.MicrotingSdkSiteId, planningCases[0].MicrotingSdkSiteId);
            Assert.AreEqual(planningCase.MicrotingSdkCaseId, planningCases[0].MicrotingSdkCaseId);
            Assert.AreEqual(planningCase.MicrotingSdkeFormId, planningCases[0].MicrotingSdkeFormId);
            Assert.AreEqual(planningCase.PlanningId, planningCases[0].PlanningId);
            Assert.AreEqual(planningCase.Status, planningCases[0].Status);
            Assert.AreEqual(Constants.WorkflowStates.Removed, planningCases[0].WorkflowState);
            Assert.AreEqual(planningCase.Id, planningCases[0].Id);
            Assert.AreEqual(2, planningCases[0].Version);

            Assert.AreEqual(planningCase.MicrotingSdkSiteId, planningCaseVersions[0].MicrotingSdkSiteId);
            Assert.AreEqual(planningCase.MicrotingSdkCaseId, planningCaseVersions[0].MicrotingSdkCaseId);
            Assert.AreEqual(planningCase.MicrotingSdkeFormId, planningCaseVersions[0].MicrotingSdkeFormId);
            Assert.AreEqual(planningCase.Status, planningCaseVersions[0].Status);
            Assert.AreEqual(Constants.WorkflowStates.Created, planningCaseVersions[0].WorkflowState);
            Assert.AreEqual(planningCase.Id, planningCaseVersions[0].PlanningCaseId);
            Assert.AreEqual(planningCase.PlanningId, planningCaseVersions[0].PlanningId);
            Assert.AreEqual(1, planningCaseVersions[0].Version);

            Assert.AreEqual(planningCase.MicrotingSdkSiteId, planningCaseVersions[1].MicrotingSdkSiteId);
            Assert.AreEqual(planningCase.MicrotingSdkCaseId, planningCaseVersions[1].MicrotingSdkCaseId);
            Assert.AreEqual(planningCase.MicrotingSdkeFormId, planningCaseVersions[1].MicrotingSdkeFormId);
            Assert.AreEqual(planningCase.PlanningId, planningCaseVersions[1].PlanningId);
            Assert.AreEqual(planningCase.Status, planningCaseVersions[1].Status);
            Assert.AreEqual(Constants.WorkflowStates.Removed, planningCaseVersions[1].WorkflowState);
            Assert.AreEqual(planningCase.Id, planningCaseVersions[1].PlanningCaseId);
            Assert.AreEqual(2, planningCaseVersions[1].Version);
        }
    }
}