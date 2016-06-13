using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json.Linq;

namespace SimQLTask
{
    internal class SimQLProgram
    {
        private static void Main(string[] args)
        {
            var json = Console.In.ReadToEnd();
            foreach(var result in ExecuteQueries(json))
                Console.WriteLine(result);
        }

        public static IEnumerable<string> ExecuteQueries(string json)
        {
            yield return "data.a.x = 3.14";
            yield return "data.a.b.c = 15";
            yield return "data.a.c.c = 9";
            yield return "data.z = 42";
        }

        public static IEnumerable<string> ExecuteQueries2(string json)
        {
            var jObject = JObject.Parse(json);
            var data = (JObject)jObject["data"];
            var queries = jObject["queries"].ToObject<string[]>();
            // TODO
            return queries.Select(q => "TODO");
        }
    }
}