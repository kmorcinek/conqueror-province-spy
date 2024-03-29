﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using Autofac;

namespace ProvinceSpy
{
    public class Predictor
    {
        [Pure]
        public IEnumerable<BuildPrediction> Predict(ProvinceHistory provinceHistory)
        {
            Contract.Requires<ArgumentNullException>(provinceHistory != null);

            var lastBuilding = GetLastBuilt(provinceHistory.Revisions);

            BuildPrediction prediction;
            if (lastBuilding.HasValue)
            {
                var calculator = AutofacServiceLocator.Container.Resolve<INeededTurnsCalculator>();

                var nextBuilding = GetNextBuilding(LastRevision(provinceHistory.Revisions), lastBuilding.Value);

                int neededTurns = calculator.Calculate(LastRevision(provinceHistory.Revisions), nextBuilding);

                int? turnsFromLastBuilt = GetTurnsFromLastBuilt(provinceHistory.Revisions);

                prediction = new BuildPrediction
                    {
                        Building = nextBuilding,
                        TurnsLeft = neededTurns - turnsFromLastBuilt.Value
                    };
            }
            else
            {
                prediction = BuildPrediction.Unknown;
            }

            return new[]
                {
                    prediction,
                };
        }

        internal Buildings GetNextBuilding(ProvinceRevision lastRevision, Buildings lastBuilt)
        {
            if (lastBuilt == Buildings.Soldiers)
            {
                if (lastRevision.FarmsCount == 1
                        && lastRevision.SoldiersCount == 2)
                {
                    return Buildings.Soldiers;
                }

                if (lastRevision.SoldiersCount < lastRevision.FarmsCount * 2)
                {
                    return Buildings.Soldiers;
                }

                return Buildings.Farm;
            }

            return lastBuilt;
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