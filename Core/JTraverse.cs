using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json.Linq;

namespace Core
{
    public static class JTraverse
    {
        public static void Eval(string[] query, List<double> values, int idx, JToken data)
        {
            if(data is JArray)
            {
                foreach(var d in data)
                {
                    try
                    {
                        Eval(query, values, idx, d);
                    }
                    catch(Exception)
                    {
                        
                    }
                }
                return;
            }
            if(idx == query.Length - 1)
            {
                values.Add(data.Value<double>());
                return;
            }
            var name = query[++idx];
            var token = data[name];
            Eval(query, values, idx, token);
        }
    }
}