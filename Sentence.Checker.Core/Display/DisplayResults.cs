using Sentence.Checker.Core.Services;
using Sentence.Checker.Core.Services.CustomSentenceFormatter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentence.Checker.Core.Display
{
    /// <summary>
    /// This is kind of a wrapper to perform extra logic based on selection.
    /// No tests written as these methods are void and not business logic.
    /// </summary>
    public class DisplayResults : IDisplayResults
    {
        private ISentenceOperation _sentenceOperation;
        private List<ISentenceOperation> _sentenceOperationsList;
        private readonly ICustomSentenceFormatter _customSentenceFormatter;

        public DisplayResults(ICustomSentenceFormatter customSentenceFormatter)
        {
            _customSentenceFormatter = customSentenceFormatter;
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

        public void CheckDuplicateAndCountOfVowels(string sentence)
        {
            _sentenceOperationsList = new List<ISentenceOperation>
            {
                new DuplicateCheckOperation(_customSentenceFormatter),
                new VowelCountCheckOperation(_customSentenceFormatter)
            };

            _sentenceOperationsList.ForEach(sent =>
            {
                Console.WriteLine(sent.ValidateSentence(sentence));
            });
        }

        public void CheckDuplicateAndVowelComparer(string sentence)
        {
            _sentenceOperationsList = new List<ISentenceOperation>
            {
                new DuplicateCheckOperation(_customSentenceFormatter),
                new VowelComparerCheckOperation(_customSentenceFormatter)
            };

            _sentenceOperationsList.ForEach(sent =>
            {
                Console.WriteLine(sent.ValidateSentence(sentence));
            });
        }

        public void CheckVowelCountAndVowelComparer(string sentence)
        {
            _sentenceOperationsList = new List<ISentenceOperation>
            {
                new VowelCountCheckOperation(_customSentenceFormatter),
                new VowelComparerCheckOperation(_customSentenceFormatter)
            };

            _sentenceOperationsList.ForEach(sent =>
            {
                Console.WriteLine(sent.ValidateSentence(sentence));
            });
        }

        public void CheckAllConditions(string sentence)
        {
            _sentenceOperationsList = new List<ISentenceOperation>
            {
                new DuplicateCheckOperation(_customSentenceFormatter),
                new VowelCountCheckOperation(_customSentenceFormatter),
                new VowelComparerCheckOperation(_customSentenceFormatter)
            };

            _sentenceOperationsList.ForEach(sent =>
            {
                Console.WriteLine(sent.ValidateSentence(sentence));
            });
        }
    }
}
