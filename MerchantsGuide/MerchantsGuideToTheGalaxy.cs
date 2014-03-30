using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuide
{
    class MerchantsGuideToTheGalaxy
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var inputProcessor = new InputProcessor();
            var processedData = inputProcessor.ProcessData(lines);
            var outputProcessor = new OutputProcessor();
            var proccessAnswer = outputProcessor.ProccessAnswer(processedData);
            foreach (var questionAnswer in proccessAnswer)
            {
                Console.WriteLine(questionAnswer.Key +' '+ questionAnswer.Value);
            }
            Console.ReadLine();
        }
    }
}