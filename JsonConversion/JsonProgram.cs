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
            //var json = "{'version':'2','constants':{'KrW':1.0,'VXX':2091752689.0},'products':{'2147483647':{'name':'bYG','price':'(KrW)/((VXX)+(KrW))','count':1},'1':{'name':'nOGRk1G','price':'(-54.6768867199667)/((-94.4693193745191)*(VXX))','count':921570388},'0':{'name':'YWd1bGWmx','price':'(VXX)+((-68.9409560379297)+(KrW))','count':1},'220138762':{'name':'LM3Jxgw','price':'(50.7671681934815)*((KrW)/(VXX))','count':1},'721734828':{'name':'GYq5','price':'(8.40230719577629)+((KrW)/(77.0179618042977))','count':1330719542},'1502878597':{'name':'z2CNkal9','price':'(KrW)*((KrW)*(VXX))','count':587644778},'709982529':{'name':'tzouK6','price':'(-64.9490050808289)-((-17.1325461553096)+(VXX))','count':1},'1182592088':{'name':'JnHdt','price':'(KrW)+((44.1574272439617)*(-10.270919702142))','count':1182987983}}}";
            var v2 = JsonConvert.DeserializeObject<ResultV2>(json);
            //JObject v2 = JObject.Parse(json);
            //...
            var v3 = new ResultV3
                {
                    version = "3",
                    products = v2.Products == null ? null : v2.Products.Select(pair => Convert(pair, v2.Constants)).ToArray()
                };
            Console.Write(JsonConvert.SerializeObject(v3, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }));
            Console.ReadLine();
        }

        private static ProductV3 Convert(KeyValuePair<string, ProductV2> v2, Dictionary<string, string> constants)
        {
            v2.Value.price = Calc.Replace(v2.Value.price, constants);
            var productV3 = new ProductV3
                {
                    count = v2.Value.count,
                    name = v2.Value.name,
                    price = v2.Value.price == null ? (decimal?)null : Calc.Evaluate(v2.Value.price),
                    id = int.Parse(v2.Key)
                };
            if(v2.Value.size != null && v2.Value.size.Length != 0)
            {
                productV3.dimensions = new Dimensions
                    {
                        w =  v2.Value.size[0],
                        h = v2.Value.size[1],
                        l = v2.Value.size[2],
                    };
            }
            return productV3;
        }
    }
}