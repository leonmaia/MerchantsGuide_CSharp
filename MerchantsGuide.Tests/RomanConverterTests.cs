using MerchantsGuide.Models;
using NUnit.Framework;

namespace MerchantsGuide.Tests
{
    [TestFixture]
    class RomanConverterTests
    {
        [TestCase("M", (int)RomanIntegerValues.M)]
        [TestCase("D", (int)RomanIntegerValues.D)]
        [TestCase("C", (int)RomanIntegerValues.C)]
        [TestCase("L", (int)RomanIntegerValues.L)]
        [TestCase("X", (int)RomanIntegerValues.X)]
        [TestCase("V", (int)RomanIntegerValues.V)]
        [TestCase("I", (int)RomanIntegerValues.I)]
        public void ShouldReturnDecimalValueOfSimpleRomans(string roman, int value)
        {
            var decimalValue = RomanConverter.GetDecimalValue(roman);

            Assert.AreEqual(value, decimalValue);
        }

        [TestCase("XV", 15)]
        [TestCase("XVI", 16)]
        [TestCase("XVII", 17)]
        [TestCase("XVIII", 18)]
        [TestCase("XCVIII", 98)]
        [TestCase("XCVII", 97)]
        [TestCase("LXXXVIII", 88)]
        [TestCase("LXXXIV", 84)]
        public void ShouldReturnDecimalValue(string roman, int value)
        {
            var decimalValue = RomanConverter.GetDecimalValue(roman);

            Assert.AreEqual(value, decimalValue);
        }

        [TestCase(10, RomanIntegerValues.I, 5, 9)]
        [TestCase(15, RomanIntegerValues.X, 5, 25)]
        public void ShouldReturnResultFromSubtractionLogic(double value, RomanIntegerValues roman, double lastNumber, double expectedResult)
        {
            var resultPerformSubtraction = RomanConverter.PerformSubtraction(value, roman, lastNumber);

            Assert.AreEqual(expectedResult, resultPerformSubtraction);

        }
    }
}
