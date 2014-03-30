using System.Collections.Generic;
using System.Text.RegularExpressions;
using MerchantsGuide.Models;

namespace MerchantsGuide
{
    public class InputProcessor
    {
        private const string TitleValuePattern = @"(?<title>(.*?) is)(?<value>(.*)|Credits)";
        private const string QuestionPattern = @"(?<title>(how much is)|(how many Credits is))(?<rest>(.* -?))";
        private readonly Variables _variables;
        private readonly Regex _questionMarkRegex;
        private readonly Regex _assignmentRegex;
        private readonly Regex _questionRegex;

        public InputProcessor()
        {
            _variables = new Variables();
            _questionMarkRegex = new Regex(@"\?");
            _assignmentRegex = new Regex(TitleValuePattern);
            _questionRegex = new Regex(QuestionPattern);

        }
        public Variables ProcessData(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var questionMarkMatch = _questionMarkRegex.Match(line);
                var assignmentMatch = _assignmentRegex.Match(line);
                var questionMatch = _questionRegex.Match(line);
                if (questionMarkMatch.Success && questionMatch.Success)
                {
                    _variables.QuestionsAndAnswers.Add(questionMatch.Groups[3].ToString().TrimStart().TrimEnd(), "");
                }
                else if (assignmentMatch.Success)
                {
                    if (line.EndsWith("Credits"))
                    {
                        _variables.IntergalacticMissingValues.Add(assignmentMatch.Groups[1].ToString().TrimStart().TrimEnd(), assignmentMatch.Groups[2].ToString().Replace("Credits", "").TrimStart().TrimEnd());
                    }
                    else
                    {
                        _variables.IntergalacticRomanValues.Add(assignmentMatch.Groups[1].ToString(), assignmentMatch.Groups[2].ToString().TrimStart().TrimEnd());
                    }
                }
                else
                {
                    _variables.QuestionsAndAnswers.Add("I have no idea what you are talking about", "");
                }
            }
            return _variables;
        }
    }
}