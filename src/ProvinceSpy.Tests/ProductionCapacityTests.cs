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
        public void Calculate_TwoFarms_CapacityIs2()
        {
            var revision = ProvinceRevisionFactory.FromFarmsAndCulture(2, CultureLevel.Primitive);

            productionCapacity.Calculate(revision).Should().Be(2);
        }

        [Test]
        public void Calculate_TwoFarmsAndOneResource_CapacityIs3()
        {
            var revision = ProvinceRevisionFactory.FromFarmsResourcesAndCulture(2, 1, CultureLevel.Primitive);

            productionCapacity.Calculate(revision).Should().Be(3);
        }

        [Test]
        public void Calculate_TwoFarmsAndTwoResources_CapacityIs4()
        {
            var revision = ProvinceRevisionFactory.FromFarmsResourcesAndCulture(2, 2, CultureLevel.Primitive);

            productionCapacity.Calculate(revision).Should().Be(4);
        }
    }
}