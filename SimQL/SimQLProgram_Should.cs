using System;
using System.Linq;

using Core;

using NUnit.Framework;

namespace SimQLTask
{
    [TestFixture]
    public class SimQLProgram_Should
    {
        [Test]
        public void SumEmptyDataToZero()
        {
            var results = SimQL.ExecuteQueries(
                "{" +
                "'data': [], " +
                "'queries': ['item.cost', 'itemsCount']}");
            Assert.AreEqual(new[] {"item.cost = error", "itemsCount = error"}, results);
        }

        [Test]
        public void SumSingleItem()
        {
            var results = SimQL.ExecuteQueries(
                "{" +
                "'data': [{'itemsCount':[42]}, {'foo':'bar'}], " +
                "'queries': ['sum(itemsCount)']}");
            Assert.AreEqual(new[] {"sum(itemsCount) = 42"}, results);
        }

        [Test]
        public void Test()
        {
            var s = "{\"data\":{\"a\":{\"x\":3.14,\"b\":{\"c\":15},\"c\":{\"c\":9}},\"z\":42,\"q\":{}},\"queries\":[\"data.xyzy\",\"data.q\",\"data.a.x\",\"data.a.b.c\",\"data.a.c.c\",\"data.z\"]}";
            var results = SimQL.ExecuteQueries(s).ToList();
            Console.WriteLine(results);
            //Assert.AreEqual(new[] { "itemsCount = 42" }, results);
            Console.WriteLine(string.Join("\r\n", results));
        }

        [Test]
        public void TestFunc()
        {
            var s = "{\"data\":{\"empty\":[],\"x\":[0.1,0.2,0.3],\"a\":[{\"b\":10,\"c\":[1,2,3]},{\"b\":30,\"c\":[4]},{\"d\":500}]},\"queries\":[\"sum(empty)\",\"sum(a.b)\",\"sum(a.c)\",\"sum(a.d)\",\"sum(x)\"]}";
            var results = SimQL.ExecuteQueries(s).ToList();
            Console.WriteLine(results);
            Console.WriteLine(string.Join("\r\n", results));
        }
        [Test]
        public void Debug()
        {
            var s = "{\"data\":{\"a\":{\"x\":3.14,\"b\":{\"c\":15},\"c\":{\"c\":9}},\"z\":42},\"queries\":[\"a.x\",\"a.b.c\",\"a.c.c\",\"z\"]}";
            var results = SimQL.ExecuteQueries(s).ToList();
            Console.WriteLine(results);
            Console.WriteLine(string.Join("\r\n", results));
        }
    }
}