using NUnit.Framework;
using FluentAssertions;

namespace ProvinceSpy.Tests
{
    [TestFixture]
    public class PredictorTests
    {
        [Test]
        public void GetLastBuilt_RevisionDiffersByFarms_FarmWasBuilt()
        {
            var predictor = new Predictor();
            var provinceHistory = new ProvinceHistory("");
            provinceHistory.Add(ProvinceRevisionFactory.FromFarmsCount(1));
            provinceHistory.Add(ProvinceRevisionFactory.FromFarmsCount(2));

            predictor.GetLastBuilt(provinceHistory.Revisions).Value.Should().Be(Buildings.Farm);
        }

        [Test]
        public void Predict_NoChangesInRevisions_NothingWasBuilt()
        {
            var predictor = new Predictor();
            var provinceHistory = new ProvinceHistory("");
            provinceHistory.Add(ProvinceRevisionFactory.FromFarmsCount(2));
            provinceHistory.Add(ProvinceRevisionFactory.FromFarmsCount(2));

            predictor.GetLastBuilt(provinceHistory.Revisions).HasValue.Should().BeFalse();
        }
    }
}