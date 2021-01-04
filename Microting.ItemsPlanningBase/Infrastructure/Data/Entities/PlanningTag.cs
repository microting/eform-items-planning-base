using System.ComponentModel.DataAnnotations;

namespace Microting.ItemsPlanningBase.Infrastructure.Data.Entities
{
    public class PlanningTag : PnBase
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}
