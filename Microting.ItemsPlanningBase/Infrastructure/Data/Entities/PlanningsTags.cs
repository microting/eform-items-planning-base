namespace Microting.ItemsPlanningBase.Infrastructure.Data.Entities
{
    public class PlanningsTags : PnBase
    {
        public int PlanningTagId { get; set; }
        public virtual PlanningTag PlanningTag { get; set; }

        public int PlanningId { get; set; }
        public virtual Planning Planning { get; set; }
    }
}
