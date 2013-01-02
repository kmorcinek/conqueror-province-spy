using System;
using System.Diagnostics.Contracts;

namespace ProvinceSpy
{
    public class ProvinceRevision
    {
        private readonly int farmsCount;
        private readonly CultureLevel cultureLevel;
        private readonly int soldiersCount;
        private readonly Resource resourceLevel;

        public ProvinceRevision(int farmsCount, Resource resourceLevel, int soldiersCount, CultureLevel cultureLevel)
        {
            this.resourceLevel = resourceLevel;
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

        public Resource ResourceLevel
        {
            get { return resourceLevel; }
        }
    }
}