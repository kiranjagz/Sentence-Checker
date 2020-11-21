using Sentence.Checker.Core.Services;
using Sentence.Checker.Core.Services.CustomSentenceFormatter;
using System;
using System.Linq;
using System.Text;

namespace Sentence.Checker.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var customSentenceFormatter = new CustomSentenceFormatter();

            var sentenceService = new SentenceService(customSentenceFormatter);

            Console.WriteLine("Please enter a sentence to analyze!");
            var sentence = Console.ReadLine();

            Console.WriteLine("Please select an option!");
            var option = Console.ReadLine();

            switch (option)
            {

            };

            Console.Read();
        }
    }
}
