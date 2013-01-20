using System.Collections.Generic;
using NUnit.Framework;
using FluentAssertions;

namespace ProvinceSpy.Tests
{
    [TestFixture]
    public class ProductionCostTests
    {
        private ProductionCost productionCost;

        [SetUp]
        public void SetUp()
        {
            productionCost = new ProductionCost();
        }

        [Test]
        public void Calculate_Soldier_Costs5()
        {
            productionCost.Calculate(null, Buildings.Soldiers).Should().Be(5);
        }

        [Test]
        public void Calculate_Having3FarmsBuildFouthFarm_Costs16()
        {
            var revision = ProvinceRevisionFactory.FromFarmsCount(3);

            productionCost.Calculate(revision, Buildings.Farm).Should().Be(16);
        }

        [Test]
        public void Calculate_Having1FarmsBuildSecondFarm_Costs4()
        {
            var revision = ProvinceRevisionFactory.FromFarmsCount(1);

            productionCost.Calculate(revision, Buildings.Farm).Should().Be(4);
        }

        [Test]
        public void Calculate_Development_Costs60()
        {
            // TODO Fortification assuming Fort (not castle), the same with culture
            productionCost.Calculate(null, Buildings.Culture).Should().Be(60);
        }
    }
}