using System;
using System.Diagnostics.Contracts;

namespace ProvinceSpy
{
    public class ProvinceRevision
    {
        private readonly int farmsCount;
        private readonly CultureLevel cultureLevel;
        private readonly int soldiersCount;
        private readonly int resourcesCount;

        public ProvinceRevision(int farmsCount, int resourcesCount, int soldiersCount, CultureLevel cultureLevel)
        {
            Contract.Requires<ArgumentOutOfRangeException>(0 <= resourcesCount && resourcesCount <= 2);

            this.resourcesCount = resourcesCount;
            this.soldiersCount = soldiersCount;
            this.cultureLevel = cultureLevel;
            this.farmsCount = farmsCount;
        }

        public int FarmsCount
        {
            get { return farmsCount; }
        }

        public CultureLevel CultureLevel
        {
            get { return cultureLevel; }
        }

        public int SoldiersCount
        {
            get { return soldiersCount; }
        }

        public int ResourcesCount
        {
            get { return resourcesCount; }
        }
    }
}