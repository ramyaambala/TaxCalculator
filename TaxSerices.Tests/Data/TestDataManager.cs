using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TaxSerices.Tests.Data
{
    public class TestDataManager
    {
        public static string GetJSON(string fixturePath)
        {
            using (StreamReader file = File.OpenText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "../../../","Data", fixturePath)))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject response = (JObject)JToken.ReadFrom(reader);
                var resString = response.ToString(Formatting.None).Replace(@"\", "");
                return response.ToString(Formatting.None).Replace(@"\", "");
            }
        }
    }
}