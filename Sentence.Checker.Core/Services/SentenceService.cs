﻿using Sentence.Checker.Core.Services.CustomSentenceFormatter;
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
        private char[] _vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

        public SentenceService(ICustomSentenceFormatter customSentenceFormatter)
        {
            _customSentenceFormatter = customSentenceFormatter;
        }

        public DuplicatesModel CheckForDuplicates(string sentence)
        {
            string output;
            string duplicatedLetters = string.Empty;

            var formattedSentence = _customSentenceFormatter.FormatWordsInSentence(sentence);

            var group = formattedSentence.ToCharArray().GroupBy(p => p);

            var duplicatesInArray = group.Where(g => g.Count() > 1).Select(g => g.Key).ToList();

            if (duplicatesInArray.Count > 0)
            {
                duplicatedLetters = string.Join("", duplicatesInArray);
                output = $"Found the following duplicates: {duplicatedLetters}";
            }
            else
            {
                output = "No duplicate values where found.";
            }

            return new DuplicatesModel { Output = output, Duplicates = duplicatedLetters };
        }

        public VowelCountModel CountNumberOfVowels(string sentence)
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

            return new VowelCountModel { Output = output , VowelCount = vowelCount };
        }
    }
}
