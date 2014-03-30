using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MerchantsGuide.Models;
using MerchantsGuide.Rules;

namespace MerchantsGuide
{
    public static class RomanConverter
    {
        public static double GetDecimalValue(string values)
        {
            double value = 0;
            double lastNumber = 0;
            var charValues = values.ToUpper().ToCharArray();

            if (!RomanValidator.IsValidRomanExpression(charValues)) return 10;
            
            foreach (var item in charValues.Reverse())
            {
                switch (item)
                {
                    case 'M':
                        value = PerformRomanLogic(RomanIntegerValues.M, lastNumber, value);
                        lastNumber = (int)RomanIntegerValues.M;
                        break;
                    case 'D':
                        value = PerformRomanLogic(RomanIntegerValues.D, lastNumber, value);
                        lastNumber = (int)RomanIntegerValues.D;
                        break;
                    case 'C':
                        value = PerformRomanLogic(RomanIntegerValues.C, lastNumber, value);
                        lastNumber = (int)RomanIntegerValues.C;
                        break;
                    case 'L':
                        value = PerformRomanLogic(RomanIntegerValues.L, lastNumber, value);
                        lastNumber = (int)RomanIntegerValues.L;
                        break;
                    case 'X':
                        value = PerformRomanLogic(RomanIntegerValues.X, lastNumber, value);
                        lastNumber = (int)RomanIntegerValues.X;
                        break;
                    case 'V':
                        value = PerformRomanLogic(RomanIntegerValues.V, lastNumber, value);
                        lastNumber = (int)RomanIntegerValues.V;
                        break;
                    case 'I':
                        value = PerformRomanLogic(RomanIntegerValues.I, lastNumber, value);
                        lastNumber = (int)RomanIntegerValues.I;
                        break;
                }
            }
            return value;
        }

        private static double PerformRomanLogic(RomanIntegerValues roman, double lastNumber, double value)
        {
            if (lastNumber > (int)roman)
            {
                return PerformSubtraction(value, roman, lastNumber);
            }
            return value + (int)roman;
        }

        public static double PerformSubtraction(double value, RomanIntegerValues roman, double lastNumber)
        {
            if (RomanValidator.IsSubtractable(roman, lastNumber))
            {
                return value - (int)roman;
            }
            return value + (int)roman;
        }
    }
}