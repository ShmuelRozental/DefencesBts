using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace Week_10.Services
{
    public class JsonService
    {
        public interface IJsonLoadable { }

        public static List<T> LoadFromJson<T>(string filePath) where T : IJsonLoadable
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };
            var jsonString = File.ReadAllText(filePath);
            var objects = JsonSerializer.Deserialize<List<T>>(jsonString, options);
            return objects;
        }
    }
}
