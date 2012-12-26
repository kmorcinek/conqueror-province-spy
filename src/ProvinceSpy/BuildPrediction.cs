using System;
using System.Windows.Media;
using ProvinceSpy.ViewModels;

namespace ProvinceSpy
{
    public class BuildPrediction : ViewModelBase
    {
        public static BuildPrediction Unknown
        {
            get { return new BuildPrediction { Building = Buildings.Unknown, TurnsLeft = 99 }; }
        }

        private int turnsLeft;
        private Buildings building;

        public Buildings Building
        {
            get { return this.building; }
            set { SetField(ref this.building, value, () => Building); }
        }
        public int TurnsLeft
        {
            get { return this.turnsLeft; }
            set { SetField(ref this.turnsLeft, value, () => TurnsLeft); }
        }
        public Brush Color
        {
            get
            {
                switch (Building)
                {
                    case Buildings.Soldiers:
                        return Brushes.Red;
                    case Buildings.Diplomats:
                        return Brushes.Peru;
                    case Buildings.Fortification:
                        return Brushes.Black;
                    case Buildings.Farm:
                        return Brushes.Green;
                    case Buildings.Gold:
                        return Brushes.Yellow;
                    case Buildings.Culture:
                        return Brushes.Azure;
                    case Buildings.Unknown:
                        return Brushes.White;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}