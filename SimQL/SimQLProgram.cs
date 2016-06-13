using System;

using Core;

namespace SimQLTask
{
    internal class SimQLProgram
    {
        private static void Main(string[] args)
        {
            var json = Console.In.ReadToEnd();
            foreach(var result in SimQL.ExecuteQueries(json))
                Console.WriteLine(result);
        }
    }
}