using Sentence.Checker.Api.Facade.SentenceChecker.Models;
using Sentence.Checker.Core.Services;
using Sentence.Checker.Core.Services.CustomSentenceFormatter;

namespace Sentence.Checker.Api.Facade.SentenceChecker
{
    public class SentenceCheckerFacade : ISentenceCheckerFacade
    {
        //TODO: inject these services on startup
        private Dictionary<int, ISentenceOperation> _sentenceOperations;
        private ICustomSentenceFormatter _customSentenceFormatter;

        public SentenceCheckerFacade()
        {
            //TODO: pass the interface in the constructor
            _customSentenceFormatter = new CustomSentenceFormatter();

            _sentenceOperations = new Dictionary<int, ISentenceOperation>
            {
                { 1, new DuplicateCheckOperation(_customSentenceFormatter) },
                { 2, new VowelCountCheckOperation(_customSentenceFormatter) },
                { 3, new VowelComparerCheckOperation(_customSentenceFormatter) }
            };
        }

        /// <summary>
        /// Validates a sentence based on a set limit of operations
        /// </summary>
        /// <param name="sentenceCheckerRequest"></param>
        /// <returns></returns>
        public async Task<SentenceCheckerResponse> ValidateSentence(SentenceCheckerRequest sentenceCheckerRequest)
        {
            //TODO: make this code block async
            var options = sentenceCheckerRequest.Options;

            var response = new SentenceCheckerResponse();

            if (!string.IsNullOrEmpty(options))
            {
                var optionArray = options.ToCharArray();

                foreach (var item in optionArray)
                {
                    var value = int.Parse(item.ToString());

                    var result = _sentenceOperations[value]
                        .ValidateSentence(sentenceCheckerRequest.Sentence);

                    if (!string.IsNullOrEmpty(result))
                    {
                        response.Result?.Add(item.ToString(), result);
                    }
                }

                response.Message = "The system has processed the request successfully";
            }

            return response;
        }
    }
}
