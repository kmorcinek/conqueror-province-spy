namespace ProvinceSpy
{
    public class ProvinceRevision
    {
        private readonly int farmsCount;
        private readonly CultureLevel cultureLevel;
        private int soldiersCount;

        public ProvinceRevision(int farmsCount, int soldiersCount, CultureLevel cultureLevel)
        {
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
    }
}