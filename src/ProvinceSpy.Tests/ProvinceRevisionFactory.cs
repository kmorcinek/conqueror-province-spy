namespace ProvinceSpy.Tests
{
    public class ProvinceRevisionFactory
    {
        public static ProvinceRevision FromFarmsCount(int farms)
        {
            return new ProvinceRevision(farmsCount: farms, cultureLevel:CultureLevel.Primitive);
        }
        
        public static ProvinceRevision FromCulture(CultureLevel cultureLevel)
        {
            return new ProvinceRevision(farmsCount: 0, cultureLevel:cultureLevel);
        }
    }
}