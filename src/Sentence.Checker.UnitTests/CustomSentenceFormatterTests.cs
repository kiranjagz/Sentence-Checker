using Moq;
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
        //Example of using moq framework
        private Mock<ICustomSentenceFormatter> _mockSentenceFormatter;

        [SetUp]
        public void Setup()
        {
            _customSentenceFormatter = new CustomSentenceFormatter();

            _mockSentenceFormatter = new Mock<ICustomSentenceFormatter>(MockBehavior.Default);
        }

        [TestCase("I like eating apples", "ilikeeatingapples1")]
        [TestCase("I like eating oranges", "ilikeeatingoranges")]
        public void TestASentenceHasNoSpacesAndInLowerCase(string sentence, string expectedResult)
        {
            var result = _customSentenceFormatter.FormatWordsInSentence(sentence);

            StringAssert.AreEqualIgnoringCase(expectedResult, result);
        }

        [TestCase("I like eating apples!!", "ilikeeatingapples")]
        [TestCase("Do you like eating oranges?", "doyoulikeeatingoranges")]
        [TestCase("Today will be a good day.", "todaywillbeagoodday")]
        public void TestASentenceRemoveCommonPunctuationChar(string sentence, string expectedResult)
        {
            var result = _customSentenceFormatter.FormatWordsInSentence(sentence);

            StringAssert.AreEqualIgnoringCase(expectedResult, result);
        }

        [TestCase("")]
        public void TestEmptyStringThrowsArgumentException(string sentence)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                _customSentenceFormatter.FormatWordsInSentence(sentence);
            });

            Assert.Multiple(() =>
            {
                StringAssert.StartsWith("Empty string provided.", ex.Message);
                Assert.That(ex, Is.InstanceOf<ArgumentException>());
            });
        }

        //Use moq framework
        [TestCase("Interface created first with no body", "interfacecreatedfirstwithnobody")]
        [TestCase("I am using moq to check behaviour", "iamusingmoqtocheckbehavour")]
        [TestCase("What is your name", "whatisyourname")]
        public void TestBehaviourNoSpaceLowerCaseUsingMoq(string sentence, string expectedResult)
        {
            _mockSentenceFormatter.Setup(sent => sent.FormatWordsInSentence(sentence)).Returns(expectedResult);

            var result = _mockSentenceFormatter.Object.FormatWordsInSentence(sentence);

            StringAssert.AreEqualIgnoringCase(expectedResult, result);
        }
    }
}
