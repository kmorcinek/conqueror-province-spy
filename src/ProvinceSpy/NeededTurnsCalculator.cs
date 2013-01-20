using System.Collections.Generic;
using System.IO;

namespace ProvinceSpy
{
    public class NeededTurnsCalculator : INeededTurnsCalculator
    {
        private readonly IProductionCost productionCost;
        private readonly IProductionCapacity productionCapacity;
        private Dictionary<BuildingTriple, int> turns = new Dictionary<BuildingTriple, int>();

        public NeededTurnsCalculator()
            : this(new ProductionCapacity(), new ProductionCost())
        {
            CreateTurns();
        }

        private void CreateTurns()
        {
            var str = File.ReadAllText(Common.BuildingTakingTurnsPath);

            var list = JsonNetSerializer.DeserializeFromString<List<BuildingStruct>>(str);

            foreach (var buildingStruct in list)
            {
                turns.Add(new BuildingTriple(buildingStruct), buildingStruct.TurnsNeeded); 
            }
        }

        public NeededTurnsCalculator(IProductionCapacity productionCapacity, IProductionCost productionCost)
        {
            this.productionCapacity = productionCapacity;
            this.productionCost = productionCost;
        }

        public int Calculate(ProvinceRevision revision, Buildings building)
        {
            var triple = new BuildingTriple(revision.Power, revision.CultureLevel, building);
            int turnsNeeded;
            if (turns.TryGetValue(triple, out turnsNeeded))
            {
                return turnsNeeded;
            }

//            if (revision.FarmsCount == 3 && revision.CultureLevel == CultureLevel.Primitive)
//            {
//                if (building == Buildings.Culture)
//                {
//                    return 10;
//                }
//                if (building == Buildings.Fortification)
//                {
//                    return 6;
//                }
//            }

            return 99;

            int capacity = productionCapacity.Calculate(revision);
            int cost = productionCost.Calculate(revision, building);

            return cost / capacity;
        }
    }
}