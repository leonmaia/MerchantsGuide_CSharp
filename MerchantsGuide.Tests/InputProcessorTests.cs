using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantsGuide.Models;
using NUnit.Framework;

namespace MerchantsGuide.Tests
{
    [TestFixture]
    class InputProcessorTests
    {
        [Test]
        public void ShouldReturnMessageOnQuestionsAndAnswersArrayWhenProvidedInvalidData()
        {
            var inputProcessor = new InputProcessor();
            var data = new List<string> { "how much wood could a woodchuck chuck if a woodchuck could chuck wood ?" };

            var processData = inputProcessor.ProcessData(data);

            Assert.AreEqual("I have no idea what you are talking about", processData.QuestionsAndAnswers.First().Key);
            Assert.AreEqual("", processData.QuestionsAndAnswers.First().Value);
        }

        [TestCase("how many Credits is glob prok Silver ?", "glob prok Silver")]
        [TestCase("how many Credits is glob prok Gold ?", "glob prok Gold")]
        [TestCase("how many Credits is glob prok Iron ?", "glob prok Iron")]
        public void ShouldReturnQuestionsAndAnswersArrayWithItensOfTheQuestion(string value, string answer)
        {
            var inputProcessor = new InputProcessor();
            var data = new List<string> { value };

            var processData = inputProcessor.ProcessData(data);

            Assert.AreEqual(answer, processData.QuestionsAndAnswers.First().Key.Trim());
        }

        [TestCase("glob glob Silver is 34 Credits", "glob glob Silver", "34")]
        [TestCase("glob prok Gold is 57800 Credits", "glob prok Gold", "57800")]
        [TestCase("pish pish Iron is 3910 Credits", "pish pish Iron", "3910")]
        public void ShouldReturnItensAndTheirCreditsValuesOnIntergalacticMissingValuesArray(string value, string keyAnswer, string valueAnswer)
        {
            var inputProcessor = new InputProcessor();
            var data = new List<string> { value };

            var processData = inputProcessor.ProcessData(data);

            Assert.AreEqual(keyAnswer, processData.IntergalacticMissingValues.First().Key.Trim());
            Assert.AreEqual(valueAnswer, processData.IntergalacticMissingValues.First().Value.Trim());
        }

        [TestCase("glob is I", "glob", "I")]
        [TestCase("prok is V", "prok", "V")]
        [TestCase("pish is X", "pish", "X")]
        [TestCase("tegj is L", "tegj", "L")]
        public void ShouldReturnItensAndTheirRomanValuesOnIntergalacticRomanValuesArray(string value, string keyAnswer, string valueAnswer)
        {
            var inputProcessor = new InputProcessor();
            var data = new List<string> { value };

            var processData = inputProcessor.ProcessData(data);

            Assert.AreEqual(keyAnswer, processData.IntergalacticRomanValues.First().Key.Trim());
            Assert.AreEqual(valueAnswer, processData.IntergalacticRomanValues.First().Value.Trim());
        }
    }
}
