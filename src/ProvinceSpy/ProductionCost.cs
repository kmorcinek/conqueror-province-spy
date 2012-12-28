using System;

namespace ProvinceSpy
{
    public class ProductionCost : IProductionCost
    {
        public int Calculate(ProvinceRevision revision, Buildings target)
        {
            switch (target)
            {
                case Buildings.Soldiers:
                    return 5;
                case Buildings.Fortification:
                    return 50;
                case Buildings.Farm:
                    return (revision.FarmsCount + 1) * (revision.FarmsCount + 1);
                case Buildings.Culture:
                    return 60;
                //                case Buildings.Unknown:
                //                    break;
                default:
                    throw new ArgumentOutOfRangeException("target");
            }
        }
    }
}