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
    }
}