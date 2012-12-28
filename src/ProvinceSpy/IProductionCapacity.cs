namespace ProvinceSpy
{
    public interface IProductionCapacity
    {
        int Calculate(ProvinceRevision lastRevision);
    }
}