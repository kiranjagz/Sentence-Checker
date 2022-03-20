using Sentence.Checker.Core.Services.CustomSentenceFormatter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sentence.Checker.Core.Services
{
    public class VowelComparerCheckOperation : ISentenceOperation
    {
        private readonly ICustomSentenceFormatter _customSentenceFormatter;
        private readonly char[] _vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

        public VowelComparerCheckOperation(ICustomSentenceFormatter customSentenceFormatter)
        {
            _customSentenceFormatter = customSentenceFormatter;
        }

        public string ValidateSentence(string sentence)
        {
            string output;

            var formattedSentence = _customSentenceFormatter.FormatWordsInSentence(sentence);

            var group = formattedSentence.ToCharArray();

            var interset = group.Intersect(_vowels);

            var except = group.Except(_vowels);

            var vowelCount = interset.Count();

            var nonVowelCOunt = except.Count();

            if (vowelCount > nonVowelCOunt)
                output = "The text has more vowels than non vowels.";
            else if (nonVowelCOunt > vowelCount)
                output = "The text has more non vowels than vowels.";
            else
                output = "The text has an equal amount of vowels and non vowels.";

            return output;
        }
    }
}
