using System;
using System.Collections.Generic;
using System.Globalization;

using Core;

using Newtonsoft.Json;

namespace EvalTask
{
    internal class EvalProgram
    {
        private static void Main(string[] args)
        {
            var input = Console.In.ReadLine();
            var data = Console.In.ReadToEnd();
            var consts = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

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
            
            if (output.EndsWith(".0"))
                Console.WriteLine(output.Substring(0, output.Length - 2));
            else
                Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}