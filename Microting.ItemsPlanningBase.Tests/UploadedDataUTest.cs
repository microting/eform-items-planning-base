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
            PlanningId = planning.Id,
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
        Assert.NotNull(dbUploadedData);

        Assert.AreEqual(1, uploadedDataList.Count);
        Assert.AreEqual(1, uploadedDataVersionList.Count);

        Assert.AreEqual(uploadedData.Checksum, dbUploadedData.Checksum);
        Assert.AreEqual(uploadedData.Extension, dbUploadedData.Extension);
        Assert.AreEqual(uploadedData.CurrentFile, dbUploadedData.CurrentFile);
        Assert.AreEqual(uploadedData.UploaderType, dbUploadedData.UploaderType);
        Assert.AreEqual(uploadedData.FileLocation, dbUploadedData.FileLocation);
        Assert.AreEqual(uploadedData.FileName, dbUploadedData.FileName);
        Assert.AreEqual(uploadedData.PlanningCaseId, dbUploadedData.PlanningCaseId);
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
            PlanningId = planning.Id,
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
        Assert.NotNull(dbUploadedData);

        Assert.AreEqual(1, uploadedDataList.Count);
        Assert.AreEqual(2, uploadedDataVersionList.Count);

        Assert.AreEqual(newCheckSum, dbUploadedData.Checksum);
        Assert.AreEqual(newExtension, dbUploadedData.Extension);
        Assert.AreEqual(newCurrentFile, dbUploadedData.CurrentFile);
        Assert.AreEqual(newUploaderType, dbUploadedData.UploaderType);
        Assert.AreEqual(newFileLocation, dbUploadedData.FileLocation);
        Assert.AreEqual(newFileName, dbUploadedData.FileName);
        Assert.AreEqual(uploadedData.PlanningCaseId, dbUploadedData.PlanningCaseId);
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
            PlanningId = planning.Id,
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
        Assert.NotNull(dbUploadedData);

        Assert.AreEqual(1, uploadedDataList.Count);
        Assert.AreEqual(2, uploadedDataVersionList.Count);

        Assert.AreEqual(uploadedData.Checksum, dbUploadedData.Checksum);
        Assert.AreEqual(uploadedData.Extension, dbUploadedData.Extension);
        Assert.AreEqual(uploadedData.CurrentFile, dbUploadedData.CurrentFile);
        Assert.AreEqual(uploadedData.UploaderType, dbUploadedData.UploaderType);
        Assert.AreEqual(uploadedData.FileLocation, dbUploadedData.FileLocation);
        Assert.AreEqual(uploadedData.FileName, dbUploadedData.FileName);
        Assert.AreEqual(uploadedData.PlanningCaseId, dbUploadedData.PlanningCaseId);
        Assert.AreEqual(Constants.WorkflowStates.Removed, dbUploadedData.WorkflowState);
    }

}