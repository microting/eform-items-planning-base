using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Microting.ItemsPlanningBase.Infrastructure.Data.Entities
{
    public class PlanningTag : PnBase
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}
