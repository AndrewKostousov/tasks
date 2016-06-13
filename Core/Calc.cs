using System;
using System.Collections.Generic;

using System.Data;
using System.Globalization;

using NCalc;

namespace Core
{
    public static class Calc
    {
        public static decimal Evaluate(string expression)
        {
            expression = expression.Replace(";", ",").ToLower();
            if(expression.Contains("min") || expression.Contains("max") || expression.Contains("sqrt"))
            {
                Expression e = new Expression(expression);
                e.EvaluateFunction += delegate(string name, FunctionArgs args)
                    {
                        if(name == "sqrt")
                            args.Result = Math.Sqrt(ToDouble(args.Parameters[0].Evaluate()));
                        if(name == "min")
                            args.Result = Math.Min(ToDouble(args.Parameters[0].Evaluate()), ToDouble(args.Parameters[1].Evaluate()));
                        if(name == "max")
                            args.Result = Math.Max(ToDouble(args.Parameters[0].Evaluate()), ToDouble(args.Parameters[1].Evaluate()));
                    };

                var o = e.Evaluate();
                return (decimal)ToDouble(o);
            }
            else
            {
                expression = expression.ToLower();
            var table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            var row = table.NewRow();
            table.Rows.Add(row);
            return decimal.Parse((string)row["expression"]);
            }
        }

        private static double ToDouble(object o)
        {
            try
            {
                return (double)o;
            }
            catch (Exception ee)
            {
            }
            try
            {
                return (int)o;
            }
            catch(Exception ee)
            {
            }
            
            return (double)(decimal)o;
        }

        public static string Replace(string s, Dictionary<string, string> constants)
        {
            if (constants == null || constants.Count == 0)
                return s;
            s = s.Replace("+", " + ").Replace("-", " - ").Replace("*", " * ").Replace("/", " / ").Replace("(", "( ").Replace(")", " )").Replace(',', '.');
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

            return String.Join("", result);}

        private static string TryFixDecimal(string value)
        {
            decimal res;
            if(decimal.TryParse(value.Replace(',', '.').Replace("'", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out res))
                return res.ToString(CultureInfo.InvariantCulture);
            return value;
        }
    }
}