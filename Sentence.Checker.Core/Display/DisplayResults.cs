using Sentence.Checker.Core.Services;
using Sentence.Checker.Core.Services.CustomSentenceFormatter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentence.Checker.Core.Display
{
    /// <summary>
    /// This is kind of a wrapper to perform extra logic based on selection
    /// </summary>
    public class DisplayResults
    {
        private ISentenceOperation _sentenceOperation;
        private ICustomSentenceFormatter _customSentenceFormatter;

        public DisplayResults()
        {
            _customSentenceFormatter = new CustomSentenceFormatter();
        }

        public void CheckDuplicates(string sentence)
        {
            _sentenceOperation = new DuplicateCheckOperation(_customSentenceFormatter);

            Console.WriteLine(_sentenceOperation.ValidateSentence(sentence));
        }

        public void CheckVowelCount(string sentence)
        {
            _sentenceOperation = new VowelCountCheckOperation(_customSentenceFormatter);

            Console.WriteLine(_sentenceOperation.ValidateSentence(sentence));
        }

        public void CheckCompareVowelWithNonVowel(string sentence)
        {
            _sentenceOperation = new VowelComparerCheckOperation(_customSentenceFormatter);

            Console.WriteLine(_sentenceOperation.ValidateSentence(sentence));
        }
    }
}
