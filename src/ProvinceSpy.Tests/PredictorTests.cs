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
            provinceHistory.Add(new ProvinceRevision(1));
            provinceHistory.Add(new ProvinceRevision(2));

            predictor.GetLastBuilt(provinceHistory).Value.Should().Be(Buildings.Farm);
        }

        [Test]
        public void Predict_NoChangesInRevisions_NothingWasBuilt()
        {
            var predictor = new Predictor();
            var provinceHistory = new ProvinceHistory("");
            provinceHistory.Add(new ProvinceRevision(2));
            provinceHistory.Add(new ProvinceRevision(2));

            predictor.GetLastBuilt(provinceHistory).HasValue.Should().BeFalse();
        }
    }
}