using System;
using System.Collections.Generic;

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

            var output = Calc.Evaluate(Calc.Replace(input, consts)).ToString();
            Console.WriteLine(output);
        }
    }
}