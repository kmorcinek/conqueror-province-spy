namespace ProvinceSpy
{
    public class ProvinceRevision
    {
        private readonly int farmsCount;
        private readonly CultureLevel cultureLevel;

        public ProvinceRevision(int farmsCount, CultureLevel cultureLevel)
        {
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
    }
}