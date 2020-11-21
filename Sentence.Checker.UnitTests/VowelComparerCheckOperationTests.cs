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
        // I added the custom sentence logic for removing spaces and to lower the casing, also to display test cases using moqs, and the the use of IoC principle.
        // Sorry if this is overkill.
        private Mock<ICustomSentenceFormatter> _customSentenceFormatter;
        private ISentenceOperation _sentenceService;

        [SetUp]
        public void Setup()
        {
            _customSentenceFormatter = new Mock<ICustomSentenceFormatter>();

            _sentenceService = new VowelComparerCheckOperation(_customSentenceFormatter.Object);
        }

        [TestCase("I eat", "ieat", "The text has more vowels than non vowels.")]
        public void TestSentenceHasMoreVowelsThanNonVowels(string sentence, string formattedSentence, string expectedResult)
        {
            _customSentenceFormatter.Setup(m => m.FormatWordsInSentence(sentence)).Returns(formattedSentence);

            var result = _sentenceService.ValidateSentence(sentence);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("I eat grapes now", "ieatgrapesnow", "The text has more non vowels than vowels.")]
        public void TestSentenceHasMoreNonVowelsThanVowels(string sentence, string formattedSentence, string expectedResult)
        {
            _customSentenceFormatter.Setup(m => m.FormatWordsInSentence(sentence)).Returns(formattedSentence);

            var result = _sentenceService.ValidateSentence(sentence);

            Assert.That(result, Is.EqualTo(expectedResult));
        }


        [TestCase("Heya", "heya", "The text has an equal amount of vowels and non vowels.")]
        public void TestEqualNumberOfVowelsAndNonVowels(string sentence, string formattedSentence, string expectedResult)
        {
            _customSentenceFormatter.Setup(m => m.FormatWordsInSentence(sentence)).Returns(formattedSentence);

            var result = _sentenceService.ValidateSentence(sentence);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
