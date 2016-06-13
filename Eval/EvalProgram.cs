using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Core;

using Newtonsoft.Json;

namespace EvalTask
{
    internal class EvalProgram
    {
        private static void Main(string[] args)
        {
            var isComma = false;
            var input = Console.In.ReadLine();
            var data = Console.In.ReadToEnd();
            var consts = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

            if(input.Contains(","))
                isComma = true;
            input = input.Replace(",", ".").Replace("'", "");
            if (consts != null && consts.Any(pair => pair.Value.Contains(",")))
                isComma = true;
            if(consts != null)
            {
                consts = consts.ToDictionary(pair => pair.Key, pair => pair.Value.Replace(",", ".").Replace("'", ""));

            }
            var expression = Calc.Replace(input, consts);
            string output;
            try
            {
                output = Calc.Evaluate(expression).ToString(CultureInfo.InvariantCulture);
            }
            catch(Exception)
            {
                Console.WriteLine("error");
                return;
            }

            if(output.EndsWith(".0"))
                Console.WriteLine(output.Substring(0, output.Length - 2));
            else
            {
                /*if (isComma)
                    Console.WriteLine(output.Replace(".", ","));
                else*/
                    Console.WriteLine(output);
            }
            Console.ReadLine();
        }
    }
}