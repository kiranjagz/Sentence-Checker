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
            try
            {
                //Need to use string builder here to concat, instead of string join
                var output = new StringBuilder();

                var customSentenceFormatter = new CustomSentenceFormatter();

                var sentenceService = new SentenceService(customSentenceFormatter);

                Console.WriteLine("Please enter text to be analyzed!");
                var sentence = Console.ReadLine();

                Console.WriteLine("Enter which operations to do on the supplied text!");
                Console.WriteLine("'1', for a duplicate character check.");
                Console.WriteLine("'2', to count the number of vowels.");
                Console.WriteLine("'3', to check if there are more vowels or non vowels.");
                Console.WriteLine("Or any combination of '1','2','3', to perform multiple checks.");
                var option = Console.ReadLine();

                //Wrap this in a selection service, and create some tests for them
                switch (option)
                {
                    case "1":
                        {
                            var duplicateResult = sentenceService.CheckForDuplicates(sentence);
                            output.AppendLine(duplicateResult.Output);
                            break;
                        };
                    case "2":
                        {
                            var numberVowelsResult = sentenceService.CountNumberOfVowels(sentence);
                            output.AppendLine(numberVowelsResult.Output);
                            break;
                        };
                    case "3":
                        {
                            var compareVowelsResult = sentenceService.CompareVowelsToNonVowels(sentence);
                            output.AppendLine(compareVowelsResult.Output);
                            break;
                        };
                    case "12":
                        {
                            var duplicateResult = sentenceService.CheckForDuplicates(sentence);
                            var numberVowelsResult = sentenceService.CountNumberOfVowels(sentence);
                            output.AppendLine(duplicateResult.Output);
                            output.AppendLine(numberVowelsResult.Output);
                            break;
                        };
                    default:
                        {
                            output.AppendLine("Oops the selection was invalid??");
                            break;
                        }
                };
                
                Console.WriteLine(output);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred, error message: {ex.Message}");
         
            }

            Console.Read();
        }
    }
}
