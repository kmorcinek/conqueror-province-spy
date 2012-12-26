namespace ProvinceSpy
{
    public class ProvinceRevision
    {
        private readonly int farmsCount;

        public ProvinceRevision(int farmsCount)
        {
            this.farmsCount = farmsCount;
        }

        public int FarmsCount
        {
            get { return farmsCount; }
        }
    }
}