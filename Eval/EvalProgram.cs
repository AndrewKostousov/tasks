using System;
using System.Data;

namespace EvalTask
{
    internal class EvalProgram
    {
        private static void Main(string[] args)
        {
            var input = Console.In.ReadToEnd();
            var output = Evaluate(input).ToString();
            Console.WriteLine(output);
        }

        public static double Evaluate(string expression)
        {
            var table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            var row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }
    }
}