using NUnit.Framework;
using Assignment11;
using System.Collections.Generic;

namespace Assignment11.Tests
{
    public class NumericFunctionsTests
    {
        private NumericFunctions nf;

        [SetUp]
        public void Setup()
        {
            nf = new NumericFunctions();
        }

        [Test] public void AddTest() => Assert.That(nf.Add(5, 4, 6), Is.EqualTo(15));

        [Test] public void SubtractTest() => Assert.That(nf.Subtract(10, 7), Is.EqualTo(3));

        [Test] public void MultiplyTest() => Assert.That(nf.Multiply(5, 4, 3), Is.EqualTo(60));

        [Test] public void DivideTest() => Assert.That(nf.Divide(5f, 2f), Is.EqualTo(2.5f));

        [Test] public void MaxTest() => Assert.That(nf.Max(3, 9, 1), Is.EqualTo(9));

        [Test] public void MinTest() => Assert.That(nf.Min(3, 9, 1), Is.EqualTo(1));

        [Test] public void IsEvenTest() => Assert.That(nf.IsEven(8), Is.True);

        [Test] public void IsOddTest() => Assert.That(nf.IsOdd(7), Is.True);

        [Test] public void IsPrimeTest() => Assert.That(nf.IsPrime(11), Is.True);

        [Test]
        public void EvenInRangeTest()
        {
            var expected = new List<int> { 2, 4, 6 };
            Assert.That(nf.EvenInRange(1, 6), Is.EqualTo(expected));
        }

        [Test]
        public void OddInRangeTest()
        {
            var expected = new List<int> { 1, 3, 5 };
            Assert.That(nf.OddInRange(1, 6), Is.EqualTo(expected));
        }

        [Test]
        public void PrimesInRangeTest()
        {
            var expected = new List<int> { 2, 3, 5, 7 };
            Assert.That(nf.PrimesInRange(1, 10), Is.EqualTo(expected));
        }

        [Test]
        public void DisplayTableTest()
        {
            var expected = new List<string>
            {
                "5 x 1 = 5",
                "5 x 2 = 10",
                "5 x 3 = 15",
                "5 x 4 = 20",
                "5 x 5 = 25",
                "5 x 6 = 30",
                "5 x 7 = 35",
                "5 x 8 = 40",
                "5 x 9 = 45",
                "5 x 10 = 50"
            };
            Assert.That(nf.DisplayTable(5), Is.EqualTo(expected));
        }

        [Test]
        public void ReverseNumberTest()
        {
            Assert.That(nf.Reverse(1234), Is.EqualTo(4321));
        }
    }
}
