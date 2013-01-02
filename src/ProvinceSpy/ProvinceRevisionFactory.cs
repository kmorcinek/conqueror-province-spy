namespace ProvinceSpy
{
    public class ProvinceRevisionFactory
    {
        public static ProvinceRevision FromFarmsCount(int farms)
        {
            return new ProvinceRevision(farmsCount: farms, cultureLevel:CultureLevel.Primitive, soldiersCount:0, resourcesCount:0);
        }
        
        public static ProvinceRevision FromCulture(CultureLevel cultureLevel)
        {
            return new ProvinceRevision(farmsCount: 0, cultureLevel: cultureLevel, soldiersCount: 0, resourcesCount: 0);
        }
        
        public static ProvinceRevision FromSoldiersCount(int soldiers)
        {
            return new ProvinceRevision(farmsCount: 0, cultureLevel: CultureLevel.Primitive, soldiersCount: soldiers, resourcesCount: 0);
        }

        public static ProvinceRevision FromFarmsAndCulture(int farms, CultureLevel cultureLevel)
        {
            return new ProvinceRevision(farmsCount: farms, cultureLevel: cultureLevel, soldiersCount: 0, resourcesCount: 0);
        }

        public static ProvinceRevision FromFarmsResourcesAndCulture(int farms, int resources, CultureLevel cultureLevel)
        {
            return new ProvinceRevision(farms, resources, cultureLevel: cultureLevel, soldiersCount: 0);
        }
    }
}