namespace ProvinceSpy
{
    public class BuildPrediction
    {
        public static BuildPrediction Unknown
        {
            get { return new BuildPrediction { Building = Buildings.Unknown, TurnsLeft = 99 }; }
        }

        public Buildings Building { get; set; }
        
        public int TurnsLeft { get; set; }
    }
}