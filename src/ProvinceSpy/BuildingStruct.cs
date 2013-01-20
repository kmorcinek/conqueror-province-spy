using System;

namespace ProvinceSpy
{
    [Serializable]
    public class BuildingStruct
    {
        public BuildingStruct()
        {
        }

        public int Power { get; set; }
        public CultureLevel Culture { get; set; }
        public Buildings Building { get; set; }
        public int TurnsNeeded { get; set; }

        public BuildingStruct(int power, CultureLevel culture, Buildings building, int turnsNeeded)
        {
            Power = power;
            Culture = culture;
            Building = building;
            TurnsNeeded = turnsNeeded;
        }

        public BuildingStruct(int power, int culture, int building, int turnsNeeded)
        {
            Power = power;
            Culture = (CultureLevel)culture;
            Building = (Buildings)building;
            TurnsNeeded = turnsNeeded;
        }
    }
}