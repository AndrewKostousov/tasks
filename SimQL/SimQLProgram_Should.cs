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
                "'queries': ['sum(item.cost)', 'sum(itemsCount)']}");
            Assert.AreEqual(new[] {"item.cost = 0", "itemsCount = 0"}, results);
        }

        [Test]
        public void SumSingleItem()
        {
            var results = SimQL.ExecuteQueries(
                "{" +
                "'data': [{'itemsCount':42}, {'foo':'bar'}], " +
                "'queries': ['sum(itemsCount)']}");
            Assert.AreEqual(new[] {"itemsCount = 42"}, results);
        }

        [Test]
        public void Test()
        {
            var s = "{\"data\":{\"a\":{\"x\":3.14,\"b\":{\"c\":15},\"c\":{\"c\":9}},\"z\":42,\"q\":{}},\"queries\":[\"data.q\",\"data.a.x\",\"data.a.b.c\",\"data.a.c.c\",\"data.z\"]}";
            var results = SimQL.ExecuteQueries(s).ToList();
            Console.WriteLine(results);
            //Assert.AreEqual(new[] { "itemsCount = 42" }, results);
        }
    }
}