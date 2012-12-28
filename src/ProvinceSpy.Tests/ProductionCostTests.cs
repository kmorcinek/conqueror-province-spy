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
    }
}