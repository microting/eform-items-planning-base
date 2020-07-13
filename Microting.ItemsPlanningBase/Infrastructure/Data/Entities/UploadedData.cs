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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.ItemsPlanningBase.Infrastructure.Data.Entities
{
    public class UploadedData : BaseEntity
    {
        [ForeignKey("PlanningCase")]
        public int PlanningCaseId { get; set; }
        
        [StringLength(255)]
        public string Checksum { get; set; }

        [StringLength(255)]
        public string Extension { get; set; }

        [StringLength(255)]
        public string CurrentFile { get; set; }

        [StringLength(255)]
        public string UploaderType { get; set; }

        [StringLength(255)]
        public string FileLocation { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        public async Task Create(ItemsPlanningPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            await dbContext.UploadedDatas.AddAsync(this);
            await dbContext.SaveChangesAsync();

            await dbContext.UploadedDataVersions.AddAsync(MapVersion(this));
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(ItemsPlanningPnDbContext dbContext)
        {
            UploadedData uploadedData = await dbContext.UploadedDatas.FirstOrDefaultAsync(x => x.Id == Id);

            if (uploadedData == null)
            {
                throw new NullReferenceException($"Could not find uploadedData with id: {Id}");
            }

            uploadedData.PlanningCaseId = PlanningCaseId;
            uploadedData.Checksum = Checksum;
            uploadedData.Extension = Extension;
            uploadedData.CurrentFile = CurrentFile;
            uploadedData.UploaderType = UploaderType;
            uploadedData.FileLocation = FileLocation;
            uploadedData.FileName = FileName;
            uploadedData.WorkflowState = WorkflowState;

            if (dbContext.ChangeTracker.HasChanges())
            {
                uploadedData.UpdatedAt = DateTime.UtcNow;
                uploadedData.Version += 1;

                await dbContext.UploadedDataVersions.AddAsync(MapVersion(uploadedData));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(ItemsPlanningPnDbContext dbContext)
        {
            UploadedData uploadedData = await dbContext.UploadedDatas.FirstOrDefaultAsync(x => x.Id == Id);

            if (uploadedData == null)
            {
                throw new NullReferenceException($"Could not find uploadedData with id: {Id}");
            }

            uploadedData.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                uploadedData.UpdatedAt = DateTime.UtcNow;
                uploadedData.Version += 1;

                await dbContext.UploadedDataVersions.AddAsync(MapVersion(uploadedData));
                await dbContext.SaveChangesAsync();
            }
        }

        private UploadedDataVersion MapVersion(UploadedData uploadedData)
        {
            UploadedDataVersion uploadedDataVersion = new UploadedDataVersion()
            {
                PlanningCaseId = uploadedData.PlanningCaseId,
                Checksum = uploadedData.Checksum,
                Extension = uploadedData.Extension,
                CurrentFile = uploadedData.CurrentFile,
                UploaderType = uploadedData.UploaderType,
                FileLocation = uploadedData.FileLocation,
                FileName = uploadedData.FileName,
                UploadedDataId = uploadedData.Id,
                Version = uploadedData.Version,
                CreatedAt = uploadedData.CreatedAt,
                CreatedByUserId = uploadedData.CreatedByUserId,
                UpdatedAt = uploadedData.UpdatedAt,
                UpdatedByUserId = uploadedData.UpdatedByUserId,
                WorkflowState = uploadedData.WorkflowState
            };

            return uploadedDataVersion;
        }

    }
}