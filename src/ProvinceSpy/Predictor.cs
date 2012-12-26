using System.Collections.Generic;

namespace ProvinceSpy
{
    public class Predictor
    {
        public IEnumerable<BuildPrediction> Predict(ProvinceHistory provinceHistory)
        {
            return new BuildPrediction[0];
        }
    }
}