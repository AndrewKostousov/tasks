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

        [Test]
        public void SimQL3()
        {
            var s = "{\"warehouse\":{\"version\":\"2\",\"constants\":{\"p\":375570429.0,\"BDT5b\":1895861230.0,\"pk6rq0teL\":2147483647.0,\"d801p5J6\":1994942430.0,\"GuuguI\":0.0},\"products\":{\"0\":{\"name\":\"RQbl0WfVY\",\"price\":\"(-84.06633771214)*(p)\",\"count\":881891749},\"1\":{\"name\":\"kDaf0Z\",\"price\":\"(12.1639563293028)+(p)\",\"count\":2147483647},\"304322859\":{\"name\":\"KcOi9dvy\",\"price\":\"(pk6rq0teL)/(-37.0159578216336)\",\"count\":1},\"1408114756\":{\"name\":\"v4N\",\"price\":\"(-85.7739047081088)/(37.9361148634628)\",\"count\":1},\"1889271802\":{\"name\":\"wtXpL\",\"price\":\"(13.8310322136763)*(58.0251485845191)\",\"count\":0},\"687275581\":{\"name\":\"bp\",\"price\":\"(-92.3887056263111)-(d801p5J6)\",\"count\":0},\"1732466776\":{\"name\":\"IohrwvzQ\",\"price\":\"(d801p5J6)+(41.3040054688715)\",\"count\":2147483647},\"2147483647\":{\"name\":\"Abap\",\"price\":\"(-59.916888624391)-(-66.5829328664499)\",\"count\":2147483647},\"517841970\":{\"name\":\"KD9S4\",\"price\":\"(58.4912672445603)/(p)\",\"count\":2147483647},\"1362982700\":{\"name\":\"9pH\",\"price\":\"(-54.4264007147524)/(-45.6487527795363)\",\"count\":1}}},\"queries\":[\"min(products.price)\",\"max(products.price)\",\"sum(products.price)\"]}";
            var results = SimQL.ExecuteQueries(s).ToList();
            Console.WriteLine(results);
            Console.WriteLine(string.Join("\r\n", results));
        }

        [Test]
        public void SimQL3_Accuracy5()
        {
            var s = "{\"warehouse\":{\"version\":\"2\",\"constants\":{\"p\":375570429.0,\"BDT5b\":1895861230.0,\"pk6rq0teL\":2147483647.0,\"d801p5J6\":1994942430.0,\"GuuguI\":0.0},\"products\":{\"0\":{\"name\":\"RQbl0WfVY\",\"price\":\"(-84.06633771214)*(p)\",\"count\":881891749},\"1\":{\"name\":\"kDaf0Z\",\"price\":\"(12.1639563293028)+(p)\",\"count\":2147483647},\"304322859\":{\"name\":\"KcOi9dvy\",\"price\":\"(pk6rq0teL)/(-37.0159578216336)\",\"count\":1},\"1408114756\":{\"name\":\"v4N\",\"price\":\"(-85.7739047081088)/(37.9361148634628)\",\"count\":1},\"1889271802\":{\"name\":\"wtXpL\",\"price\":\"(13.8310322136763)*(58.0251485845191)\",\"count\":0},\"687275581\":{\"name\":\"bp\",\"price\":\"(-92.3887056263111)-(d801p5J6)\",\"count\":0},\"1732466776\":{\"name\":\"IohrwvzQ\",\"price\":\"(d801p5J6)+(41.3040054688715)\",\"count\":2147483647},\"2147483647\":{\"name\":\"Abap\",\"price\":\"(-59.916888624391)-(-66.5829328664499)\",\"count\":2147483647},\"517841970\":{\"name\":\"KD9S4\",\"price\":\"(58.4912672445603)/(p)\",\"count\":2147483647},\"1362982700\":{\"name\":\"9pH\",\"price\":\"(-54.4264007147524)/(-45.6487527795363)\",\"count\":1}}},\"queries\":[\"min(products.price)\",\"max(products.price)\",\"sum(products.price)\"]}";
            var results = SimQL.ExecuteQueries(s).ToList();
            Console.WriteLine(results);
            Console.WriteLine(string.Join("\r\n", results));
        }
    }
}