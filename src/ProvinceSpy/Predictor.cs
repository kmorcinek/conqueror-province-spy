using System.Collections.Generic;

namespace ProvinceSpy
{
    public class Predictor
    {
        IEnumerable<BuildPrediction> Predict(List<ProvinceRevision> revisions)
        {
            return new BuildPrediction[0];
        }
    }
}