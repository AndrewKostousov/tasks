﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Newtonsoft.Json.Linq;

namespace Core
{
    public static class SimQL
    {
        public static IEnumerable<string> ExecuteQueries(string json)
        {
            var jObject = JObject.Parse(json);
            var data = jObject["data"];
            var queries = jObject["queries"].ToObject<string[]>();
            return queries.Select(q =>
                {
                    var fix = q.StartsWith("sum(") ? q.Substring(4, q.Length - 4 - 1) : q;
                    var query = fix.Split('.');
                    return string.Format("{0} = {1}", fix, JTraverse.Sum(query, -1, data).ToString(CultureInfo.InvariantCulture));
                });
        }
    }
}