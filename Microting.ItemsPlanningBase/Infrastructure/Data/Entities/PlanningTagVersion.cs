using Microting.eForm.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Microting.ItemsPlanningBase.Infrastructure.Data.Entities
{
    public class PlanningTagVersion : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey("PlanningTag")]
        public int PlanningTagId { get; set; }
    }
}
