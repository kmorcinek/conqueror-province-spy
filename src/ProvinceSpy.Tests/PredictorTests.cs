using NUnit.Framework;
using FluentAssertions;

namespace ProvinceSpy.Tests
{
    [TestFixture]
    public class PredictorTests
    {
        private Predictor predictor;
        private ProvinceHistory provinceHistory;

        [SetUp]
        public void SetUp()
        {
            predictor = new Predictor();
            provinceHistory = new ProvinceHistory("");
        }

        [Test]
        public void GetLastBuilt_RevisionDiffersByFarms_FarmWasBuilt()
        {
            provinceHistory.Add(ProvinceRevisionFactory.FromFarmsCount(1));
            provinceHistory.Add(ProvinceRevisionFactory.FromFarmsCount(2));

            predictor.GetLastBuilt(provinceHistory.Revisions).Value.Should().Be(Buildings.Farm);
        }

        [Test]
        public void GetLastBuilt_NoChangesInRevisions_NothingWasBuilt()
        {
            provinceHistory.Add(ProvinceRevisionFactory.FromFarmsCount(2));
            provinceHistory.Add(ProvinceRevisionFactory.FromFarmsCount(2));

            predictor.GetLastBuilt(provinceHistory.Revisions).HasValue.Should().BeFalse();
        }

        [Test]
        public void GetLastBuilt_RevisionDiffersBySoldiers_SoldierWasBuilt()
        {
            provinceHistory.Add(ProvinceRevisionFactory.FromSoldiersCount(5));
            provinceHistory.Add(ProvinceRevisionFactory.FromSoldiersCount(6));

            predictor.GetLastBuilt(provinceHistory.Revisions).Value.Should().Be(Buildings.Soldiers);
        }

        [Test]
        public void GetLastBuilt_RevisionDiffersByCulture_CultureWasBuilt()
        {
            provinceHistory.Add(ProvinceRevisionFactory.FromCulture(CultureLevel.Developed));
            provinceHistory.Add(ProvinceRevisionFactory.FromCulture(CultureLevel.Advanced));

            predictor.GetLastBuilt(provinceHistory.Revisions).Value.Should().Be(Buildings.Culture);
        }

        [Test]
        public void GetLastBuilt_RevisionDiffersByCultureAndThenByFarms_FarmWasBuilt()
        {
            provinceHistory.Add(ProvinceRevisionFactory.FromFarmsAndCulture(3, CultureLevel.Primitive));
            provinceHistory.Add(ProvinceRevisionFactory.FromFarmsAndCulture(3, CultureLevel.Developed));
            provinceHistory.Add(ProvinceRevisionFactory.FromFarmsAndCulture(4, CultureLevel.Developed));

            predictor.GetLastBuilt(provinceHistory.Revisions).Value.Should().Be(Buildings.Farm);
        }
    }
}