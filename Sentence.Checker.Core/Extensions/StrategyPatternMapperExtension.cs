using Sentence.Checker.Core.Services;
using Sentence.Checker.Core.Services.CustomSentenceFormatter;
using Sentence.Checker.Core.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentence.Checker.Core.Extensions
{
    public static class StrategyPatternMapperExtension
    {
        public static Dictionary<string, IContext> CreateStrategyMapper(ICustomSentenceFormatter customSentenceFormatter)
        {
            var strategyPattern = new Dictionary<string, IContext>();
            strategyPattern.Add("1", new Context(new List<ISentenceOperation>()
                    {
                        new DuplicateCheckOperation(customSentenceFormatter)
                    }));
            strategyPattern.Add("2", new Context(new List<ISentenceOperation>()
                    {
                        new VowelCountCheckOperation(customSentenceFormatter)
                    }));
            strategyPattern.Add("3", new Context(new List<ISentenceOperation>()
                    {
                        new VowelComparerCheckOperation(customSentenceFormatter)
                    }));
            strategyPattern.Add("12", new Context(new List<ISentenceOperation>()
                    {
                        new DuplicateCheckOperation(customSentenceFormatter),
                        new VowelCountCheckOperation(customSentenceFormatter)
                    }));
            strategyPattern.Add("13", new Context(new List<ISentenceOperation>()
                    {
                        new DuplicateCheckOperation(customSentenceFormatter),
                        new VowelComparerCheckOperation(customSentenceFormatter)
                    }));
            strategyPattern.Add("23", new Context(new List<ISentenceOperation>()
                    {
                        new VowelCountCheckOperation(customSentenceFormatter),
                        new VowelComparerCheckOperation(customSentenceFormatter)
                    }));
            strategyPattern.Add("123", new Context(new List<ISentenceOperation>()
                    {
                        new DuplicateCheckOperation(customSentenceFormatter),
                        new VowelCountCheckOperation(customSentenceFormatter),
                        new VowelComparerCheckOperation(customSentenceFormatter)
                    }));

            return strategyPattern;
        }
    }
}
