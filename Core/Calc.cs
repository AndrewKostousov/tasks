using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace Core
{
    public static class Calc
    {
        public static decimal Evaluate(string expression)
        {
            var table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            var row = table.NewRow();
            table.Rows.Add(row);
            return decimal.Parse((string)row["expression"]);
        }

        public static string Replace(string s, Dictionary<string, string> constants)
        {
            if (constants == null || constants.Count == 0)
                return s;
            s = s.Replace("+", " + ").Replace("-", " - ").Replace("*", " * ").Replace("/", " / ").Replace("(", " ( ").Replace(")", " ) ");
            var result = s.Split(new[] { " ", }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var constant in constants)
            {
                for (var i = 0; i < result.Length; ++i)
                {
                    if (result[i] == constant.Key)
                    {
                        result[i] = TryFixDecimal(constant.Value);
                    }
                }
            }

            var set = new HashSet<string> { "+", "-", "*", "/", "(", ")" };
            for (var i = 0; i < result.Length; ++i)
            {
                if (!set.Contains(result[i]) && !result[i].Contains("."))
                {
                    result[i] = result[i] + ".0";
                }
            }

            return String.Join("", result);
        }

        private static string TryFixDecimal(string value)
        {
            decimal res;
            if(decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out res) || decimal.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("ru-RU"), out res))
                return res.ToString(CultureInfo.InvariantCulture);
            return value;
        }
    }
}