using System.Collections.Generic;

namespace ProvinceSpy
{
    public class NeighbourProvider
    {
        public IEnumerable<string> GetNeighbours(string province)
        {
            return new[]
                {
                    "England",
                    "Wales",
                };
        }
    }
}