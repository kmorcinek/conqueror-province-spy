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
        internal int? GetTurnsFromLastBuilt(ReadOnlyCollection<ProvinceRevision> revisions)
        {
            var result = GetLastBuiltAndTurnAgo(revisions);

            int? turnsAgo = null;
            if (result.HasValue)
                turnsAgo = result.Value.TurnsAge;

            return turnsAgo;
        }

        [Pure]
        internal Buildings? GetLastBuilt(ReadOnlyCollection<ProvinceRevision> revisions)
        {
            var result = GetLastBuiltAndTurnAgo(revisions);

            Buildings? lastBuilt = null;
            if (result.HasValue)
                lastBuilt = result.Value.Builded;

            return lastBuilt;
        }

        private static BuiltAndTurnsAgo? GetLastBuiltAndTurnAgo(ReadOnlyCollection<ProvinceRevision> revisions)
        {
            Contract.Requires<ArgumentException>(revisions != null);

            if (revisions.Count == 0) return null;

            var lastIndex = revisions.Count - 1;
            var last = LastRevision(revisions);
            var currentFarmsCount = last.FarmsCount;
            var currentSoldiersCount = last.SoldiersCount;
            var currentCulture = last.CultureLevel;

            for (int i = lastIndex - 1; i >= 0; i--)
            {
                var currentRevision = revisions[i];
                if (currentRevision.FarmsCount < currentFarmsCount)
                {
                    return new BuiltAndTurnsAgo(Buildings.Farm, lastIndex - i);
                }
                if (currentRevision.SoldiersCount < currentSoldiersCount)
                {
                    return new BuiltAndTurnsAgo(Buildings.Soldiers, lastIndex - i);
                }
                if ((int)currentRevision.CultureLevel < (int)currentCulture)
                {
                    return new BuiltAndTurnsAgo(Buildings.Culture, lastIndex - i);
                }
            }

            return null;
        }

        private static ProvinceRevision LastRevision(ReadOnlyCollection<ProvinceRevision> revisions)
        {
            return revisions[revisions.Count - 1];
        }

        private struct BuiltAndTurnsAgo
        {
            public Buildings Builded;
            public int TurnsAge;

            public BuiltAndTurnsAgo(Buildings builded, int turnsAge)
            {
                Builded = builded;
                TurnsAge = turnsAge;
            }
        }
    }
}