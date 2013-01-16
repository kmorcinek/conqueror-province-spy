namespace ProvinceSpy
{
    public class NeededTurnsCalculator : INeededTurnsCalculator
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
            if (revision.FarmsCount == 3 && revision.CultureLevel == CultureLevel.Primitive)
            {
                if (building == Buildings.Culture)
                {
                    return 10;
                }
                if (building == Buildings.Fortification)
                {
                    return 6;
                }
            }

            int capacity = productionCapacity.Calculate(revision);
            int cost = productionCost.Calculate(revision, building);

            return cost / capacity;
        }
    }
}