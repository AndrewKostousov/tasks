using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

namespace Core.Json
{
    public static class WarehouseConverter
    {
        public static string FixV3(string json)
        {
            var fix = Regex.Replace(json, @"""\d+(?:'\d+)*,\d+""", v => v.Value.Replace("\"", "").Replace("'", "").Replace(",", "."));
            var v3 = JsonConvert.DeserializeObject<ResultV3>(fix);
            if(v3.version != "3")
                throw new Exception();
            v3.products = v3.products == null ? null : v3.products.Select(product => FixV3(product, new Dictionary<string, string>())).ToArray();
            var serializeObject = JsonConvert.SerializeObject(v3, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            return serializeObject;
        }

        public static string ConvertV2ToV3(string json)
        {
            var v2 = JsonConvert.DeserializeObject<ResultV2>(json);
            var v3 = new ResultV3
                {
                    version = "3",
                    products = v2.Products == null ? null : v2.Products.Select(pair => Convert(pair, v2.Constants)).ToArray()
                };
            var serializeObject = JsonConvert.SerializeObject(v3, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            return serializeObject;
        }

        private static ProductV3 Convert(KeyValuePair<string, ProductV2> v2, Dictionary<string, string> constants)
        {
            if (v2.Value == null)
                return null;
            v2.Value.price = Calc.Replace(v2.Value.price, constants);
            var productV3 = new ProductV3
                {
                    count = v2.Value.count,
                    name = v2.Value.name,
                    price = v2.Value.price == null ? (decimal?)null : Calc.Evaluate(v2.Value.price),
                    id = int.Parse(v2.Key)
                };
            if (v2.Value.size != null && v2.Value.size.Length != 0)
            {
                productV3.dimensions = new Dimensions
                    {
                        w = v2.Value.size[0],
                        h = v2.Value.size[1],
                        l = v2.Value.size[2],
                    };
            }
            return productV3;
        }

        private static ProductV3 FixV3(ProductV3 v3, Dictionary<string, string> constants)
        {
            if(v3 == null)
                return null;
            if(v3.price == null)
                return v3;
            var price = v3.price?.ToString(CultureInfo.InvariantCulture);
            price = decimal.Parse(Calc.Replace(price, constants), CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
            v3.price = Calc.Evaluate(price);
            return v3;
        }
    }
}