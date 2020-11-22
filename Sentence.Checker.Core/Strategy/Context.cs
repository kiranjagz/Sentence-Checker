using Sentence.Checker.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentence.Checker.Core.Strategy
{
    /// <summary>
    /// Using the strategy pattern to swtich implementations at runtime, this makes it easier to add new functionality to the system
    /// No tests written as these methods are void and not business logic.
    /// </summary>
    public class Context : IContext
    {
        private readonly List<ISentenceOperation> _sentenceOperations;

        public Context(List<ISentenceOperation> sentenceOperations) 
        {
            _sentenceOperations = sentenceOperations;
        }

        public void Invoke(string sentence)
        {
            _sentenceOperations.ForEach(sent =>
            {
                var result = sent.ValidateSentence(sentence);

                Console.WriteLine(result);
            });
        }
    }
}
