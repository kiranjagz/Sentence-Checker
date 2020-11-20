using NUnit.Framework;
using Sentence.Checker.Core.Services.CustomSentenceFormatter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentence.Checker.UnitTests
{
    [TestFixture]
    public class CustomSentenceFormatterTests
    {
        private ICustomSentenceFormatter _customSentenceFormatter;

        [SetUp]
        public void Setup()
        {
            _customSentenceFormatter = new CustomSentenceFormatter();
        }

        [TestCase("I like eating apples", "ilikeeatingapples")]
        [TestCase("I like eating oranges", "ilikeeatingoranges")]
        public void SentenceHasNoSpacesAndInLowerCase(string sentence, string expectedResult)
        {
            var result = _customSentenceFormatter.FormatWordsInSentence(sentence);

            StringAssert.AreEqualIgnoringCase(expectedResult, result);
        }
    }
}
