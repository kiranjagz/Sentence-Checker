using Moq;
using NUnit.Framework;
using Sentence.Checker.Core.Services;
using Sentence.Checker.Core.Services.CustomSentenceFormatter;

namespace Sentence.Checker.UnitTests
{
    public class SentenceTests
    {
        private Mock<ICustomSentenceFormatter> _customSentenceFormatter;
        private ISentenceService _sentenceService;

        [SetUp]
        public void Setup()
        {
            _customSentenceFormatter = new Mock<ICustomSentenceFormatter>();

            _sentenceService = new SentenceService(_customSentenceFormatter.Object);
        }

        [TestCase("I Like eating apples", "ilikeeatingapples", "ileap")]
        [TestCase("I Like eating oranges", "ilikeeatingoranges", "iean")]
        public void CheckThatSentenceDoesNotContainDuplicates(string sentence, string formattedSentence, string expectedResult)
        {
            _customSentenceFormatter.Setup(m => m.FormatWordsInSentence(It.IsAny<string>())).Returns(formattedSentence);

            var result = _sentenceService.CheckForDuplicates(sentence);

            StringAssert.Contains(expectedResult, result.Output);
        }
    }
}