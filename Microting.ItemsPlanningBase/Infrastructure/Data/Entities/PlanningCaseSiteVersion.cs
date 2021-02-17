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
using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.ItemsPlanningBase.Infrastructure.Data.Entities
{
    public class PlanningCaseSiteVersion : BaseEntity
    {
        public int MicrotingSdkSiteId { get; set; }
        
        public int MicrotingSdkeFormId { get; set; }
        
        public int Status { get; set; }
        
        public string FieldStatus { get; set; }
        
        public int MicrotingSdkCaseId { get; set; }
        
        public DateTime? MicrotingSdkCaseDoneAt { get; set; }
        
        public int NumberOfImages { get; set; }
        
        public string Comment { get; set; }
        
        public string Location { get; set; }
                
        public int PlanningId { get; set; }

        [ForeignKey("PlanningCaseSite")]
        public int PlanningCaseSiteId { get; set; }
        
        public string SdkFieldValue1 { get; set; }
        
        public string SdkFieldValue2 { get; set; }
        
        public string SdkFieldValue3 { get; set; }
        
        public string SdkFieldValue4 { get; set; }
        
        public string SdkFieldValue5 { get; set; }
        
        public string SdkFieldValue6 { get; set; }
        
        public string SdkFieldValue7 { get; set; }
        
        public string SdkFieldValue8 { get; set; }
        
        public string SdkFieldValue9 { get; set; }
        
        public string SdkFieldValue10 { get; set; }
        
        public int DoneByUserId { get; set; }
        
        public string DoneByUserName { get; set; }
        
        public int PlanningCaseId { get; set; }
    }
}