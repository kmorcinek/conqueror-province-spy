using System.Collections.Generic;

namespace ProvinceSpy
{
    public class Predictor
    {
        public IEnumerable<BuildPrediction> Predict(ProvinceHistory provinceHistory)
        {
            return new []
                {
                    new BuildPrediction{TurnsLeft = 4, Building = Buildings.Farm}, 
                };
        }
    }
}