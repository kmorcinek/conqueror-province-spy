using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ProvinceSpy
{
    public class Predictor
    {
        [Pure]
        public IEnumerable<BuildPrediction> Predict(ProvinceHistory provinceHistory)
        {
            Contract.Requires<ArgumentNullException>(provinceHistory != null);
            //            Contract.Requires<ArgumentException>(provinceHistory.Revisions != null);

            var lastBuilding = GetLastBuilt(provinceHistory);

            return new[]
                {
                    lastBuilding.HasValue
                        ? new BuildPrediction {TurnsLeft = 4, Building = lastBuilding.Value}
                        : BuildPrediction.Unknown, 
                };
        }

        [Pure]
        internal Buildings? GetLastBuilt(ProvinceHistory provinceHistory)
        {
            if (provinceHistory.Revisions.Count == 0) return null;

            var lastIndex = provinceHistory.Revisions.Count - 1;
            var last = provinceHistory.Revisions[lastIndex];
            var currentFarmsCount = last.FarmsCount;

            for (int i = lastIndex - 1; i >= 0; i--)
            {
                var currentRevision = provinceHistory.Revisions[i];
                if (currentRevision.FarmsCount < currentFarmsCount)
                {
                    return Buildings.Farm;
                }
            }

            return null;
        }
    }
}