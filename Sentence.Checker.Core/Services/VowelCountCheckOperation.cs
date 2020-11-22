using Sentence.Checker.Core.Services.CustomSentenceFormatter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sentence.Checker.Core.Services
{
    public class VowelCountCheckOperation : ISentenceOperation
    {
        private readonly ICustomSentenceFormatter _customSentenceFormatter;
        private readonly char[] _vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
        public VowelCountCheckOperation(ICustomSentenceFormatter customSentenceFormatter)
        {
            _customSentenceFormatter = customSentenceFormatter;
        }

        public string ValidateSentence(string sentence)
        {
            string output;

            var formattedSentence = _customSentenceFormatter.FormatWordsInSentence(sentence);

            var group = formattedSentence.ToCharArray();

            var interset = group.Intersect(_vowels);

            var vowelCount = interset.Count();

            if (vowelCount > 0)
                output = $"The number of vowels is: {vowelCount}";
            else
                output = $"No vowels where found.";

            return output;
        }
    }
}
