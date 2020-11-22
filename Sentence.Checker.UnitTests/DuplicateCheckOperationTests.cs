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
    class DuplicateCheckOperationTests
    {
        private ICustomSentenceFormatter _customSentenceFormatter;
        private ISentenceOperation _sentenceService;

        [SetUp]
        public void Setup()
        {
            _customSentenceFormatter = new CustomSentenceFormatter();

            _sentenceService = new DuplicateCheckOperation(_customSentenceFormatter);
        }

        [TestCase("I Like eating apples", "Found the following duplicates: ileap")]
        [TestCase("I Like eating oranges", "Found the following duplicates: ieang")]
        [TestCase("abcdee 5", "Found the following duplicates: e")]
        public void TestReturnCharInOutputThatContainDuplicatesInASentence(string sentence, string expectedResult)
        {
            var result = _sentenceService.ValidateSentence(sentence);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("abcd 4", "No duplicate values where found.")]
        [TestCase("abcde 5", "No duplicate values where found.")]
        public void TestSentenceWithNoDuplicatesReturnNoCharInOutput(string sentence, string expectedResult)
        {
            var result = _sentenceService.ValidateSentence(sentence);

            //Nunit has built in special class to asset string values, an alternative to the above assertion.
            StringAssert.AreEqualIgnoringCase(expectedResult, result);
        }
    }
}
