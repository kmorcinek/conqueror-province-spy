namespace ProvinceSpy
{
    public class ProductionCapacity : IProductionCapacity
    {
        public int Calculate(ProvinceRevision revision)
        {
            return (revision.FarmsCount + revision.ResourcesCount)*(int) revision.CultureLevel;
        }
    }
}