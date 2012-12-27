using System;
using System.Globalization;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ProvinceSpy
{
    public static class JsonNetSerializer
    {
        private static readonly JsonSerializer Serializer = new JsonSerializer();

        public static string SerializeToString(object item)
        {
            var result = new StringBuilder();
            using (var writer = new StringWriter(result, CultureInfo.InvariantCulture))
            {
                Serializer.Serialize(writer, item);
            }

            return result.ToString();
        }

        public static T DeserializeFromString<T>(string json)
        {
            return (T)DeserializeFromString(json, typeof(T));
        }

        public static object DeserializeFromString(string json, Type structureType)
        {
            using (var reader = new StringReader(json))
            {
                return Serializer.Deserialize(reader, structureType);
            }
        }
    }
}