using System;
using System.Windows.Media;

namespace ProvinceSpy
{
    public class BuildPrediction
    {
        public Buildings Building { get; set; }
        public int TurnsLeft { get; set; }
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
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}