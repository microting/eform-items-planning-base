using Microting.eForm.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.ItemsPlanningBase.Infrastructure.Data.Entities
{
    public class PlanningTagVersion : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey("PlanningTag")]
        public int PlanningTagId { get; set; }
    }
}
