using System.Collections.Generic;

namespace ProvinceSpy
{
    public class NeededTurnsCalculator : INeededTurnsCalculator
    {
        private readonly IProductionCost productionCost;
        private readonly IProductionCapacity productionCapacity;
        private Dictionary<BuildingStruct, int> turns = new Dictionary<BuildingStruct, int>();

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
//            var triple = new BuildingStruct(revision.Power, revision.CultureLevel, building);
//            int turnsNeeded;
//            if (turns.TryGetValue(triple, out turnsNeeded))
//            {
//                return turnsNeeded;
//            }

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