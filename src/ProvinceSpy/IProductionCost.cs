namespace ProvinceSpy
{
    public interface IProductionCost
    {
        int Calculate(ProvinceRevision revision, Buildings target);
    }
}