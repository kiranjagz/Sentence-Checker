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
    class VowelCountCheckOperationTests
    {
        private ICustomSentenceFormatter _customSentenceFormatter;
        private ISentenceOperation _sentenceService;

        [SetUp]
        public void Setup()
        {
            _customSentenceFormatter = new CustomSentenceFormatter();

            _sentenceService = new VowelCountCheckOperation(_customSentenceFormatter);
        }

        [TestCase("I Like eating apples", "The number of vowels is: 3")]
        [TestCase("I Like eating oranges", "The number of vowels is: 4")]
        public void TestNumberOfVowelsInASentenceReturnCountInOutput(string sentence, string expectedResult)
        {
            var result = _sentenceService.ValidateSentence(sentence);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("jkl kkjh", "No vowels where found.")]
        public void TestSentenceWithNoVowelsReturnNoVowelsOutput(string sentence, string expectedResult)
        {
            var result = _sentenceService.ValidateSentence(sentence);

            StringAssert.AreEqualIgnoringCase(expectedResult, result);
        }
    }
}
