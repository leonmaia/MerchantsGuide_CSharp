using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MerchantsGuide.Models;
using NUnit.Framework;

namespace MerchantsGuide.Tests
{
    [TestFixture]
    class OutputProcessorTests
    {

        private Variables _processedData;

        [SetUp]
        public void Setup()
        {
            var listLines = new List<string>
            {
                "glob is I",
                "prok is V",
                "pish is X",
                "tegj is L",
                "glob glob Silver is 34 Credits",
                "glob prok Gold is 57800 Credits",
                "pish pish Iron is 3910 Credits",
                "how much is pish tegj glob glob ?",
                "how many Credits is glob prok Silver ?",
                "how many Credits is glob prok Gold ?",
                "how many Credits is glob prok Iron ?",
                "how much wood could a woodchuck chuck if a woodchuck could chuck wood ?"
            };

            var inputProcessor = new InputProcessor();
            _processedData = inputProcessor.ProcessData(listLines);
        }

        [Test]
        public void ShouldReturnVariablesWithCalculatedElements()
        {
            var outputProcessor = new OutputProcessor();
            var calculatedElementValues = outputProcessor.CalculateElementValues(_processedData).ElementValues;

            Assert.AreEqual(17.0, calculatedElementValues["Silver"]);
            Assert.AreEqual(14450.0, calculatedElementValues["Gold"]);
            Assert.AreEqual(195.5, calculatedElementValues["Iron"]);
        }

        [Test]
        public void ShouldReturnVariablesWithAnswers()
        {
            var outputProcessor = new OutputProcessor();
            var calculatedElementValues = outputProcessor.ProccessAnswer(_processedData);

            Assert.AreEqual("is 42", calculatedElementValues["pish tegj glob glob"]);
            Assert.AreEqual("is 68 Credits", calculatedElementValues["glob prok Silver"]);
            Assert.AreEqual("is 57800 Credits", calculatedElementValues["glob prok Gold"]);
            Assert.AreEqual("is 782 Credits", calculatedElementValues["glob prok Iron"]);
            Assert.AreEqual("", calculatedElementValues["I have no idea what you are talking about"]);
        }
    }
}
