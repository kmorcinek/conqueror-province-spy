using NUnit.Framework;
using FluentAssertions;

namespace ProvinceSpy.Tests
{
    [TestFixture]
    public class PredictorTests
    {
         [Test]
        public void GetLastBuilded_RevisionDiffersByFarms_FarmsWasBuilded()
         {
             var predictor = new Predictor();
             var provinceHistory = new ProvinceHistory("");
             provinceHistory.Add(new ProvinceRevision(1));
             provinceHistory.Add(new ProvinceRevision(2));

             predictor.GetLastBuilded(provinceHistory).Value.Should().Be(Buildings.Farm);
         }
    }
}