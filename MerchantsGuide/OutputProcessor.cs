using System;
using System.Collections.Generic;
using MerchantsGuide.Models;
using System.Linq;

namespace MerchantsGuide
{
    public class OutputProcessor
    {

        public IDictionary<string, string> ProccessAnswer(Variables variables)
        {
            CalculateIntergalacticDecimalValues(variables);
            CalculateElementValues(variables);
            return ProcessAnswers(variables).QuestionsAndAnswers;
        }

        public Variables CalculateIntergalacticDecimalValues(Variables variables)
        {
            foreach (var value in variables.IntergalacticRomanValues)
            {
                variables.IntergalacticDecimalValues.Add(value.Key, RomanConverter.GetDecimalValue(value.Value));
            }
            return variables;
        }

        public Variables CalculateElementValues(Variables variables)
        {
            foreach (var missingValue in variables.IntergalacticMissingValues)
            {
                var value = "";
                var items = missingValue.Key.Split(' ');
                foreach (var item in items)
                {
                    if (variables.IntergalacticRomanValues.Keys.Contains(item))
                    {
                        value += variables.IntergalacticRomanValues.FirstOrDefault(m => m.Key.Equals(item.ToString())).Value;
                    }
                    else
                    {
                        var valueDouble = double.Parse(missingValue.Value, System.Globalization.CultureInfo.InvariantCulture);
                        variables.ElementValues.Add(item, valueDouble/RomanConverter.GetDecimalValue(value));
                    }
                }

            }
            return variables;
        }

        public Variables ProcessAnswers(Variables variables)
        {
            var questionAnswersDictionary = variables.QuestionsAndAnswers.ToDictionary(questionsAndAnswer => questionsAndAnswer.Key, questionsAndAnswer => questionsAndAnswer.Value);
            
            foreach (var questionAnswer in questionAnswersDictionary)
            {
                var value = "";
                var itemList = questionAnswer.Key.Split(' ').ToList();
                
                var last = itemList.Last();
                foreach (var item in itemList)
                {
                    if (variables.IntergalacticRomanValues.Keys.Contains(item))
                    {
                        value += variables.IntergalacticRomanValues.FirstOrDefault(m => m.Key.Equals(item.ToString())).Value;
                        if (item.Equals(last))
                        {
                            variables.QuestionsAndAnswers[questionAnswer.Key] = "is " +
                                                                                RomanConverter.GetDecimalValue(value);
                        }
                    }
                    else if (variables.ElementValues.Keys.Contains(item))
                    {
                        variables.QuestionsAndAnswers[questionAnswer.Key] = "is " +
                                                                            (RomanConverter.GetDecimalValue(value)*
                                                                             variables.ElementValues[item] + " Credits");
                    }
                }
            }
            return variables;
        }
    }
}