using Moq;
using NUnit.Framework;
using Sentence.Checker.Core.Services;
using Sentence.Checker.Core.Services.CustomSentenceFormatter;

namespace Sentence.Checker.UnitTests
{
    public class SentenceTests
    {
        // I added the custom sentence logic for removing spaces and to lower the casing, also to display test cases using moqs, and the the use of IoC principle.
        // Sorry if this is overkill.
        private Mock<ICustomSentenceFormatter> _customSentenceFormatter;
        private ISentenceService _sentenceService;

        [SetUp]
        public void Setup()
        {
            _customSentenceFormatter = new Mock<ICustomSentenceFormatter>();

            _sentenceService = new SentenceService(_customSentenceFormatter.Object);
        }

        [TestCase("I Like eating apples", "ilikeeatingapples", "ileap")]
        [TestCase("I Like eating oranges", "ilikeeatingoranges", "ieang")]
        public void TestReturnLettersThatAreDuplicatesInASentence(string sentence, string formattedSentence, string expectedResult)
        {
            _customSentenceFormatter.Setup(m => m.FormatWordsInSentence(sentence)).Returns(formattedSentence);

            var result = _sentenceService.CheckForDuplicates(sentence);

            Assert.That(result.Duplicates, Is.EqualTo(expectedResult));
        }

        [TestCase("I Like eating apples", "ilikeeatingapples", 3)]
        [TestCase("I Like eating oranges", "ilikeeatingoranges", 4)]
        [TestCase("jkl kkjh", "jklkkjh", 0)]
        public void TestNumberOfVowelsInASentence(string sentence, string formattedSentence, int expectedResult)
        {
            _customSentenceFormatter.Setup(m => m.FormatWordsInSentence(sentence)).Returns(formattedSentence);

            var result = _sentenceService.CountNumberOfVowels(sentence);

            Assert.That(result.VowelCount, Is.EqualTo(expectedResult));
        }
    }
}