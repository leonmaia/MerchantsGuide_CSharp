using MerchantsGuide.Models;
using MerchantsGuide.Rules;
using NUnit.Framework;

namespace MerchantsGuide.Tests
{
    [TestFixture]
    internal class RomanValidationTests
    {
        [TestCase(RomanIntegerValues.I, 5)]
        [TestCase(RomanIntegerValues.I, 10)]
        [TestCase(RomanIntegerValues.X, 50)]
        [TestCase(RomanIntegerValues.X, 100)]
        [TestCase(RomanIntegerValues.C, 100)]
        [TestCase(RomanIntegerValues.C, 1000)]
        public void ShouldReturnTrueIfNumberIsSubtractableFromRoman(RomanIntegerValues roman, double value)
        {
            var resultFromIsSubtractable = RomanValidator.IsSubtractable(roman, value);

            Assert.True(resultFromIsSubtractable);
        }

        [TestCase(RomanIntegerValues.I, 4)]
        [TestCase(RomanIntegerValues.X, 40)]
        [TestCase(RomanIntegerValues.C, 110)]
        public void ShouldReturnFalseIfNumberIsNotSubtractableFromRoman(RomanIntegerValues roman, double value)
        {
            var resultFromIsSubtractable = RomanValidator.IsSubtractable(roman, value);

            Assert.False(resultFromIsSubtractable);
        }

        [Test]
        public void ShouldReturnTrueIfIsValidSetOfCharacters()
        {
            var charValues = "IVXCDML".ToUpper().ToCharArray();
            var resultFromIsValidSetOfCharacters = RomanValidator.IsValidSetOfCharacters(charValues);

            Assert.True(resultFromIsValidSetOfCharacters);
        }

        [Test]
        public void ShouldReturnFalseIfIsNotValidSetOfCharacters()
        {
            var charValues = "IVXCDMLZ".ToUpper().ToCharArray();
            var resultFromIsValidSetOfCharacters = RomanValidator.IsValidSetOfCharacters(charValues);

            Assert.False(resultFromIsValidSetOfCharacters);
        }

        [TestCase("IIIVI")]
        [TestCase("DDIVI")]
        public void ShouldReturnFalseIfIsValidRomanExpression(string values)
        {
            var charValues = values.ToUpper().ToCharArray();
            var resultFromIsValidSetOfCharacters = RomanValidator.ValidLiteralCount(charValues);

            Assert.False(resultFromIsValidSetOfCharacters);
        }

        [TestCase("XXXIX")]
        [TestCase("XXXVX")]
        public void ShouldReturnTrueIfIsValidLiteralCount(string values)
        {
            var charValues = values.ToUpper().ToCharArray();
            var resultFromIsValidSetOfCharacters = RomanValidator.ValidLiteralCount(charValues);

            Assert.True(resultFromIsValidSetOfCharacters);
        }

        [Test]
        public void ShouldReturnTrueIfCurrentLiteralSmallerThanPrevious()
        {
            var charValues = "XXXIX".ToUpper().ToCharArray();
            var resultFromIsValidSetOfCharacters = RomanValidator.CurrentLiteralSmallerThanPrevious(charValues[3], charValues[0]);

            Assert.True(resultFromIsValidSetOfCharacters);
        }
    }
}
