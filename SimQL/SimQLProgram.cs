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
            var jObject = JObject.Parse(json);
            var data = jObject["data"];
            var queries = jObject["queries"].ToObject<string[]>();
            return queries.Select(q =>
                {
                    var query = q.Substring(4, q.Length - 4 - 1).Split('.');
                    return String.Format("{0}", Sum(query, -1, data));
                });
        }

        public static decimal Sum(string[] query, int idx, JToken data)
        {
            if(data is JArray)
                return data.Children().Sum(item => Sum(query, idx, item));
            var name = query[++idx];
            if(idx == query.Length - 1)
            {
                var prop = data[name];
                return prop == null || prop.Type != JTokenType.Integer && prop.Type != JTokenType.Float ? 0 : data[name].Value<decimal>();
            }
            data = data[name];
            return Sum(query, idx, data);
        }
    }
}