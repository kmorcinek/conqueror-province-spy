using System.Collections.Generic;
using System.IO;

namespace ProvinceSpy
{
    public class ExampleBuilingsTakingTurns
    {
        private List<BuildingStruct> list = new List<BuildingStruct>();

        public void AddThem()
        {
            list.Add(new BuildingStruct(3, CultureLevel.Primitive, Buildings.Culture, 10));
        }

        public void SaveToFile()
        {
            string serializeToString = JsonNetSerializer.SerializeToString(list);

            var l = JsonNetSerializer.DeserializeFromString<List<BuildingStruct>>(serializeToString);
            
            File.WriteAllText("konio.txt", serializeToString);
        }
    }
}