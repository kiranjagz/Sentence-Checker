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
            string output = string.Empty;

            var customSentenceFormatter = new CustomSentenceFormatter();

            var sentenceService = new SentenceService(customSentenceFormatter);

            Console.WriteLine("Please enter text to be analyzed!");
            var sentence = Console.ReadLine();

            Console.WriteLine("Enter which operations to do on the supplied text!");
            Console.WriteLine("'1', for a duplicate character check.");
            Console.WriteLine("'2', to count the number of vowels.");
            Console.WriteLine("'3', to check if there are more vowels or non vowels.");
            Console.WriteLine("Or any combination of '1','2','3' to perform multiple checks.");
            var option = Console.ReadLine();

            //Wrap this in a selection service, and create some tests for them
            switch (option)
            {
                case "1":
                    {
                        output = sentenceService.CheckForDuplicates(sentence).Output;
                        break;
                    };
                case "2":
                    {
                        output = sentenceService.CountNumberOfVowels(sentence).Output;
                        break; ;
                    };
                case "3":
                    {
                        output = sentenceService.CompareVowelsToNonVowels(sentence).Output;
                        break;
                    };
                default:
                    {
                        output = "Opps sorry, not selection made :|";
                        break;
                    }
            };

            Console.WriteLine(output);

            Console.Read();
        }
    }
}
