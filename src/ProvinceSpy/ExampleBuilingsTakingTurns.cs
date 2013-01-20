using System.Collections.Generic;
using System.IO;

namespace ProvinceSpy
{
    public class ExampleBuilingsTakingTurns
    {
        private List<BuildingStruct> list = new List<BuildingStruct>();

        public void AddThem()
        {
            // TODO Farm must be divided for base and resources
            list.Add(new BuildingStruct(3, CultureLevel.Primitive, Buildings.Culture, 10));
            list.Add(new BuildingStruct(2, CultureLevel.Primitive, Buildings.Culture, 16));
            list.Add(new BuildingStruct(2, CultureLevel.Primitive, Buildings.Soldiers, 2));
            list.Add(new BuildingStruct(4, CultureLevel.Primitive, Buildings.Fortification, 4));
            list.Add(new BuildingStruct(3, CultureLevel.Primitive, Buildings.Fortification, 5)); //2+1
            list.Add(new BuildingStruct(2, CultureLevel.Primitive, Buildings.Fortification, 8));
            list.Add(new BuildingStruct(2, CultureLevel.Primitive, Buildings.Farm, 2));
            list.Add(new BuildingStruct(2, CultureLevel.Primitive, Buildings.Farm, 2)); //1+1
            list.Add(new BuildingStruct(3, CultureLevel.Primitive, Buildings.Farm, 3)); //2+1
            list.Add(new BuildingStruct(4, CultureLevel.Primitive, Buildings.Farm, 4)); //3+1
            list.Add(new BuildingStruct(5, CultureLevel.Primitive, Buildings.Farm, 4)); //4+1
            list.Add(new BuildingStruct(6, CultureLevel.Primitive, Buildings.Farm, 5)); //5+1


        }

        public void SaveToFile()
        {
            var serializeToString = JsonNetSerializer.SerializeToString(list);

            File.WriteAllText(Common.BuildingTakingTurnsPath, serializeToString);
        }
    }
}