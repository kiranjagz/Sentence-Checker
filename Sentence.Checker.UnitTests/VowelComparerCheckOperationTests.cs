using Moq;
using NUnit.Framework;
using Sentence.Checker.Core.Services;
using Sentence.Checker.Core.Services.CustomSentenceFormatter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentence.Checker.UnitTests
{
    [TestFixture]
    class VowelComparerCheckOperationTests
    {
        private ICustomSentenceFormatter _customSentenceFormatter;
        private ISentenceOperation _sentenceService;

        [SetUp]
        public void Setup()
        {
            _customSentenceFormatter = new CustomSentenceFormatter();

            _sentenceService = new VowelComparerCheckOperation(_customSentenceFormatter);
        }

        [TestCase("I eat", "The text has more vowels than non vowels.")]
        public void TestSentenceHasMoreVowelsThanNonVowels(string sentence, string expectedResult)
        {
            var result = _sentenceService.ValidateSentence(sentence);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("that dog", "The text has more non vowels than vowels.")]
        [TestCase("I eat grapes now", "The text has more non vowels than vowels.")]
        public void TestSentenceHasMoreNonVowelsThanVowels(string sentence, string expectedResult)
        {
            var result = _sentenceService.ValidateSentence(sentence);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("3 a", "The text has an equal amount of vowels and non vowels.")]
        [TestCase("Heya", "The text has an equal amount of vowels and non vowels.")]
        public void TestEqualNumberOfVowelsAndNonVowels(string sentence, string expectedResult)
        {
            var result = _sentenceService.ValidateSentence(sentence);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
