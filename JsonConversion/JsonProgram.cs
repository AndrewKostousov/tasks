using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace JsonConversion
{
class JsonProgram
  {
    static void Main()
    {
      string json = Console.In.ReadToEnd();
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

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int count { get; set; }
    }


    public class ResultV3
    {
        public string version { get; set; }
        public Product[] products { get; set; }
    }

    public class ResultV2
    {
        public string Version { get; set; }
        public Dictionary<string, Product> Products { get; set; }
    }
}
