using System;

using Core;

namespace EvalTask
{
    internal class EvalProgram
    {
        private static void Main(string[] args)
        {
            var input = Console.In.ReadToEnd();
            var output = Calc.Evaluate(input).ToString();
            Console.WriteLine(output);
        }
    }
}