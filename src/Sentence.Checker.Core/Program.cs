using Sentence.Checker.Core.Extensions;
using Sentence.Checker.Core.Services.CustomSentenceFormatter;
using System;

namespace Sentence.Checker.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    var customSentenceFormatter = new CustomSentenceFormatter();

                    //Registered a pattern mapper to match options based on selection, key maps to sentence operations.
                    //This is to eliminate the need for nested if statements or switch case.
                    //This would be on startup ideally, and using an IoC framework.
                    var strategyPattern = StrategyPatternMapperExtension.CreateStrategyMapper(customSentenceFormatter);

                    Console.WriteLine("Please enter text to be analyzed!");
                    var sentence = Console.ReadLine();

                    while (string.IsNullOrEmpty(sentence))
                    {
                        Console.WriteLine("Not a valid sentence, try again please.");
                        sentence = Console.ReadLine();
                    }

                    Console.WriteLine("Enter which operations to do on the supplied text!");
                    Console.WriteLine("'1', for a duplicate character check.");
                    Console.WriteLine("'2', to count the number of vowels.");
                    Console.WriteLine("'3', to check if there are more vowels or non vowels.");
                    Console.WriteLine("Or any combination of '1','2','3', to perform multiple checks.");
                    var option = Console.ReadLine();

                    while (string.IsNullOrEmpty(option))
                    {
                        Console.WriteLine("Not a valid option, try again please.");
                        option = Console.ReadLine();
                    }

                    var optionArray = option.ToCharArray();

                    foreach (var item in optionArray)
                    {
                        var value = int.Parse(item.ToString());

                        var result = strategyPattern[value].ValidateSentence(sentence);

                        Console.WriteLine(result);
                    }

                    Console.WriteLine("========================================");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred, error message: {ex.Message}");
            }

            Console.Read();
        }
    }
}
