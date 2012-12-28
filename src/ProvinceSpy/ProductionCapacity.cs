namespace ProvinceSpy
{
    public class ProductionCapacity : IProductionCapacity
    {
        public int Calculate(ProvinceRevision revision)
        {
            return revision.FarmsCount*(int) revision.CultureLevel;
        }
    }
}