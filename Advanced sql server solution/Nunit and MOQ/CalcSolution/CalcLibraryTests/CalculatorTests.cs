using NUnit.Framework;
using CalcLibrary;

namespace CalcLibraryTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator? calc;

        [SetUp]
        public void Init()
        {
            calc = new Calculator();
        }

        [TearDown]
        public void Cleanup()
        {
            calc = null;
        }

        [TestCase(2, 3, 5)]
        [TestCase(-1, -1, -2)]
        [TestCase(0, 0, 0)]
        public void Add_TwoNumbers_ReturnsExpectedResult(int a, int b, int expected)
        {
            Assert.That(calc!.Add(a, b), Is.EqualTo(expected));
        }
    }
}
