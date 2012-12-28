using System.Collections.Generic;
using System.IO;

namespace ProvinceSpy
{
    public class NeighbourProvider
    {
        private const string NeighboursFileName = "neighbours.txt";
        private static readonly Dictionary<string, string[]> neighbours = GetNeighboursFromFile();

        private static Dictionary<string, string[]> GetNeighboursFromFile()
        {
            try
            {
                var content = File.ReadAllText(NeighboursFileName);
                return JsonNetSerializer.DeserializeFromString<Dictionary<string, string[]>>(content);
            }
            catch (FileNotFoundException)
            {
                // TODO log error show error,
                return new Dictionary<string, string[]>();
            }
        }

        public IEnumerable<string> GetCapitals()
        {
            return neighbours.Keys;
        }

        public IEnumerable<string> GetNeighbours(string province)
        {
            string[] neighboursCollection;

            if(!neighbours.TryGetValue(province, out neighboursCollection))
                neighboursCollection = new string[0];

            return neighboursCollection;
        }
    }
}