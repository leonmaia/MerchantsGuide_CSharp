using System.Collections.Generic;
using System.Linq;
using MerchantsGuide.Models;

namespace MerchantsGuide.Rules
{
    public static class RomanValidator
    {
        public static char[] NonRepeatingRomanNumerals = { 'D', 'L', 'V' };
        public static char[] RepeatingRomanNumerals = { 'I', 'V', 'X', 'M' };
        public static Dictionary<char, int> NonRepeatableLiteralsCount = new Dictionary<char, int> { { 'V', 0 }, { 'L', 0 }, { 'D', 0 } };
        public static Dictionary<char, int> RepeatableLiteralsCount = new Dictionary<char, int> { { 'I', 0 }, { 'X', 0 }, { 'C', 0 }, { 'M', 0 } };
        public static IList<int> SubtractablesOfI = new List<int> { 5, 10 };
        public static IList<int> SubtractablesOfX = new List<int> { 50, 100 };
        public static IList<int> SubtractablesOfC = new List<int> { 100, 1000 };

        public static bool IsSubtractable(RomanIntegerValues roman, double lastNumber)
        {
            switch (roman)
            {
                case RomanIntegerValues.I:
                    if (SubtractablesOfI.Contains((int)lastNumber))
                        return true;
                    break;
                case RomanIntegerValues.X:
                    if (SubtractablesOfX.Contains((int)lastNumber))
                        return true;
                    break;
                case RomanIntegerValues.C:
                    if (SubtractablesOfC.Contains((int)lastNumber))
                        return true;
                    break;
            }
            return false;
        }

        public static bool IsValidRomanExpression(IEnumerable<char> values)
        {
            ResetLiteralCounts();
            return ValidLiteralCount(values);
        }

        public static bool ValidLiteralCount(IEnumerable<char> values)
        {
            var enumerable = values as char[] ?? values.ToArray();
            PopulateLiteralCounters(enumerable);

            if (NonRepeatableLiteralsCount.Values.Any(m => m > 1))
            {
                return false;
            }
            
            if (RepeatableLiteralsCount.Values.Any(m => m > 3))
            {
                foreach (var i in RepeatableLiteralsCount)
                {
                    if (i.Value > 3)
                    {
                        var list = enumerable.ToList();
                        var indexOfFirsRepeatedLiteral = list.IndexOf(i.Key);
                        if (list.Count() > indexOfFirsRepeatedLiteral + 3)
                        {
                            return CurrentLiteralSmallerThanPrevious(list.ElementAt(indexOfFirsRepeatedLiteral + 3), i.Key);
                        }
                    }
                }
            }
            return true;
        }

        private static void PopulateLiteralCounters(IEnumerable<char> enumerable)
        {
            foreach (var item in enumerable)
            {
                if (NonRepeatableLiteralsCount.Keys.Contains(item))
                {
                    NonRepeatableLiteralsCount[item] += 1;
                }

                else if (RepeatableLiteralsCount.Keys.Contains(item))
                {
                    RepeatableLiteralsCount[item] += 1;
                }
            }
        }

        public static bool IsValidSetOfCharacters(IEnumerable<char> values)
        {
            var validChars = new[] { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

            return values.All(validChars.Contains);
        }

        public static bool CurrentLiteralSmallerThanPrevious(char currentLiteral, char repeatedValue)
        {
            return !(RomanConverter.GetDecimalValue(currentLiteral.ToString()) > RomanConverter.GetDecimalValue(repeatedValue.ToString()));
        }

        private static void ResetLiteralCounts()
        {
            NonRepeatableLiteralsCount = new Dictionary<char, int> { { 'V', 0 }, { 'L', 0 }, { 'D', 0 } };
            RepeatableLiteralsCount = new Dictionary<char, int> { { 'I', 0 }, { 'X', 0 }, { 'C', 0 }, { 'M', 0 } };
        }           
    }
}
