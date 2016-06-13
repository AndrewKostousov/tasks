using System.Linq;

using Newtonsoft.Json.Linq;

namespace Core
{
    public static class JTraverse
    {
        public static decimal Eval(string[] query, string funcName, int idx, JToken data)
        {
            var name = query[++idx];
            var token = data[name];
            if(idx == query.Length - 1)
            {
                {
                    switch (funcName)
                    {
                        case "min":
                            return token.Values<decimal>().Min();
                        case "max":
                            return token.Values<decimal>().Max();
                        case "sum":
                            return token.Values<decimal>().Sum();
                        default:
                            return token.Value<decimal>();
                    }
                }
            }
            return Eval(query, funcName, idx, token);
        }
    }
}