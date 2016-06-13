using System.Linq;

using Newtonsoft.Json.Linq;

namespace Core
{
    public static class JTraverse
    {
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