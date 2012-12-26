﻿using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace ProvinceSpy
{
    public class Predictor
    {
        [Pure]
        public IEnumerable<BuildPrediction> Predict(ProvinceHistory provinceHistory)
        {
            Buildings? lastBuilding = GetLastBuilded(provinceHistory);
            return new BuildPrediction[0];
            return new []
                {
                    new BuildPrediction{TurnsLeft = 4, Building = Buildings.Farm}, 
                };
        }

        [Pure]
        internal Buildings? GetLastBuilded(ProvinceHistory provinceHistory)
        {
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