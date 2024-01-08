namespace Sentence.Checker.Api.Facade.SentenceChecker.Models
{
    public class SentenceCheckerResponse
    {
        public SentenceCheckerResponse()
        {
            Result = new Dictionary<string, object> ();
        }

        public string? Message { get; set; }
        public DateTime? RequestedDateTime => DateTime.Now;
        public Dictionary<string, object>? Result { get; set; }
    }
}
