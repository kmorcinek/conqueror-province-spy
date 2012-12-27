using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;

namespace ProvinceSpy
{
    public class Predictor
    {
        [Pure]
        public IEnumerable<BuildPrediction> Predict(ProvinceHistory provinceHistory)
        {
            Contract.Requires<ArgumentNullException>(provinceHistory != null);

            var lastBuilding = GetLastBuilt(provinceHistory.Revisions);

            return new[]
                {
                    lastBuilding.HasValue
                        ? new BuildPrediction {TurnsLeft = 4, Building = lastBuilding.Value}
                        : BuildPrediction.Unknown, 
                };
        }

        [Pure]
        internal Buildings? GetLastBuilt(ReadOnlyCollection<ProvinceRevision> revisions)
        {
            Contract.Requires<ArgumentException>(revisions != null);

            if (revisions.Count == 0) return null;

            var lastIndex = revisions.Count - 1;
            var last = revisions[lastIndex];
            var currentFarmsCount = last.FarmsCount;
            var currentCulture = last.CultureLevel;

            for (int i = lastIndex - 1; i >= 0; i--)
            {
                var currentRevision = revisions[i];
                if (currentRevision.FarmsCount < currentFarmsCount)
                {
                    return Buildings.Farm;
                }
                if ((int)currentRevision.CultureLevel < (int)currentCulture)
                {
                    return Buildings.Culture;
                }
            }

            return null;
        }
    }
}