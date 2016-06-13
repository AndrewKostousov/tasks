using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Core.Json;

using Newtonsoft.Json.Linq;

namespace Core
{
    public static class SimQL
    {
        public static IEnumerable<string> ExecuteQueries(string json)
        {
            var jObject = JObject.Parse(json);
            var data = jObject["data"];

            if(data == null)
                data = ConvertWarehouse(jObject["warehouse"]);

            var queries = jObject["queries"].ToObject<string[]>();
            return queries.Select(q =>
                {
                    var initialQuery = q;
                    string funcName = string.Empty;
                    if(q.Contains('('))
                    {
                        funcName = q.Substring(0, 3).ToLower();
                        q = q.Substring(4, q.Length - 4 - 1);
                    }
                    var query = q.Split('.');
                    if(query[0] == "data")
                        query = query.Skip(1).ToArray();
                    string res = "error";
                    var values = new List<decimal>();
                    try
                    {
                        decimal result;
                        JTraverse.Eval(query, values, -1, data);
                        switch(funcName)
                        {
                        case "min":
                            result = values.Min();
                            break;
                        case "max":
                            result = values.Max();
                            break;
                        default:
                            result = values.Sum();
                            break;
                        }
                        res = Math.Round(result, 5).ToString(CultureInfo.InvariantCulture);
                    }
                    catch(Exception e)
                    {
                        Console.Error.WriteLine(e);
                    }
                    return string.Format("{0} = {1}", initialQuery, res);
                });
        }

        private static JToken ConvertWarehouse(JToken jToken)
        {
            return JObject.Parse(WarehouseConverter.ConvertV2ToV3(jToken.ToString()));
        }
    }
}