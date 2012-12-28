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
//                case Buildings.Diplomats:
//                    break;
//                case Buildings.Fortification:
//                    break;
//                case Buildings.Farm:
//                    break;
//                case Buildings.Gold:
//                    break;
//                case Buildings.Culture:
//                    break;
//                case Buildings.Unknown:
//                    break;
                default:
                    throw new ArgumentOutOfRangeException("target");
            }
        } 
    }
}