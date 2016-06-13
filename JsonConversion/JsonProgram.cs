using System;
using System.Collections.Generic;
using System.Linq;

using Core;

using Newtonsoft.Json;

namespace JsonConversion
{
    internal class JsonProgram
    {
        private static void Main()
        {
            var json = Console.In.ReadToEnd();
            var v2 = JsonConvert.DeserializeObject<ResultV2>(json);
            //JObject v2 = JObject.Parse(json);
            //...
            var v3 = new ResultV3
                {
                    version = "3",
                    products = v2.Products.Select(pair => Convert(pair, v2.Constants)).ToArray()
                };
            Console.Write(JsonConvert.SerializeObject(v3));
            Console.ReadLine();
        }

        private static ProductV3 Convert(KeyValuePair<string, ProductV2> v2, Dictionary<string, string> constants)
        {
            v2.Value.price = Replace(v2.Value.price, constants);
            return new ProductV3
                {
                    count = v2.Value.count,
                    name = v2.Value.name,
                    price = Calc.Evaluate(v2.Value.price),
                    id = int.Parse(v2.Key)
                };
        }

        private static string Replace(string s, Dictionary<string, string> constants)
        {
            s = s.Replace("+", " + ").Replace("-", " - ").Replace("*", " * ").Replace("/", " / ").Replace("(", " ( ").Replace(")", " ) ");
            var result = s.Split(new [] {" ", }, StringSplitOptions.None);
            
            foreach(var constant in constants)
            {
                for(var i = 0; i < result.Length; ++i)
                {
                    if(result[i] == constant.Key)
                    {
                        result[i] = constant.Value;
                    }
                }
            }
            return String.Join("", result);
        }
    }
}