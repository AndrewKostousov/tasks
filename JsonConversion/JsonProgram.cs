using System;
using System.Linq;

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
                    products = v2.Products.Select(pair => new Product
                        {
                            count = pair.Value.count,
                            name = pair.Value.name,
                            price = pair.Value.price,
                            id = int.Parse(pair.Key)
                        }).ToArray()
                };
            Console.Write(JsonConvert.SerializeObject(v3));
            //Console.ReadLine();
        }
    }
}