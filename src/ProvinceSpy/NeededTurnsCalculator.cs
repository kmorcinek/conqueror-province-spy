namespace ProvinceSpy
{
    public class NeededTurnsCalculator
    {
        private readonly IProductionCost productionCost;
        private readonly IProductionCapacity productionCapacity;

        public NeededTurnsCalculator()
            : this(new ProductionCapacity(), new ProductionCost())
        {

        }

        public NeededTurnsCalculator(IProductionCapacity productionCapacity, IProductionCost productionCost)
        {
            this.productionCapacity = productionCapacity;
            this.productionCost = productionCost;
        }

        public int Calculate(ProvinceRevision revision, Buildings building)
        {
            int capacity = productionCapacity.Calculate(revision);
            int cost = productionCost.Calculate(revision, building);

            return cost / capacity;
        }
    }
}