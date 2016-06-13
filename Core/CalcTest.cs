using NUnit.Framework;

namespace Core
{
    [TestFixture]
    public class CalcTest
    {
        [Test]
        public void Smoke()
        {
            Assert.That(Calc.Evaluate("2 + 2"), Is.EqualTo(4m));
        }
    }
}