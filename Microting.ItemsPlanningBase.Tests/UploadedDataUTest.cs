using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eForm.Infrastructure.Data.Entities;
using Microting.ItemsPlanningBase.Infrastructure.Data.Entities;
using NUnit.Framework;
using UploadedData = Microting.ItemsPlanningBase.Infrastructure.Data.Entities.UploadedData;

namespace Microting.ItemsPlanningBase.Tests;

[TestFixture]
public class UploadedDataUTest : DbTestFixture
{
    [Test]
    public async Task UploadedData_Create_DoesCreate()
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

        var uploadedData = new UploadedData
        {
            PlanningCaseId = planningCase.Id,
            Checksum = Guid.NewGuid().ToString(),
            Extension = Guid.NewGuid().ToString(),
            CurrentFile = Guid.NewGuid().ToString(),
            UploaderType = Guid.NewGuid().ToString(),
            FileLocation = Guid.NewGuid().ToString(),
            FileName = Guid.NewGuid().ToString()
        };
        //Act
        await uploadedData.Create(DbContext);

        var dbUploadedData = DbContext.UploadedDatas.AsNoTracking().First();
        var uploadedDataList = DbContext.UploadedDatas.AsNoTracking().ToList();
        var uploadedDataVersionList = DbContext.UploadedDataVersions.AsNoTracking().ToList();
        //Assert
        Assert.That(dbUploadedData, Is.Not.Null);

        Assert.That(uploadedDataList.Count, Is.EqualTo(1));
        Assert.That(uploadedDataVersionList.Count, Is.EqualTo(1));

        Assert.That(dbUploadedData.Checksum, Is.EqualTo(uploadedData.Checksum));
        Assert.That(dbUploadedData.Extension, Is.EqualTo(uploadedData.Extension));
        Assert.That(dbUploadedData.CurrentFile, Is.EqualTo(uploadedData.CurrentFile));
        Assert.That(dbUploadedData.UploaderType, Is.EqualTo(uploadedData.UploaderType));
        Assert.That(dbUploadedData.FileLocation, Is.EqualTo(uploadedData.FileLocation));
        Assert.That(dbUploadedData.FileName, Is.EqualTo(uploadedData.FileName));
        Assert.That(dbUploadedData.PlanningCaseId, Is.EqualTo(uploadedData.PlanningCaseId));
    }

    [Test]
    public async Task UploadedData_Update_DoesUpdate()
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

        var uploadedData = new UploadedData
        {
            PlanningCaseId = planningCase.Id,
            Checksum = Guid.NewGuid().ToString(),
            Extension = Guid.NewGuid().ToString(),
            CurrentFile = Guid.NewGuid().ToString(),
            UploaderType = Guid.NewGuid().ToString(),
            FileLocation = Guid.NewGuid().ToString(),
            FileName = Guid.NewGuid().ToString()
        };
        await uploadedData.Create(DbContext);

        var newCheckSum = Guid.NewGuid().ToString();
        var newExtension = Guid.NewGuid().ToString();
        var newCurrentFile = Guid.NewGuid().ToString();
        var newUploaderType = Guid.NewGuid().ToString();
        var newFileLocation = Guid.NewGuid().ToString();
        var newFileName = Guid.NewGuid().ToString();

        uploadedData.Checksum = newCheckSum;
        uploadedData.Extension = newExtension;
        uploadedData.CurrentFile = newCurrentFile;
        uploadedData.UploaderType = newUploaderType;
        uploadedData.FileLocation = newFileLocation;
        uploadedData.FileName = newFileName;
        //Act
        await uploadedData.Update(DbContext);

        var dbUploadedData = DbContext.UploadedDatas.AsNoTracking().First();
        var uploadedDataList = DbContext.UploadedDatas.AsNoTracking().ToList();
        var uploadedDataVersionList = DbContext.UploadedDataVersions.AsNoTracking().ToList();
        //Assert
        Assert.That(dbUploadedData, Is.Not.Null);

        Assert.That(uploadedDataList.Count, Is.EqualTo(1));
        Assert.That(uploadedDataVersionList.Count, Is.EqualTo(2));

        Assert.That(dbUploadedData.Checksum, Is.EqualTo(newCheckSum));
        Assert.That(dbUploadedData.Extension, Is.EqualTo(newExtension));
        Assert.That(dbUploadedData.CurrentFile, Is.EqualTo(newCurrentFile));
        Assert.That(dbUploadedData.UploaderType, Is.EqualTo(newUploaderType));
        Assert.That(dbUploadedData.FileLocation, Is.EqualTo(newFileLocation));
        Assert.That(dbUploadedData.FileName, Is.EqualTo(newFileName));
        Assert.That(dbUploadedData.PlanningCaseId, Is.EqualTo(uploadedData.PlanningCaseId));
    }

    [Test]
    public async Task UploadedData_Delete_DoesDelete()
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

        var uploadedData = new UploadedData
        {
            PlanningCaseId = planningCase.Id,
            Checksum = Guid.NewGuid().ToString(),
            Extension = Guid.NewGuid().ToString(),
            CurrentFile = Guid.NewGuid().ToString(),
            UploaderType = Guid.NewGuid().ToString(),
            FileLocation = Guid.NewGuid().ToString(),
            FileName = Guid.NewGuid().ToString()
        };
        await uploadedData.Create(DbContext);

        //Act
        await uploadedData.Delete(DbContext);

        var dbUploadedData = DbContext.UploadedDatas.AsNoTracking().First();
        var uploadedDataList = DbContext.UploadedDatas.AsNoTracking().ToList();
        var uploadedDataVersionList = DbContext.UploadedDataVersions.AsNoTracking().ToList();
        //Assert
        Assert.That(dbUploadedData, Is.Not.Null);

        Assert.That(uploadedDataList.Count, Is.EqualTo(1));
        Assert.That(uploadedDataVersionList.Count, Is.EqualTo(2));

        Assert.That(dbUploadedData.Checksum, Is.EqualTo(uploadedData.Checksum));
        Assert.That(dbUploadedData.Extension, Is.EqualTo(uploadedData.Extension));
        Assert.That(dbUploadedData.CurrentFile, Is.EqualTo(uploadedData.CurrentFile));
        Assert.That(dbUploadedData.UploaderType, Is.EqualTo(uploadedData.UploaderType));
        Assert.That(dbUploadedData.FileLocation, Is.EqualTo(uploadedData.FileLocation));
        Assert.That(dbUploadedData.FileName, Is.EqualTo(uploadedData.FileName));
        Assert.That(dbUploadedData.PlanningCaseId, Is.EqualTo(uploadedData.PlanningCaseId));
        Assert.That(dbUploadedData.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
    }

}