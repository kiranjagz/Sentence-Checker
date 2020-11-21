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
                DisplayResults displayResults = new DisplayResults();

                //Register a pattern mapper to match options based on selection, this is to eliminate the need for nested if statements or switch
                Dictionary<string, Action<string>> patternMapper = new Dictionary<string, Action<string>>();
                patternMapper["1"] = x => { displayResults.CheckDuplicates(x); };
                patternMapper["2"] = x => { displayResults.CheckVowelCount(x); };
                patternMapper["3"] = x => { displayResults.CheckCompareVowelWithNonVowel(x); };
                patternMapper["12"] = x => { displayResults.CheckCompareVowelWithNonVowel(x); };
                patternMapper["123"] = x => { displayResults.CheckCompareVowelWithNonVowel(x); };

                Console.WriteLine("Please enter text to be analyzed!");
                var sentence = Console.ReadLine();

                Console.WriteLine("Enter which operations to do on the supplied text!");
                Console.WriteLine("'1', for a duplicate character check.");
                Console.WriteLine("'2', to count the number of vowels.");
                Console.WriteLine("'3', to check if there are more vowels or non vowels.");
                Console.WriteLine("Or any combination of '1','2','3', to perform multiple checks.");
                var option = Console.ReadLine();          

                if (!string.IsNullOrEmpty(option))
                {
                    patternMapper[option](sentence);
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
