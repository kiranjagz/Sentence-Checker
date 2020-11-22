using Sentence.Checker.Core.Display;
using Sentence.Checker.Core.Services;
using Sentence.Checker.Core.Services.CustomSentenceFormatter;
using System;
using System.Collections.Generic;
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
                while (true)
                {
                    //We would register this in our IoC framework, should you use one.
                    ICustomSentenceFormatter customSentenceFormatter = new CustomSentenceFormatter();
                    IDisplayResults displayResults = new DisplayResults(customSentenceFormatter);

                    //Register a pattern mapper to match options based on selection, key maps to an action, this is to eliminate the need for nested if statements or switch case.
                    //This would be on startup ideally.
                    Dictionary<string, Action<string>> patternMapper = new Dictionary<string, Action<string>>
                    {
                        ["1"] = sentence => { displayResults.CheckDuplicates(sentence); },
                        ["2"] = sentence => { displayResults.CheckVowelCount(sentence); },
                        ["3"] = sentence => { displayResults.CheckCompareVowelWithNonVowel(sentence); },
                        ["12"] = sentence => { displayResults.CheckDuplicateAndCountOfVowels(sentence); },
                        ["13"] = sentence => { displayResults.CheckDuplicateAndVowelComparer(sentence); },
                        ["23"] = sentence => { displayResults.CheckVowelCountAndVowelComparer(sentence); },
                        ["123"] = sentence => { displayResults.CheckAllConditions(sentence); }
                    };

                    Console.WriteLine("Please enter text to be analyzed!");
                    string sentence = Console.ReadLine();

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
                    string option = Console.ReadLine();

                    while (string.IsNullOrEmpty(option))
                    {
                        Console.WriteLine("Not a valid option, try again please.");
                        option = Console.ReadLine();
                    }

                    patternMapper[option](sentence);

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
