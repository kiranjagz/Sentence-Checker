using Sentence.Checker.Core.Services.CustomSentenceFormatter;
using Sentence.Checker.Core.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sentence.Checker.Core.Services
{
    public class SentenceService : ISentenceService
    {
        private ICustomSentenceFormatter _customSentenceFormatter;

        public SentenceService(ICustomSentenceFormatter customSentenceFormatter)
        {
            _customSentenceFormatter = customSentenceFormatter;
        }

        public SentenceModel CheckForDuplicates(string sentence)
        {
            var formattedSentence = _customSentenceFormatter.FormatWordsInSentence(sentence);

            var group = formattedSentence.ToCharArray().GroupBy(p => p);

            var duplicatesInArray = group.Where(g => g.Count() > 1).Select(g => g.Key).ToList();

            var duplicateLetters = string.Join("", duplicatesInArray);

            return new SentenceModel { Output = $"Found the following duplicates: {duplicateLetters}", Duplicates = duplicateLetters };
        }
    }
}
