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
        // I added the custom sentence logic for removing spaces and to lower the casing, also to display test cases using moqs, and the the use of IoC principle.
        // Sorry if this is overkill.
        private Mock<ICustomSentenceFormatter> _customSentenceFormatter;
        private ISentenceOperation _sentenceService;

        [SetUp]
        public void Setup()
        {
            _customSentenceFormatter = new Mock<ICustomSentenceFormatter>();

            _sentenceService = new VowelCountCheckOperation(_customSentenceFormatter.Object);
        }

        [TestCase("I Like eating apples", "ilikeeatingapples", "The number of vowels is: 3")]
        [TestCase("I Like eating oranges", "ilikeeatingoranges", "The number of vowels is: 4")]
        public void TestNumberOfVowelsInASentenceReturnCountInOutput(string sentence, string formattedSentence, string expectedResult)
        {
            _customSentenceFormatter.Setup(m => m.FormatWordsInSentence(sentence)).Returns(formattedSentence);

            var result = _sentenceService.ValidateSentence(sentence);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("jkl kkjh", "jklkkjh", "No vowels where found.")]
        public void TestSentenceWithNoVowelsReturnNoVowelsOutput(string sentence, string formattedSentence, string expectedResult)
        {
            _customSentenceFormatter.Setup(m => m.FormatWordsInSentence(sentence)).Returns(formattedSentence);

            var result = _sentenceService.ValidateSentence(sentence);

            StringAssert.AreEqualIgnoringCase(expectedResult, result);
        }
    }
}
