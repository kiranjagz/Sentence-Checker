using Sentence.Checker.Core.Services.CustomSentenceFormatter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sentence.Checker.Core.Services
{
    public class DuplicateCheckOperation : ISentenceOperation
    {
        private readonly ICustomSentenceFormatter _customSentenceFormatter;

        public DuplicateCheckOperation(ICustomSentenceFormatter customSentenceFormatter)
        {
            _customSentenceFormatter = customSentenceFormatter;
        }

        public string ValidateSentence(string sentence)
        {
            string output;
            string duplicatedLetters = string.Empty;

            var formattedSentence = _customSentenceFormatter.FormatWordsInSentence(sentence);

            var group = formattedSentence
                .ToCharArray()
                .GroupBy(p => p);

            var duplicatesInArray = group
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicatesInArray.Count > 0)
            {
                duplicatedLetters = string.Join("", duplicatesInArray);
                output = $"Found the following duplicates: {duplicatedLetters}";
            }
            else
            {
                output = "No duplicate values where found.";
            }

            return output;
        }
    }
}
