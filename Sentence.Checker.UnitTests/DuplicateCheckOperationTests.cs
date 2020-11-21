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
        // I added the custom sentence logic for removing spaces and to lower the casing, also to display test cases using moqs, and the the use of IoC principle.
        // Sorry if this is overkill.
        private Mock<ICustomSentenceFormatter> _customSentenceFormatter;
        private ISentenceOperation _sentenceService;

        [SetUp]
        public void Setup()
        {
            _customSentenceFormatter = new Mock<ICustomSentenceFormatter>();

            _sentenceService = new DuplicateCheckOperation(_customSentenceFormatter.Object);
        }

        [TestCase("I Like eating apples", "ilikeeatingapples", "Found the following duplicates: ileap")]
        [TestCase("I Like eating oranges", "ilikeeatingoranges", "Found the following duplicates: ieang")]
        [TestCase("abcdee 5", "abcdee5", "Found the following duplicates: e")]
        public void TestReturnCharInOutputThatContainDuplicatesInASentence(string sentence, string formattedSentence, string expectedResult)
        {
            _customSentenceFormatter.Setup(m => m.FormatWordsInSentence(sentence)).Returns(formattedSentence);

            var result = _sentenceService.ValidateSentence(sentence);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("abcd 4", "abcd4", "No duplicate values where found.")]
        [TestCase("abcde 5", "abcde5", "No duplicate values where found.")]
        public void TestSentenceWithNoDuplicatesReturnNoCharInOutput(string sentence, string formattedSentence, string expectedResult)
        {
            _customSentenceFormatter.Setup(m => m.FormatWordsInSentence(sentence)).Returns(formattedSentence);

            var result = _sentenceService.ValidateSentence(sentence);

            //Nunit has built in special class to asset string values, an alternative to the above assertion.
            StringAssert.AreEqualIgnoringCase(expectedResult, result);
        }
    }
}
