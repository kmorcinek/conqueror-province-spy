using NUnit.Framework;
using FluentAssertions;

namespace ProvinceSpy.Tests
{
    [TestFixture]
    public class ProductionCapacityTests
    {
        private ProductionCapacity productionCapacity;

        [SetUp]
        public void SetUp()
        {
            productionCapacity = new ProductionCapacity();
        }

        [Test]
        public void Calculate_TwoFarms_CapacityIs1()
        {
            var revision = ProvinceRevisionFactory.FromFarmsAndCulture(2, CultureLevel.Primitive);

            productionCapacity.Calculate(revision).Should().Be(2);
        }
         
    }
}