using Sentence.Checker.Core.Services;
using Sentence.Checker.Core.Services.CustomSentenceFormatter;
using System.Collections.Generic;

namespace Sentence.Checker.Core.Extensions
{
    public static class StrategyPatternMapperExtension
    {
        public static Dictionary<int, ISentenceOperation> CreateStrategyMapper(ICustomSentenceFormatter customSentenceFormatter)
        {
            return new Dictionary<int, ISentenceOperation>
            {
                { 1, new DuplicateCheckOperation(customSentenceFormatter) },
                { 2, new VowelCountCheckOperation(customSentenceFormatter) },
                { 3, new VowelComparerCheckOperation(customSentenceFormatter) }
            };
        }
    }
}
