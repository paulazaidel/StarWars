using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Infra.Swapi.Helpers
{
    public static class JsonHelper
    {
        public static void SaveJsonFile<T>(IEnumerable<T> data, string fileName)
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.FullName;

            if (path == null)
                throw new ArgumentNullException(nameof(path));

            string filePath = Path.Combine(path, fileName);

            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
            }
        }
    }
}
