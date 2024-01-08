using Sentence.Checker.Api.Facade.SentenceChecker.Models;

namespace Sentence.Checker.Api.Facade.SentenceChecker
{
    public interface ISentenceCheckerFacade
    {
        Task<SentenceCheckerResponse> ValidateSentence(SentenceCheckerRequest sentenceCheckerRequest);
    }
}
