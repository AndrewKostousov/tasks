﻿using System.Linq;

using Newtonsoft.Json.Linq;

namespace Core
{
    public static class JTraverse
    {
        public static decimal Sum(string[] query, int idx, JToken data)
        {
            //if(data is JArray)
                //return data.Sum(item => Sum(query, idx, item));
            var name = query[++idx];
            var token = data[name];
            //if(token == null)
                //return default(decimal);
            if(idx == query.Length - 1)
                return token.Value<decimal>();
            return Sum(query, idx, token);
        }
    }
}